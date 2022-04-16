using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lemon : MonoBehaviour, Iitems
{
    public string Name
    {
        get
        {
            return "Lemon";
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
