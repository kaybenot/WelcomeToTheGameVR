using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFusesPosition : MonoBehaviour
{
    [SerializeField] GameObject fusesThing;
    Transform fusesPosition;

    public bool isOn = true;


    private void Start()
    {
        fusesPosition = fusesThing.transform;      
    }

    public void ChangeMode()
    {
        if (isOn)
        {
            FusesOff();
        }
        else
        {
            FusesOn();
        }
    }
    public void FusesOn()
    {
        isOn = true;
        fusesThing.transform.position = fusesPosition.position;
        fusesThing.transform.rotation = Quaternion.Euler(0,-90,0);
    }

    public void FusesOff()
    {
        isOn = false;
        fusesThing.transform.position = fusesPosition.position;
        fusesThing.transform.rotation = Quaternion.Euler(0, -90, -130f);
    }
}
