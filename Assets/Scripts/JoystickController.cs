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

    Vector2 parentPosition;
    Vector2 childPosition;
    
    Vector2 UnlimitedLocalPosition;

    Vector2 clamp;

    public Vector2 localPositionEnd;
    
    
    


    void Start()
    {
        transform.parent.TryGetComponent(out RectTransform parentTransform);
        Size = parentTransform.rect.size;
    }


    public void OnDrag(PointerEventData mouse){

        parentPosition = transform.parent.position;
        childPosition = mouse.position;

        UnlimitedLocalPosition = -(parentPosition - childPosition) / (2.5f);

        clamp = new Vector2(
            Mathf.Abs(UnlimitedLocalPosition.normalized.x), 
            Mathf.Abs(UnlimitedLocalPosition.normalized.y)) * (Size / 2.5f);

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
