using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerDownHandler {

    public bool buttonPressed;

    public void OnPointerDown(PointerEventData eventData){
        buttonPressed = !buttonPressed;
    }
}
