using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour, UseableObject
{
    Light GeneratorLight;
    bool Fixed = false;
    ItemManager ItemManager;
    PlayerInventory inventory;
    private void Awake()
    {
        GeneratorLight = transform.GetComponentInChildren<Light>();
        
    }
    private void Start()
    {
        ItemManager = GameManager.Inst.ItemManager;
        inventory = GameManager.Inst.PlayerInventory;
    }
    public void objectIneractive()
    {
        if (GameManager.Inst.ItemManager.currentItemCount[(int)Itemlist.RepairKit] > 0)
        {
            if (!Fixed)
            {
                Fixed = true;
                GeneratorLight.color = Color.green;
                GameManager.Inst.KeyRoomBattery.BatteryCount += 1;
                ItemManager.currentItemCount[(int)Itemlist.RepairKit]--;
                if (ItemManager.currentItemCount[(int)Itemlist.RepairKit] == 0)
                {
                    ItemManager.ItemDelete(Itemlist.RepairKit);
                }
            }
        }       
    }

    public string objectName()
    {        
        if (!Fixed)
        {
            return "발전기(수리필요)";
        }
        else
        {
            return "발전기(작동중)";
        }
    }

    public bool canInteractive()
    {
        bool result = false;
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
