using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, UseableObject
{
    Animator anim;
    bool canOpenDoor = true;
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
    public bool directUseable()
    {
        if (canOpenDoor)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string objectName()
    { 
        if (canOpenDoor)
        {
            return "열기/닫기";
        }
        else
        {
            return "열기/닫기\n잠겨있음";
        }
    }
}
