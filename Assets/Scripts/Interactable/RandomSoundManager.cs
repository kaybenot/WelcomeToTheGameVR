using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundManager : MonoBehaviour
{
    [SerializeField] GameObject randomSoundPrefab;
    [SerializeField] float timeToStart = 5f;
    [SerializeField] float timeBetween = 20f;

    private void Start()
    {
        InvokeRepeating("SpawnSound",timeToStart,timeBetween);
    }

    public void SpawnSound()
    {
        Instantiate(randomSoundPrefab);
    }
}
