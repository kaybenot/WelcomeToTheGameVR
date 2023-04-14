using TMPro;
using UnityEngine;

public class PapersPleaseMinigame : MonoBehaviour {
    IdDataGenerator idDataGenerator = new IdDataGenerator();
    [SerializeField] TMP_Text paperText;
    [SerializeField] TMP_Text websiteText;
    [SerializeField] PunishmentPanel punishmentPanel;
    bool areSame;

    void Awake() {
        FillWithNewData();
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
    }
    
    void OnFailure() {
        punishmentPanel.Punish(FillWithNewData);
    }
}