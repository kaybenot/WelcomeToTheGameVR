using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonCursorDetector : MonoBehaviour, IPointerEnterHandler
{
    public string text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        text = "Kursor wchodzi na: " + eventData.pointerCurrentRaycast.gameObject.name;
    }
}