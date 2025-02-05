using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VelosityController : MonoBehaviour, IPointerUpHandler
{
    public bool buttonPressed;

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = !buttonPressed;
    }
}
