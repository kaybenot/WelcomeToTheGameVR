using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    [SerializeField] AudioClip[] audioclips;
    [SerializeField] Vector3[] soundTransform;

    static int lastRandom;

    AudioSource audioSource;

    void Start()
    {
        int random = Random.Range(0, audioclips.Length);

        if (random == lastRandom) return;

        audioSource = GetComponent<AudioSource>();

        audioSource.panStereo = Random.Range(-1f, 1f);
        audioSource.clip = audioclips[random];
        Destroy(gameObject, audioSource.clip.length);
        transform.position = soundTransform[random];

        audioSource.Play();
        lastRandom = random;

    }


}
