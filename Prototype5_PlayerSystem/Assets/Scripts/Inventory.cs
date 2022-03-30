using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    private List<Items> itemList;

    public Inventory()
    {
        itemList = new List<Items>();
        addItem(new Items { itemType = Items.itemTypes.Apple, amount = 1 });
        Debug.Log(itemList.Count);
    }

    public void addItem(Items item)
    {
        itemList.Add(item);
    }
}
