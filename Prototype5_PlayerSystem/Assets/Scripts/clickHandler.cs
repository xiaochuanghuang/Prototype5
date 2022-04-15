using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickHandler : MonoBehaviour
{
    public Inventory _inventory;
    public void onItemClick()
    {
        ItemDrag dragHandler = gameObject.transform.Find("Image").GetComponent<ItemDrag>();
        Debug.Log(dragHandler);
        Iitems item = dragHandler.item;
       
        Debug.Log(item.Name);
        _inventory.useItem(item);


    }
}
