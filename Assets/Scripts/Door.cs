using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Door : JumpscareProvider
{
    [SerializeField] private AudioClip footstepClip;
    [SerializeField] private Transform handle;
    [SerializeField] private float timeToKill = 3f;
    [SerializeField] private int checkCount = 3;
    [SerializeField] private float checkDuration = 1f;

    // TODO: Temporarily
    [SerializeField] private Vector2Int attackTime = new (50, 70); 

    private WindowLoseAnimation loseAnim;
    private AudioSource source;
    private Animator animator;
    private static readonly int OpenDoor = Animator.StringToHash("OpenDoor");

    bool isReady = true;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        loseAnim = FindObjectOfType<WindowLoseAnimation>();
        animator = GetComponent<Animator>();
    }

    IEnumerator AttackDoorCrt()
    {
        isReady = false;
        source.Play();
        yield return new WaitForSeconds(timeToKill);
        for (var i = 0; i < checkCount; i++)
        {
            yield return new WaitForSeconds(checkDuration);
            if (!IsPlayerHolding())
            {
                animator.SetBool(OpenDoor, true);
                loseAnim.PlayLoseAnimation(handle);
            }
        }

        OnScareCompleteEvent(10);
        
        if (footstepClip)
            AudioSource.PlayClipAtPoint(footstepClip, transform.position);
        isReady = true;
    }

    private bool IsPlayerHolding()
    {
        const float epsilon = 0.01f;
        return handle.rotation.x < -epsilon;
    }

    public override void Scare()
    {
        StartCoroutine(AttackDoorCrt());
    }

    public override bool IsReady()
    {
        return isReady;
    }
}
