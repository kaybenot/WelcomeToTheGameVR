using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerBehindMonitor : MonoBehaviour
{
    [SerializeField] GameObject killer;
    [SerializeField] int minTime = 60, maxTime = 80;
    [SerializeField] Transform scarePos;

    private void Start()
    {
        StartCoroutine(StartCounter());
    }


    IEnumerator StartCounter()
    {
        int random = Random.Range(minTime,maxTime);
        yield return new WaitForSeconds(random);
        GameObject go = Instantiate(killer,scarePos.position,scarePos.transform.rotation);
        Destroy(go.gameObject,3f);
        StartCoroutine(StartCounter());
    }
}
