using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour,UseableObject
{
    ShipRoomDoor shipRoomDoor;
    Animator anim;
    public GameObject lever;
    bool leverUsed = false;
    private void Awake()
    {
        shipRoomDoor = FindObjectOfType<ShipRoomDoor>();
        anim = GetComponent<Animator>();
    }
    public void objectInteractive()
    {
        leverUsed = true;
        GameManager.Inst.MissionObject.useLever();
        anim.SetBool("Use",true);
        shipRoomDoor.OpenDoor();
    }

    public string objectName()
    {
        string name = "";
        if (!leverUsed)
        {
            name = "레버 작동";
        }
        return name;
    }

    public Sprite returnItemSprite()
    {
        return null;
    }

    public void UseItem()
    {
       
    }

}
