using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour, Iitems
{
    public string Name
    {
        get
        {
            return "Cherry";
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
