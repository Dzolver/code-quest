using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public int itemCount;

    public Item item;

    public ItemUI itemUI;

    public void OnDrop(PointerEventData eventData)
    {
        //if item contains other
        if (item == null)
        {
            InventoryDragAndDropHandler.itemBeingDragged.transform.SetParent(transform);
            itemCount = InventoryDragAndDropHandler.itemBeingDragged.transform.parent.GetComponent<Slot>().itemCount;
        }
        else
        {
            //Setting item02 slot as slot 01
            transform.GetChild(0).SetParent(InventoryDragAndDropHandler.itemBeingDragged.transform.parent);
            //Setting item01s parent as this slot 02
            InventoryDragAndDropHandler.itemBeingDragged.transform.SetParent(transform);

            //swapping the item counts
            int slotOneItemCount = InventoryDragAndDropHandler.itemBeingDragged.GetComponentInParent<Slot>().itemCount;

            InventoryDragAndDropHandler.itemBeingDragged.GetComponentInParent<Slot>().itemCount = itemCount;
            itemCount = slotOneItemCount;
        }
    }

}

public enum ItemType
{
    WEAPON,
    ARMOR,
    POTION
}