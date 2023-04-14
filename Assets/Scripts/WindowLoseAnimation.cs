using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class WindowLoseAnimation : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] TrackedPoseDriver trackedPoseDriver;
    [SerializeField] Transform lookAtPoint;
    [SerializeField] GameObject KillerPrefab;

    [SerializeField] float rotateSpeed;
    [SerializeField] float killerSpeed;

    Quaternion startRotation;
    Quaternion targetRotation;
    bool animPlaying = false;
    GameObject killer;
    float killerMoveProgress = 0;
    float killerRotationProgress = 0;

    public void PlayLoseAnimation()
    {
        if (animPlaying)
            return;

        killer = Instantiate(KillerPrefab, lookAtPoint.position, Quaternion.identity);
        killer.transform.LookAt(playerCamera);

        trackedPoseDriver.trackingType = TrackedPoseDriver.TrackingType.PositionOnly;
        startRotation = playerCamera.rotation;
        targetRotation = Quaternion.LookRotation(lookAtPoint.transform.position - playerCamera.position);

        animPlaying = true;
    }

    private void Update()
    {
        if (animPlaying)
        {
            Debug.Log(killerRotationProgress);
            killerRotationProgress += Time.deltaTime * rotateSpeed;
            playerCamera.rotation = Quaternion.Slerp(startRotation, targetRotation, killerRotationProgress);
            

            killer.transform.position = Vector3.Lerp(lookAtPoint.position, playerCamera.position, killerMoveProgress);
            killerMoveProgress += Time.deltaTime * killerSpeed;
            killerMoveProgress = Mathf.Clamp(killerMoveProgress, 0, 0.9f);
        }
    }
}