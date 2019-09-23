using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UnequippedSlot : Slot, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null)
            itemDetailsDisplayRef.ShowDetails(item);
    }

    public override void SetItem(Item newItem)
    {

        if (item == null)
        {
            //itemUI.currentSlot.item = null;

            item = newItem;
            newItem.transform.SetParent(transform);
            newItem.transform.position = transform.position;

            Slot previousSlot = null;
            if (newItem.currentSlot != null)
                previousSlot = newItem.currentSlot;
            

            newItem.currentSlot = this;

            if (previousSlot)
                previousSlot.item = null;

            if (newItem.itemDetails.GetType().IsSubclassOf(typeof(EquippableItem))){
                ((EquippableItem)newItem.itemDetails).Unequip();
            }
        } else
        {
            if (newItem.currentSlot.GetType() == typeof(UnequippedSlot))
            {
                //Set current items parent to the other slot
                //set current items position to zero
                //set current items slot ref to other slot
                //set other slots current item ref to current item

                //set new item uis parent to this slot
                //set new item uis position to zero
                //set new items slot ref to new item
                //set this slots current item ref to newItem

                item.transform.SetParent(newItem.currentSlot.transform);
                item.transform.localPosition = Vector3.zero;
                item.currentSlot = newItem.currentSlot;

                newItem.transform.SetParent(transform);
                newItem.transform.localPosition = Vector3.zero;

                newItem.currentSlot.item = item;
                newItem.currentSlot = this;

                item = newItem;
            }
            else
            {
                if (item.itemDetails.itemType == newItem.itemDetails.itemType && item.itemDetails.GetType().IsSubclassOf(typeof(EquippableItem)))
                {
                    Debug.Log("Item type " + item.name +" == "+newItem.name);

                    item.transform.SetParent(newItem.currentSlot.transform);
                    item.transform.localPosition = Vector3.zero;
                    item.currentSlot = newItem.currentSlot;

                    newItem.transform.SetParent(transform);
                    newItem.transform.localPosition = Vector3.zero;

                    newItem.currentSlot.item = item;
                    newItem.currentSlot = this;

                    ((EquippableItem)item.itemDetails).Equip();
                    item = newItem;
                    ((EquippableItem)item.itemDetails).Unequip();
                }
                else
                {
                    newItem.transform.SetParent(newItem.currentSlot.transform);
                    newItem.transform.localPosition = Vector3.zero;
                }
            }
        }
    }
}



public enum ItemType
{
    HEADWEAR,
    NECKLACE,
    SECONDARY,
    MAIN,
    ARMOR,
    BOOTS,
    CAPE,
    MISC
}