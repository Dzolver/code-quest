using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryDragAndDropHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static Item itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;

    public Transform potentialPoint;

    private void Start()
    {
        potentialPoint = transform.parent;
        startParent = transform.parent;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = GetComponent<Item>();
        startParent = transform.parent;
        startPosition = startParent.position;

        transform.SetParent(transform.parent.parent.parent);
        transform.SetAsLastSibling();
        GetComponent<Image>().raycastTarget = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //GraphicRaycaster raycaster = n();

        //RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, new Vector3(0, 1,0));
        RaycastHit2D[] hits = Physics2D.LinecastAll(Input.mousePosition, Input.mousePosition - new Vector3(0, 0, 100));

        bool notDraggedToSlot = true;
        if (hits != null)
        {
            foreach (RaycastHit2D hit in hits)
            {

                Slot newSlot = hit.collider.gameObject.GetComponent<Slot>();
                if (newSlot)
                {
                    if (newSlot.GetType() == typeof(EquippedSlot))
                    {
                        //if 
                        if (((EquippedSlot)newSlot).itemType == GetComponent<Item>().itemDetails.itemType)
                        {
                            hit.collider.gameObject.GetComponent<Slot>().SetItem(GetComponent<Item>());
                        }
                        else
                        {
                            transform.parent = (GetComponent<Item>().currentSlot.transform);
                            transform.localPosition = Vector3.zero;
                        }

                    } else 
                        hit.collider.gameObject.GetComponent<Slot>().SetItem(GetComponent<Item>());

                    notDraggedToSlot = false;
                    break;
                }
            }
        }

        if (notDraggedToSlot)
        {
            transform.parent = (GetComponent<Item>().currentSlot.transform);
            transform.localPosition = Vector3.zero;
        }

    }

    private void Update()
    {
        Debug.DrawRay(GetWorldPositionOnPlane(Input.mousePosition, 0), new Vector3(0, 1, 0), Color.red);
        Debug.DrawLine(Input.mousePosition, new Vector3(0, 1, 0), Color.red);
        Debug.DrawRay(Vector3.zero, new Vector2(1, 1), Color.red);

    }

    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
