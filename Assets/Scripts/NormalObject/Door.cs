using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, UseableObject
{
    Animator anim;
    bool doorOpen = false;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void objectIneractive()
    {
        if (doorOpen)
        {
            anim.SetTrigger("Close");
            doorOpen = false;
        }
        else
        {
            anim.SetTrigger("Open");
            doorOpen = true;
        }
    }
    public string objectName()
    {
        return "열기/닫기";
    }

    public bool canInteractive()
    {
        bool result = true;
        return result;
    }

    public void UseItem()
    {
        
    }
    public Sprite returnItemSprite()
    {
        return null;
    }
}
