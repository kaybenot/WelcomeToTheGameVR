using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JumpscareProvider : MonoBehaviour
{
    public event System.Action<float> ScareCompleteEvent;
    public abstract void Scare();
    public void OnScareCompleteEvent(float waitTime)
    {
        ScareCompleteEvent?.Invoke(waitTime);
    }

    public abstract bool IsReady();
}
