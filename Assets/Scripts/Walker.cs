using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public enum State
    {
        WalkingIn,
        LookingAtWindow,
        WalkingOut
    }

    [SerializeField] Transform StartPoint;
    [SerializeField] Transform WindowPoint;
    [SerializeField] Transform EndPoint;
    [SerializeField] Transform Window;

    public State currentState;

    [Range(0, 1)] public float walkingInProgress = 0;
    [Range(0, 1)] public float walkingOutProgress = 0;
    [Range(0, 1)] public float lookingProgress = 0;
    public float walkingSpeed = 5;
    public bool walkingEnabled;
    public float lookingTime = 2;

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        if (currentState == State.WalkingIn)
        {
            var lookPos = Window.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);
            transform.position = Vector3.Lerp(StartPoint.position, WindowPoint.position, walkingInProgress);

            if (walkingEnabled)
            {
                walkingInProgress += Time.deltaTime * walkingSpeed;
            }

            if (walkingInProgress >= 1)
            {
                currentState = State.LookingAtWindow;
            }
        }
        else if (currentState == State.LookingAtWindow)
        {
            lookingProgress += Time.deltaTime;

            if (lookingProgress >= lookingTime)
            {
                currentState = State.WalkingOut;
            }
        }
        else if (currentState == State.WalkingOut)
        {
            walkingOutProgress += Time.deltaTime * walkingSpeed;

            var lookPos = EndPoint.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);
            transform.position = Vector3.Lerp(WindowPoint.position, EndPoint.position, walkingOutProgress);

            if (walkingOutProgress >= 1)
            {
                Reset();
            }
        }
    }

    private void Reset()
    {
        currentState = State.WalkingIn;
        walkingInProgress = 0;
        walkingOutProgress = 0;
        lookingProgress = 0;
        transform.position = StartPoint.position;
        transform.LookAt(EndPoint);
    }
}
