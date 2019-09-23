using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool inventoryEnabled;
    public GameObject inventory;

    private int allSlots;
    private UnequippedSlot[] slots;
    private List<UnequippedSlot> freeSlots;

    public GameObject slotHolder;
    public GameObject equippedSlotHolder;

    public Item itemPrefab;
    //contains reference to the equipped slots
        
    public static Inventory Instance { get; private set; }
    //how to get a reference to what needs to be spawned?
    //item variable contains game object that should be attached to player

    //inventory is attached to the player, the player contains game objects attached to this object

    public bool recieveInput;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        allSlots = slotHolder.transform.childCount;
        slots = new UnequippedSlot[allSlots];

        slots = slotHolder.GetComponentsInChildren<UnequippedSlot>();
        freeSlots = new List<UnequippedSlot>(slots);

        // Keep inventory minimised on Start
        inventoryEnabled = false;
        inventory.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (recieveInput && Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;

            if (inventoryEnabled)
            {
                inventory.SetActive(true);
            } else
            {
                inventory.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {

        }
    }



    public void AddItem(ItemDetails item)
    {
        //item type is unequipped item
        bool foundFreeSlot = false;
        if (item.isStackable)
        {
            foreach (UnequippedSlot slot in slots)
            {
                if (slot.item != null)
                {
                    if (slot.item.itemDetails == item && item.isStackable)
                    {
                        slot.item.IncrementItemCount();
                        freeSlots.Remove(slot);
                        foundFreeSlot = true;
                        return;
                    }
                }
            }
        }
        if (freeSlots.Count > 0 && !foundFreeSlot)
        {
            foreach (UnequippedSlot slot in slots)
            {
                if (slot.item == null)
                {

                    Item newItem = Instantiate(itemPrefab);
                    newItem.transform.position = slot.transform.position;
                    newItem.transform.parent = slot.transform;
                    slot.item = newItem;

                    slot.item.SetItem(item);

                    Debug.Log("Sticks? " + slot.item.itemDetails.itemType + newItem.itemDetails.itemType);
                    Debug.Log("Sticks? " + slot.item.GetHashCode() + " = " + newItem.itemDetails.GetHashCode());


                    newItem.currentSlot = slot;
                    freeSlots.Remove(slot);
                    return;
                }
            }
        }
        Debug.Log("Didnt Add Item");
    }
}

