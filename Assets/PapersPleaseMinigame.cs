using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PapersPleaseMinigame : MonoBehaviour {
    IdDataGenerator idDataGenerator = new IdDataGenerator();
    [SerializeField] TMP_Text paperText;
    [SerializeField] TMP_Text websiteText;
    bool areSame;

    void Awake() {
        FillWithNewData();
    }

    public void FillWithNewData() {
        var ids = idDataGenerator.GeneratePairOfIds();
        paperText.text = ids.paperDocument.GetAsPaperText();
        websiteText.text = ids.websiteDocument.GetAsWebsiteText();
    }
}