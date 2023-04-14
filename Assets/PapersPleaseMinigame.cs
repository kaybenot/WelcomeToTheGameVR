using System;
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
    
    private IdDataGenerator idDataGenerator = new IdDataGenerator();
    private bool areSame;

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

    public void OnAcceptClick() {
        if (areSame)
            OnSuccess();
        else
            OnFailure();
    }
    
    public void OnRejectClick() {
        if (!areSame)
            OnSuccess();
        else
            OnFailure();
    }

    void OnSuccess() {
        FillWithNewData();
        
        TasksToDo--;
        OnTasksUpdated?.Invoke(TasksToDo);
    }
    
    void OnFailure() {
        punishmentPanel.Punish(FillWithNewData);
        
        // TODO: Variable task increase
        TasksToDo++;
        OnTasksUpdated?.Invoke(TasksToDo);
    }
}