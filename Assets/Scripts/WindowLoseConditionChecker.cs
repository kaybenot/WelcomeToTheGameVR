using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowLoseConditionChecker : MonoBehaviour
{
    // TODO: Add monitor switch checking
    [SerializeField] LampPullSwitch lampPullSwitch;
    [SerializeField] Walker walker;

    [SerializeField] WindowLoseAnimation loseAnimation;

    private void Update()
    {
        if (lampPullSwitch.isOn && walker.progress >= 1)
        {
            loseAnimation.PlayLoseAnimation();
        }
    }
}
