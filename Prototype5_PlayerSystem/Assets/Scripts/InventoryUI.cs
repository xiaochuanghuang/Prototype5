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
    }

    private void inventoryAddItem(object sender, InventoryEventArg e)
    {
        Transform inventoryPanel = transform.Find("List");
        foreach(Transform slot in inventoryPanel)
        {
            Image i = slot.GetChild(0).GetComponent<Image>();
            if(!i.enabled)
            {
                i.enabled = true;
                i.sprite = e.item.Image;
                break;
            }
        }
    }
}
