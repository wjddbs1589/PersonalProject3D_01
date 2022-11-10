using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour,UseableObject
{
    ShipRoomDoor shipRoomDoor;
    public GameObject lever;
    bool leverUsed = false;
    private void Awake()
    {
        shipRoomDoor = FindObjectOfType<ShipRoomDoor>();
    }
    public void objectIneractive()
    {
        leverUsed = true;        
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
