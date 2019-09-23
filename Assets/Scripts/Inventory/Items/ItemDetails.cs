using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ItemDetails : ScriptableObject
{
    [SerializeField]
    public bool isStackable;
    [SerializeField]
    public string itemName;
    [SerializeField]
    public string itemDescription;
    [SerializeField]
    public Sprite itemImage;
    [SerializeField]
    public ItemType itemType;
}


public abstract class EquippableItem : ItemDetails
{
    public abstract void Equip();
    public abstract void Unequip();
}

public abstract class UsableItem : ItemDetails
{
    public abstract void Use();
}
