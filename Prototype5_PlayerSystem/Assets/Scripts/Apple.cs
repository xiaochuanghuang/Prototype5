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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
