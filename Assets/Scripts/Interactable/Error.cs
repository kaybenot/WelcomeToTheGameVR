using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Error : MonoBehaviour
{
    [SerializeField] GameObject blueScreen;
    [SerializeField] int minTime = 40, maxTime = 60;
     GameObject minigame;

    private void Start()
    {
        minigame = FindObjectOfType<PapersPleaseMinigame>().transform.gameObject;
        DeactivadeBlueScreen();
        StartCoroutine(StartCounter());
    }

    public void ActivadeBlueScreen()
    {
        blueScreen.SetActive(true);
        minigame.SetActive(false);
    }

    public void DeactivadeBlueScreen()
    {
        blueScreen.SetActive(false);
        minigame.SetActive(true);
    }

    IEnumerator StartCounter()
    {
        int random = Random.Range(minTime,maxTime);
        yield return new WaitForSeconds(random);
        ActivadeBlueScreen();
        StartCoroutine(StartCounter());
    }
}
