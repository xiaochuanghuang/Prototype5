using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    void Start()
    {
        inventory.addedItems += inventoryAddItem;
        inventory.removeItems += inventoryRemoveItem;
    }

    private void inventoryAddItem(object sender, InventoryEventArg e)
    {
        Transform inventoryPanel = transform.Find("List");
        foreach(Transform slot in inventoryPanel)
        {
            Image i = slot.GetChild(0).GetComponent<Image>();
            ItemDrag itemDragHandler = i.transform.GetComponent<ItemDrag>();
            if(!i.enabled)
            {
                i.enabled = true;
                i.sprite = e.item.Image;
                itemDragHandler.item = e.item;
                break;
            }
        }
    }
    private void inventoryRemoveItem(object sender, InventoryEventArg e)
    {
        Transform inventoryPanel = transform.Find("List");
        foreach (Transform slot in inventoryPanel)
        {
            Image i = slot.GetChild(0).GetComponent<Image>();
            ItemDrag itemDragHandler = i.GetComponent<ItemDrag>();
            if (itemDragHandler.item.Equals(e.item))
            {
                i.enabled = false;
                i.sprite = null;
                itemDragHandler.item = null;
                break;
            }
        }
    }
}
