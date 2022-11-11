using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour, UseableObject
{    
    float chargedOil = 0;
    ItemManager itemManager;    
    private void Start()
    {
        itemManager = GameManager.Inst.ItemManager;
    }
    public void objectIneractive()
    {
        if(chargedOil < 5)
        {
            if (itemManager.currentItemCount[(int)Itemlist.Oil] > 0)
            {
                chargedOil += 1;
                itemManager.decreaseItemCount(Itemlist.Oil);
                if (itemManager.currentItemCount[(int)Itemlist.Oil] == 0)
                {
                    itemManager.ItemDelete(Itemlist.Oil);
                }
            }
        }
        else
        {
            GameManager.Inst.Escape();
        }
                
    }

    public string objectName()
    {
        if(chargedOil < 5)
        {
            return $"연료 : {chargedOil}/5";
        }
        else
        {
            return "탈출";
        }
        
    }

    public Sprite returnItemSprite()
    {
        return null;
    }

    public void UseItem()
    {

    }
}
