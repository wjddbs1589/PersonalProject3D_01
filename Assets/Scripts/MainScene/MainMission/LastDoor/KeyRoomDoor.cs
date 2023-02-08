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
    // 수리된 배터리 갯수가 증가할때 마다 실행
    private void CheckBattery(int count)
    {
        // 배터리가 전부 수리 되었으면
        if(batteryCount == count)
        {
            canOpenDoor = true; //문 잠금 해제
        }
    }

    //문 열기 상호작용
    public void objectInteractive()
    {
        //문의 잠금상태가 풀렸을 때
        if (canOpenDoor)
        {
            //문이 열려 있을 때
            if (checkDoorOpen)
            {
                anim.SetTrigger("Close"); 
                checkDoorOpen = false;
            }
            else
            {
                anim.SetTrigger("Open");
                checkDoorOpen = true;
            }
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
            return "전력 부족";
        }
    }
    public void UseItem()
    {
      // 해당사항 없음   
    }
    public Sprite returnItemSprite()
    {
        return null;
    }
}
