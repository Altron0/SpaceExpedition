using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector2 Size;
    Vector2 parentPosition;
    Vector2 UnlimitedLocalPosition;
    Vector2 clamp;
    public Vector2 localPositionEnd;


    public void Awoke(){
        transform.parent.TryGetComponent(out RectTransform parentTransform);
        Size = parentTransform.rect.size;
        Debug.Log("Playground Active!");
    }
    
    public void OnDrag(PointerEventData mouse){

        parentPosition = transform.parent.position;
        UnlimitedLocalPosition = (parentPosition - mouse.position) / (-2.25f);

        Awoke();

        clamp = new Vector2(
            Mathf.Abs(UnlimitedLocalPosition.normalized.x), 
            Mathf.Abs(UnlimitedLocalPosition.normalized.y)) * (Size / 2);

        localPositionEnd = new Vector2(
            Mathf.Clamp(UnlimitedLocalPosition.x, -clamp.x, clamp.x),
            Mathf.Clamp(UnlimitedLocalPosition.y, -clamp.y, clamp.y)
            );

        transform.localPosition = localPositionEnd;
        
    }

    public void OnEndDrag(PointerEventData mouse){

        transform.localPosition = Vector3.zero;
        localPositionEnd = Vector3.zero;
    }
}