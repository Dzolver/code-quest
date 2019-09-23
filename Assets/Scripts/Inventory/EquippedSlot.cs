using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquippedSlot : Slot, IPointerClickHandler
{
    public ItemType itemType;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null)
            itemDetailsDisplayRef.ShowDetails(item);

    }

    public override void SetItem(Item newItem)
    {
        if (item == null)
        {
            if (newItem.itemDetails.itemType == itemType && newItem.itemDetails.GetType().IsSubclassOf(typeof(EquippableItem)))
            {
                newItem.transform.SetParent(transform);
                newItem.transform.localPosition = Vector3.zero;

                newItem.currentSlot.item = item;
                newItem.currentSlot = this;

                item = newItem;

                ((EquippableItem)item.itemDetails).Equip();
            } else
            {
                //NOT SET
                newItem.transform.SetParent(newItem.currentSlot.transform);
                newItem.transform.localPosition = Vector3.zero;
            }
        } else
        {
            if (newItem.itemDetails.itemType == itemType && item.itemDetails.GetType().IsSubclassOf(typeof(EquippableItem)))
            {
                item.transform.SetParent(newItem.currentSlot.transform);
                item.transform.localPosition = Vector3.zero;
                item.currentSlot = newItem.currentSlot;

                newItem.transform.SetParent(transform);
                newItem.transform.localPosition = Vector3.zero;

                newItem.currentSlot.item = item;
                newItem.currentSlot = this;

                ((EquippableItem)newItem.itemDetails).Equip();
                item = newItem;
                ((EquippableItem)item.itemDetails).Equip();
            }
            else
            {
                //NOT SET
                newItem.transform.SetParent(newItem.currentSlot.transform);
                newItem.transform.localPosition = Vector3.zero;
            }
        }
    }
}