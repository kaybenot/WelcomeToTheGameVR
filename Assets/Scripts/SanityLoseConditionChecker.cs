using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityLoseConditionChecker : MonoBehaviour
{
    [SerializeField] WindowLoseAnimation loseAnimation;
    [SerializeField] LampPullSwitch lampPullSwitch;
    [SerializeField] float sanityLoseSpeed;
    [SerializeField] float sanityGainSpeed;

    [SerializeField] List<GameObject> ghosts;

    [Range(0, 1)] public float sanityLeft = 1;

    private void Update()
    {
        if (!lampPullSwitch.isOn)
        {
            sanityLeft -= Time.deltaTime * sanityLoseSpeed;
        }
        else
        {
            sanityLeft += Time.deltaTime * sanityGainSpeed;
        }
        sanityLeft = Mathf.Clamp01(sanityLeft);

        if (sanityLeft <= 0)
        {
            loseAnimation.PlayLoseAnimation();
        }

        int limit = (int)(ghosts.Count * (1 - sanityLeft));

        for (int i = 0; i < ghosts.Count; i++)
        {
            if (i < limit)
                ghosts[i].SetActive(true);
            else
                ghosts[i].SetActive(false);
        }
    }
}
