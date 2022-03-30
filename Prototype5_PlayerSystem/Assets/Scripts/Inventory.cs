using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private const int Slots = 6;
    private List<Iitems> itemInstance = new List<Iitems>();
    public event EventHandler<InventoryEventArg> addedItems;

    public void addItem(Iitems item)
    {
      if(itemInstance.Count < Slots)
        {
            Collider collide = (item as MonoBehaviour).GetComponent<Collider>();
            if(collide.enabled)
            {
                collide.enabled = false;
                itemInstance.Add(item);
                Debug.Log(item);
                item.OnPickUP();
                if (addedItems != null)
                {
                    addedItems(this, new InventoryEventArg(item));
                }
            }
           
        }
    }
}
