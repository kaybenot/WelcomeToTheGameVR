using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuseBox : MonoBehaviour
{
    [SerializeField] UnityEvent OnFuseButtonPressed;
    [SerializeField] SetFusesPosition fusesPosition;
    public void FuseButtonPressed()
    {
        if (fusesPosition.isOn)
        {
            OnFuseButtonPressed?.Invoke();
        }
    }
}
