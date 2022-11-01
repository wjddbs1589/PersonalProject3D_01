using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : Item, UseableObject
{
    public bool immediatelyUseable()
    {
        return false;
    }
    public int maxCount()
    {
        return maxItemCount;
    }
    public void objectIneractive()
    {
        GameManager.Inst.ItemManager.saveItem(Itemlist.Oil);
        Debug.Log($"{gameObject.name}을 얻었습니다.");
        Destroy(gameObject);
    }
    public string objectName()
    {
        return "연료";
    }
    private void Awake()
    {
        maxItemCount = 5;
        currentItemCount = 0;
    }
}
