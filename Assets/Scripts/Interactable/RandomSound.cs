using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    [SerializeField] AudioClip[] audioclips;
    [SerializeField] Vector3[] soundTransform;

    AudioSource audioSource;

    void Start()
    {
        int random = Random.Range(0, audioclips.Length);

        audioSource = GetComponent<AudioSource>();

        audioSource.clip = audioclips[random];
        Destroy(gameObject, audioSource.clip.length);
        transform.position = soundTransform[random];

        audioSource.Play();

       
    }


}
