using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestClicking : MonoBehaviour {
    [SerializeField] TMP_Text text;

    public void Randomize() {
        text.text = "" + Random.Range(0, 100);
    }
}
