using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JumpscareManager : MonoBehaviour
{
    [SerializeField] List<JumpscareConfiguration> jumpscares;
    bool isReadyForNextJumpscare = true;

    IEnumerator Start()
    {
        foreach(var jumpscare in jumpscares)
            jumpscare.jumpscareProvider.ScareCompleteEvent += SetReadyForNextJumpscare;
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (!isReadyForNextJumpscare || !ShouldLaunchJumpscareThisSecond())
                continue;
            var jumpscare = SelectJumpscare();
            if (jumpscare != null)
            {
                isReadyForNextJumpscare = false;
                jumpscare.Scare();
            }
        }

    }

    private bool ShouldLaunchJumpscareThisSecond()
    {
        return true; //todo: less jumpscares when score is low
    }

    private JumpscareProvider SelectJumpscare()
    {
        var possibleJumpscares = jumpscares.Where(j => j.jumpscareProvider.IsReady());
        if (!possibleJumpscares.Any())
            return null;
        var probabilitiesSum = possibleJumpscares.Sum(j => j.probability01);
        var random = UnityEngine.Random.Range(0f, probabilitiesSum);
        foreach(var jumpscare in possibleJumpscares)
        {
            random -= jumpscare.probability01;
            if (random <= 0)
                return jumpscare.jumpscareProvider;
        }
        throw new Exception("Entliczek pentliczek zawiódł :o");
    }



    private void SetReadyForNextJumpscare(float delay)
    {
        Invoke("SetReadyForNextJumpscare", delay);
    }

    void SetReadyForNextJumpscare()
    {
        isReadyForNextJumpscare = true;
    }
}

[System.Serializable] public class JumpscareConfiguration
{
    public JumpscareProvider jumpscareProvider;
    public float probability01;
}
