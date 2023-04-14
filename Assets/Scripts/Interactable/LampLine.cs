using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLine : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer.SetPosition(0,this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(1, obj.transform.position);
    }
}
