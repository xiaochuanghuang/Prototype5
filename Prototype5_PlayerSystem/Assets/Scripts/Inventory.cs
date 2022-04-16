using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private const int Slots = 6;
    private List<Iitems> itemInstance = new List<Iitems>();
    public event EventHandler<InventoryEventArg> addedItems;
    public event EventHandler<InventoryEventArg> removeItems;
    //public event EventHandler<InventoryEventArg> useItems;
    public void addItem(Iitems item)
    {
      if(itemInstance.Count < Slots)
        {
            Collider collide = (item as MonoBehaviour).GetComponent<Collider>();
            if(collide.enabled)
            {
                collide.enabled = false;
                itemInstance.Add(item);
                item.OnPickUP();
                if (addedItems != null)
                {
                    addedItems(this, new InventoryEventArg(item));
                }
            }
           
        }
    }
    public void removeItem(Iitems item)
    {
        if(itemInstance.Contains(item))
        {
            itemInstance.Remove(item);
        }

        if(removeItems != null)
        {
            removeItems(this, new InventoryEventArg(item));
        }
    }
    public void useItem(Iitems item)
    {
        if (removeItems != null)
        {
            removeItems(this, new InventoryEventArg(item));
        }
    }
}
