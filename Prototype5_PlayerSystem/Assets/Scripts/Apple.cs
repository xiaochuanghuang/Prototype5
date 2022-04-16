using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour, Iitems
{
    public string Name
    {
        get
        {
            return "Apple";
        }
    }


    public Sprite s;
    Sprite Iitems.Image
    {
        get
        {
            return s;
        }
    }

    public void OnPickUP()
    {
        gameObject.SetActive(false);
    }

    public void onUsed()
    {
        this.onUsed();
    }
}
