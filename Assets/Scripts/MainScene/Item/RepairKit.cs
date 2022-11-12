using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class RepairKit : MonoBehaviour, UseableObject
{
    public Sprite itemImagePrefab;

    public void objectIneractive()
    {
        if (GameManager.Inst.ItemManager.saveItem(Itemlist.RepairKit))
        {
            Destroy(gameObject);
        }
    }
    
    public string objectName()
    {
        return "수리키트";
    }

    public void UseItem()
    {
       
    }
    public Sprite returnItemSprite()
    {
        return itemImagePrefab;
    }
}
