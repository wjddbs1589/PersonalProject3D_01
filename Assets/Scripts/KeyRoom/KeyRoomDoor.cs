using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyRoomDoor : MonoBehaviour, UseableObject
{
    Animator anim;
    bool checkDoorOpen = false; // 문이 열려있는 상태 확인
    bool canOpenDoor = false;   // 문을 열수 있는지 확인
    int batteryCount = 4;
    KeyRoomBattery allOfBattery;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        allOfBattery = GameManager.Inst.KeyRoomBattery;
        allOfBattery.OnBattery += CheckBattery;
    }
    // 배터리 갯수가 증가할때 마다 실행, 4개를 다 채우면 문 열림
    private void CheckBattery(int count)
    {
        if(batteryCount == count)
        {
            canOpenDoor = true;
        }
    }

    public void objectIneractive()
    {
        if (canInteractive()) //문을 열수 있는 상태일때
        {
            if (checkDoorOpen) //문이 열려있을 때
            {
                anim.SetTrigger("Close");
                checkDoorOpen = false;
            }
            else  //문이 닫혀있을 때
            {
                anim.SetTrigger("Open");
                checkDoorOpen = true;
            }
        }
    }
    //바로 사용하는 오브젝트인지 확인
    public bool immediatelyUseable() 
    {
        return true;
    }

    public string objectName()
    { 
        if (canOpenDoor)
        {
            return "열기/닫기";
        }
        else
        {
            return "전력 부족";
        }
    }

    public bool canInteractive()
    {
        bool result = false;
        if (canOpenDoor)
        {
            result = true;
        }
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
