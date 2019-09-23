using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Axe : EquippableItem
{
    public override void Equip()
    {
        Debug.Log("EQUIPPED AXE");
    }

    public override void Unequip()
    {
        Debug.Log("UNEQUIPPED AXE");
    }
}


