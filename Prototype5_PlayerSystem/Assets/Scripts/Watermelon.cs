using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : MonoBehaviour,Iitems
{
    // Start is called before the first frame update
    public string Name
    {
        get
        {
            return "Watermelon";
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
