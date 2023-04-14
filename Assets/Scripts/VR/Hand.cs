using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class Hand : MonoBehaviour
{
    public UnityEvent<float> OnGrip;

    [SerializeField] private ActionBasedController controller;
    
    private Animator animator;
    private static readonly int Grip = Animator.StringToHash("Grip");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var grip = controller.selectAction.action.ReadValue<float>();
        if (grip != 0f)
        {
            OnGrip?.Invoke(grip);
            
            if (grip >= 0.5f) // TODO: Smooth grip
                animator.SetBool(Grip, true);
            else
                animator.SetBool(Grip, false);
        }
        else
            animator.SetBool(Grip, false);
    }
}
