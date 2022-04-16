using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickHandler : MonoBehaviour
{
    public Inventory _inventory;
    public Move player;
    public void onItemClick()
    {
        //player = FindObjectOfType<Move>();
        ItemDrag dragHandler = gameObject.transform.Find("Image").GetComponent<ItemDrag>();
        Debug.Log(dragHandler);
        Iitems item = dragHandler.item;
       
        Debug.Log(item.Name);

        //item.onUsed();
        _inventory.useItem(item);
        if(item.Name == "Apple")
        {
            player.playerHealth += 10f;
        }

    }
}
