using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//How will the hovering work, Hover above the 
public class ShowItemDetails : MonoBehaviour
{
    public Text itemName;
    public Text itemDescription;
    public Text itemType;
    public Image itemImage;

    public Button useButton;
    public Button exitButton;

    public RectTransform containerPanel;
    public RectTransform rectTransform;

    public Vector3 offset;
    public Vector3 flippedOffset;

    public Animator animator;

    public Item currentItem;
    public RectTransform currentItemRectTransform;
    private void Start()
    {
        //animator = GetComponentInChildren<Animator>();
        rectTransform.parent.gameObject.SetActive(false);
        Debug.Log("Deactivated");
    }
    public void ShowDetails(Item item)
    {
        rectTransform.parent.gameObject.SetActive(true);
        rectTransform.gameObject.SetActive(true);

        //handling toggle if clicked twice, if so hide and skip the rest of the method
        if (currentItem && currentItem == item)
        {
            HideItemDetails();
            return;
        }

        //Setting up item details
        currentItem = item;
        currentItemRectTransform = item.GetComponent<RectTransform>();
        itemName.text = item.itemDetails.itemName;
        itemImage.sprite = item.itemDetails.itemImage;
        itemDescription.text = item.itemDetails.itemDescription;
        itemType.text = itemType.text;

        useButton.onClick.RemoveAllListeners();
        if (item.itemDetails.GetType().IsSubclassOf(typeof(UsableItem)))
        {
            useButton.gameObject.SetActive(true);
            useButton.onClick.AddListener(item.currentSlot.UseItem);
        }
        else
        {
            useButton.gameObject.SetActive(false);
        }


        //Finding the correct position for the item details
        Vector3 flippedOffset = Vector3.zero;
        if (currentItemRectTransform.position.x / Screen.width < 0.5)
        {
            flippedOffset = this.flippedOffset;
        }
        rectTransform.parent.position = currentItem.transform.position + (flippedOffset + offset) * Screen.width / 1080;

        Vector3[] itemDetailsCorners = new Vector3[4];
        rectTransform.GetWorldCorners(itemDetailsCorners);

        Vector3[] containerPanelCorners = new Vector3[4];
        containerPanel.GetWorldCorners(containerPanelCorners);

        if (itemDetailsCorners[0].y < containerPanelCorners[0].y)
        {
            rectTransform.parent.position += new Vector3(0, containerPanelCorners[0].y - itemDetailsCorners[0].y, 0);
        } else if (itemDetailsCorners[1].y > containerPanelCorners[1].y)
        {
            rectTransform.parent.position -= new Vector3(0, itemDetailsCorners[1].y - containerPanelCorners[1].y, 0);
        }


        animator.SetTrigger("Show Details");
    }

    public void HideItemDetails()
    {
        currentItem = null;
        currentItemRectTransform = null;
        animator.SetTrigger("Hide Details");
    }

    public void Update()
    {
        //Finding the correct position for the item details panel if panel is active
        if (currentItem)
        {
            Vector3 flippedOffset = Vector3.zero;
            if (currentItemRectTransform.position.x/Screen.width < 0.5)
            {
                flippedOffset = this.flippedOffset;
            }

            rectTransform.parent.position = currentItem.transform.position + (flippedOffset + offset) * Screen.width / 1080;

            //get the bottom corner, if the bottom corner y is negative, push the position up by the screen pos
            Vector3[] itemDetailsCorners = new Vector3[4];
            rectTransform.GetWorldCorners(itemDetailsCorners);

            Vector3[] containerPanelCorners = new Vector3[4];
            containerPanel.GetWorldCorners(containerPanelCorners);

            if (itemDetailsCorners[0].y < containerPanelCorners[0].y)
            {
                rectTransform.parent.position += new Vector3(0, containerPanelCorners[0].y - itemDetailsCorners[0].y, 0);
            }
            else if (itemDetailsCorners[1].y > containerPanelCorners[1].y)
            {
                rectTransform.parent.position -= new Vector3(0, itemDetailsCorners[1].y - containerPanelCorners[1].y, 0);
            }
        }

    }

    
}
