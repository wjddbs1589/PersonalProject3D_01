using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour, UseableObject
{
    public Sprite itemImagePrefab;
    public void objectIneractive()
    {
        if (GameManager.Inst.ItemManager.saveItem(Itemlist.Oil))
        {
            Destroy(gameObject);
        }
    }
    public string objectName()
    {
        return "연료";
    }

    public void UseItem()
    {
        
    }

    public Sprite returnItemSprite()
    {
        return itemImagePrefab;
    }
}
