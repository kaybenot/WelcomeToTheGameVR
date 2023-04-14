using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] Transform StartPoint;
    [SerializeField] Transform EndPoint;
    [SerializeField] Transform Window;

    [Range(0,1)] public float progress = 0;
    public float walkingSpeed = 5;
    public bool walkingEnabled;

    private void Start()
    {
        transform.position = StartPoint.position;
        transform.LookAt(EndPoint);
    }

    private void Update()
    {
        var lookPos = Window.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);

        transform.position = Vector3.Lerp(StartPoint.position, EndPoint.position, progress);

        if (walkingEnabled)
        {
            progress += Time.deltaTime * walkingSpeed;
        }
        else
        {
            progress = 0;
        }
    }
}
