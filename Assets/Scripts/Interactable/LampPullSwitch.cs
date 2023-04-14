using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampPullSwitch : MonoBehaviour
{
    [SerializeField] Joint spring;
    [SerializeField] GameObject lightGO;
    [SerializeField] float forceToPull = 1f;
    [SerializeField] float timeBetweenPulls = 0.5f;
    [SerializeField] private GameObject lampOn;
    [SerializeField] private GameObject lampOff;
    [SerializeField] AudioClip[] lampSounds;

    AudioSource audioSource;
    float currentTimeBetweenPulls = 0f;

    public bool isOn = true;

    private void Start()
    {
        ChangeMode();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
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
        if (isOn)
        {
            lightGO.SetActive(false);
            lampOff.SetActive(true);
            lampOn.SetActive(false);
        }
        else
        {
            lightGO.SetActive(true);
            lampOff.SetActive(false);
            lampOn.SetActive(true);
        }

        isOn = !isOn;

        audioSource.clip = lampSounds[Random.Range(0,lampSounds.Length)];
        audioSource.Play();
    }

    public void SetOn()
    {
        lightGO.SetActive(true);
        isOn = true;
    }

    public void SetOff()
    {
        lightGO.SetActive(false);
        isOn = false;
    }
}
