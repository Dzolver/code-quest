using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class TestPotion : UsableItem
{
    public override void Use()
    {
        Debug.Log("USED POTION!!");
    }
}
