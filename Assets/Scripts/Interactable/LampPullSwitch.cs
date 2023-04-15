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
    [SerializeField] GameObject killerPrefab;

    AudioSource audioSource;

    public bool isOn = true;

    private void Start()
    {
        //ChangeMode();
        audioSource = GetComponent<AudioSource>();
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

            int random = Random.Range(0, 5);
            if (random == 0)
            {
                GameObject go = Instantiate(killerPrefab, transform.position + new Vector3(0f, 0.1f, 0.1f), transform.rotation * Quaternion.Euler(0, 90f, 0));
                Destroy(go.gameObject, 1f);
            }
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
