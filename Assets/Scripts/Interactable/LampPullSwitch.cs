using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampPullSwitch : MonoBehaviour
{
    [SerializeField] Joint spring;
    [SerializeField] GameObject lightGO;
    [SerializeField] Light lightComp;
    [SerializeField] float forceToPull = 1f;
    [SerializeField] float timeBetweenPulls = 0.5f;
    [SerializeField] private GameObject lampOn;
    [SerializeField] private GameObject lampOff;
    [SerializeField] AudioClip[] lampSounds;
    [SerializeField] float offIntensity;
    [SerializeField] float offRange;

    AudioSource audioSource;

    public bool isOn = true;

    float startIntensity;
    float startRange;

    private void Start()
    {
        //ChangeMode();
        audioSource = GetComponent<AudioSource>();
        startIntensity = lightComp.intensity;
        startRange = lightComp.range;
    }

    public void ChangeMode()
    {
        if (isOn)
        {
            //lightGO.SetActive(false);
            lampOff.SetActive(true);
            lampOn.SetActive(false);
            lightComp.intensity = offIntensity;
            lightComp.range = offRange;
        }
        else
        {
            //lightGO.SetActive(true);
            lampOff.SetActive(false);
            lampOn.SetActive(true);
            lightComp.intensity = startIntensity;
            lightComp.range = startRange;
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
