using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BreakeGrabDistance : MonoBehaviour
{
    [SerializeField] Transform pivot;
    [SerializeField] float breakeDistance = 0.5f;
    XRGrabInteractable interactable;
    XRInteractionManager interactManager;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactManager = FindObjectOfType<XRInteractionManager>();
    }

    void Update()
    {
        if (interactable.isHovered && Vector3.Distance(pivot.position, transform.position)> breakeDistance)
        {
            if (interactManager && interactable.firstInteractorSelecting != null) {
                interactManager.CancelInteractorSelection(interactable.firstInteractorSelecting);
            }
        }
    }
}
