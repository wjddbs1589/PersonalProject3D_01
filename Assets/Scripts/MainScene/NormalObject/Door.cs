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
        //도어가 열려있는 상태이면
        if (doorOpen)
        {
            anim.SetTrigger("Close"); //애니메이션 변경
            doorOpen = false;         //상태 변경
        }
        else //닫혀있으면
        {
            anim.SetTrigger("Open"); //애니메이션 변경
            doorOpen = true;         //상태 변경
        }
    }
    public string objectName()
    {
        return "열기/닫기";
    }

    public bool canInteractive()
    {
        return true;
    }

    public void UseItem()
    {
        
    }
    public Sprite returnItemSprite()
    {
        return null;
    }
}
