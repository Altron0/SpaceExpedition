using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// движение контроллера внутри джостика
/// </summary>
public class JoystickController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector2 Size;

    Vector2 myPosition;

    Vector2 UnlimitedLocalPosition;

    Vector2 clamp;

    Transform handle;

    public Vector2 localPositionEnd;


    void Start(){
        transform.TryGetComponent(out RectTransform parentTransform);
        Size = parentTransform.rect.size;
        handle = transform.GetChild(0);
    }


    public void OnDrag(PointerEventData mouse){

        myPosition = transform.position;
        UnlimitedLocalPosition = (myPosition - mouse.position) / (-2.25f);

        clamp = new Vector2(
            Mathf.Abs(UnlimitedLocalPosition.normalized.x), 
            Mathf.Abs(UnlimitedLocalPosition.normalized.y)) * (Size / 2);

        localPositionEnd = new Vector2(
            Mathf.Clamp(UnlimitedLocalPosition.x, -clamp.x, clamp.x),
            Mathf.Clamp(UnlimitedLocalPosition.y, -clamp.y, clamp.y)
            );

        handle.localPosition = localPositionEnd;
    }


    public void OnEndDrag(PointerEventData mouse){

        handle.localPosition = Vector3.zero;
        localPositionEnd = Vector3.zero;
    }
}
