using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandHide : MonoBehaviour
{
    [SerializeField] private GameObject hand;

    public void OnSelectEnter(SelectEnterEventArgs args)
    {
        hand.SetActive(false);
    }

    public void OnSelectExit(SelectExitEventArgs args)
    {
        hand.SetActive(true);
    }
}
