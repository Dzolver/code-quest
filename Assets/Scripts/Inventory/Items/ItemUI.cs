using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image image;
    public Text itemCount;
    public void SetItem(Item item, int count = 1)
    {
        //item UI could be attached to the slot? then what will 
        image.sprite = item.itemImage;
        image.SetNativeSize();
        GetComponent<RectTransform>().localScale = new Vector2(1, 1);

        if (item.isStackable)
        {
            itemCount.text = ""+count;
            itemCount.color = Color.black;
        } else
        {
            itemCount.color = new Color(0, 0, 0, 0);
        }
    }

    public void SetItemCount(int count)
    {
        itemCount.text = "" + count;
    }
}
