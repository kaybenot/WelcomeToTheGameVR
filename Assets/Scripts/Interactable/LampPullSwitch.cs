using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampPullSwitch : MonoBehaviour
{
    [SerializeField] Joint spring;
    [SerializeField] GameObject lightGO;
    [SerializeField] float forceToPull = 1f;
    [SerializeField] float timeBetweenPulls = 0.5f;

    float currentTimeBetweenPulls = 0f;

    bool isOn = false;

    private void Start()
    {
        lightGO.SetActive(false);
    }

    void Update()
    {
        Debug.Log(spring.currentForce);

        if(Mathf.Abs(spring.currentForce.y) > forceToPull)
        {
            if (currentTimeBetweenPulls > timeBetweenPulls)
            {
                ChangeMode();
                currentTimeBetweenPulls = 0f;
            }
        }

        currentTimeBetweenPulls += Time.deltaTime;
    }

    public void ChangeMode()
    {
        if(isOn) lightGO.SetActive(false);
        else lightGO.SetActive(true);

        isOn = !isOn;
    }
}
