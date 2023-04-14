using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuseBox : MonoBehaviour
{
    [SerializeField] UnityEvent OnFuseButtonPressed;

    public void FuseButtonPressed()
    {
        OnFuseButtonPressed?.Invoke();
    }
}
