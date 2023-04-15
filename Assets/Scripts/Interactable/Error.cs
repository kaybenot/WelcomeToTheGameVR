using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Error : MonoBehaviour
{
    [SerializeField] GameObject blueScreen;
    [SerializeField] int minTime = 40, maxTime = 60;
    [SerializeField] PapersPleaseMinigame minigame;

    private void Start()
    {
        DeactivadeBlueScreen();
        StartCoroutine(StartCounter());
    }

    public void ActivadeBlueScreen()
    {
        blueScreen.SetActive(true);
        minigame.HideCanvas();
    }

    public void DeactivadeBlueScreen()
    {
        blueScreen.SetActive(false);
        minigame.ShowCanvas();
    }

    IEnumerator StartCounter()
    {
        int random = Random.Range(minTime,maxTime);
        yield return new WaitForSeconds(random);
        ActivadeBlueScreen();
        StartCoroutine(StartCounter());
    }
}
