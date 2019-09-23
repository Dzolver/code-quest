using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Item class contains method onequip, and other image etc info
//item ui just contains a ref to the item. 

//ref to prefab should be contained
/***
 * ref to prefab containing equip method, sprite info etc should also be contained.
 ***/
public class Item : MonoBehaviour
{
    public Image image;
    public Text itemCountText;

    public int itemCount;
    public ItemDetails itemDetails;

    public Slot currentSlot;

    public void SetItem(ItemDetails item, int count = 1)
    {
        image.sprite = item.itemImage;
        image.SetNativeSize();
        GetComponent<RectTransform>().localScale = new Vector2(1, 1);

        if (item.isStackable)
        {
            itemCount = count;
            itemCountText.text = "" + count;
            itemCountText.color = Color.black;
        }
        else
        {
            itemCount = count;
            itemCountText.color = new Color(0, 0, 0, 0);
            itemCountText.text = "";
        }

        Debug.Log(item.itemType);
        this.itemDetails = item;
        Debug.Log(this.itemDetails.itemType);
    }

    public void SetItemCount(int count)
    {
        itemCount = count;
        itemCountText.text = "" + count;
    }

    public void IncrementItemCount()
    {
        itemCount++;
        itemCountText.text = "" + itemCount;
    }

    public void DecrementItemCount()
    {
        itemCount--;
        itemCountText.text = "" + itemCount;
    }
}
