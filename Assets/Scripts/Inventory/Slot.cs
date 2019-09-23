using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Slot : MonoBehaviour
{
    public ShowItemDetails itemDetailsDisplayRef;

    public Item item;

    public Image backgroundImage;

    public abstract void SetItem(Item item);

    public void UseItem()
    {
        ((UsableItem)item.itemDetails).Use();

        if (item.itemDetails.isStackable)
        {
            if (item.itemCount < 2)
            {
                itemDetailsDisplayRef.HideItemDetails();
                item.currentSlot = null;
                Destroy(item.gameObject);
                item = null;
            }
            else
            {
                item.itemCount--;
                item.itemCountText.text = "" + item.itemCount;
            }
        }
        else
        {
            item.currentSlot = null;
            item = null;
            Destroy(item);
        }
    }
}