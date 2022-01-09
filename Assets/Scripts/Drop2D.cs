using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class Drop2D : MonoBehaviour , IDropHandler {

    public DraggingBox dargbox;
    public int slotId;
    public void OnDrop(PointerEventData eventData)
    {
        //Snap Around
        
        GameObject newCandy = Instantiate(eventData.pointerDrag.gameObject , transform, true);
        newCandy.transform.position = transform.position ;

        dargbox.SetID(slotId, eventData.pointerDrag.GetComponent<Drag2D>().candyId);
        
    }


}
