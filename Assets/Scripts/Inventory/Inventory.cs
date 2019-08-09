using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool inventoryEnabled;
    public GameObject inventory;

    private int allSlots;
    private Slot[] slots;
    private List<Slot> freeSlots;

    public GameObject slotHolder;
    public GameObject equippedSlotHolder;

    public ItemUI itemUIPrefab;
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
        slots = new Slot[allSlots];

        slots = slotHolder.GetComponentsInChildren<Slot>();
        freeSlots = new List<Slot>(slots);

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
    
    public void SwapItems(Item SlotOne, Slot SlotTwo)
    {
        RectTransform invPanel = transform as RectTransform;

    }

    public void AddItem(Item item)
    {
        if (freeSlots.Count > 0)
        {
            foreach (Slot slot in slots)
            {
                if (slot.item == null)
                {
                    ItemUI newItemUI = Instantiate(itemUIPrefab);
                    newItemUI.transform.position = slot.transform.position;
                    newItemUI.transform.parent = slot.transform;
                    newItemUI.SetItem(item);
                    slot.itemUI = newItemUI;
                    slot.item = item;
                    slot.itemCount = 1;
                    Debug.Log("Added Item");
                    freeSlots.Remove(slot);
                    return;
                } //if item is already contained
                else if (slot.item == item && item.isStackable)
                {
                    slot.itemCount++;
                    slot.itemUI.SetItemCount(slot.itemCount);
                    Debug.Log("Incremented Item" + slot.itemCount);
                    freeSlots.Remove(slot);
                    return;
                    //item UI is attached to slot, how will the dragging work?

                    //itemUI UI is spawned with a game object, slot maintains a reference to the item and the item UI.
                    //when dragged and dropped how will the swapping occur? Actually swap
                }
            }
        }
        Debug.Log("Didnt Add Item");
    }
}

public class EquippedSlot
{
    public ItemType equipItemType;

    public Item item;

    //what about items that 
}