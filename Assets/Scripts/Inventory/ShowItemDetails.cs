using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowItemDetails : MonoBehaviour
{
    public Text itemName;
    public Text itemDescription;
    public Text itemType;
    public Image itemImage;
    public void ShowDetails(Item item)
    {
        itemName.text = item.itemName;
        itemImage.sprite = item.itemImage;
        itemDescription.text = item.itemDescription;
        itemType.text = itemType.text;
    }
}
