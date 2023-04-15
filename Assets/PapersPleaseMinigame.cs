using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using XRController = UnityEngine.InputSystem.XR.XRController;

public class PapersPleaseMinigame : MonoBehaviour {
    
    public int TasksToDo { get; private set; }
    public Action<int> OnTasksUpdated { get; set; }
    
    [SerializeField] TMP_Text paperText;
    [SerializeField] TMP_Text websiteText;
    [SerializeField] TMP_Text counterText;
    [SerializeField] PunishmentPanel punishmentPanel;
    [SerializeField] private float cooldownTime = 0.5f;
    [SerializeField] private float punishmentTime = 3f;
    
    private IdDataGenerator idDataGenerator = new IdDataGenerator();
    private bool areSame;
    private bool onCooldown;
    private bool punished;

    void Awake() {
        FillWithNewData();

        TasksToDo = GameManager.Instance.gameData.TasksToDo;
        OnTasksUpdated += (count) => counterText.text = count.ToString();
    }

    private void Start()
    {
        OnTasksUpdated?.Invoke(TasksToDo);
    }

    public void FillWithNewData() {
        var ids = idDataGenerator.GeneratePairOfIds();
        paperText.text = ids.paperDocument.GetAsPaperText();
        websiteText.text = ids.websiteDocument.GetAsWebsiteText();
        areSame = ids.areSame;
    }

    public void OnAcceptClick()
    {
        if (onCooldown || punished)
            return;
        
        if (areSame)
            OnSuccess();
        else
            OnFailure();

        onCooldown = true;
        StartCoroutine(ButtonCooldown());
    }
    
    public void OnRejectClick()
    {
        if (onCooldown || punished)
            return;
        
        if (!areSame)
            OnSuccess();
        else
            OnFailure();
        
        onCooldown = true;
        StartCoroutine(ButtonCooldown());
    }

    void OnSuccess() {
        if (TasksToDo <= 0)
        {
            GameManager.Instance.LoadWinScreen(1);
            return;
        }

        FillWithNewData();
        
        TasksToDo--;
        OnTasksUpdated?.Invoke(TasksToDo);
    }
    
    void OnFailure() {
        punishmentPanel.Punish(FillWithNewData, punishmentTime);
        
        punished = true;
        StartCoroutine(PunishCooldown());
        
        // TODO: Variable task increase
        TasksToDo++;
        OnTasksUpdated?.Invoke(TasksToDo);
    }

    IEnumerator ButtonCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
    }
    
    IEnumerator PunishCooldown()
    {
        yield return new WaitForSeconds(punishmentTime);
        punished = false;
    }

    public void HideCanvas()
    {
        foreach (var canvas in GetComponentsInChildren<Canvas>())
            canvas.enabled = false;
    }

    public void ShowCanvas()
    {
        foreach (var canvas in GetComponentsInChildren<Canvas>())
            canvas.enabled = true;
    }
}