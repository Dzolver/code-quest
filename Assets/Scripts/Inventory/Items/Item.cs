using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public bool isStackable;
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public ItemType itemType;

    public abstract void OnEquip();
}

