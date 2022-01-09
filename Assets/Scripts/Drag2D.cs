using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class Drag2D : MonoBehaviour , IBeginDragHandler , IDragHandler , IEndDragHandler {
   
    Vector3 oldPosition;
    public int candyId;
    public void OnBeginDrag(PointerEventData eventData)
    {
        oldPosition = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
         transform.position = oldPosition;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }




 
}
