using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryDragAndDropHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startParent = transform.parent;
        startPosition = startParent.position;

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //determining item dropped into new slot 
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }

        Debug.Log("Ended");
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

}
