using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface Iitems
{
    string Name { get; }
     Sprite Image { get; }

     void OnPickUP();
}
public class InventoryEventArg : EventArgs
{
    public Iitems item;
    public InventoryEventArg(Iitems item)
    {
        this.item = item;
    }
    
}
