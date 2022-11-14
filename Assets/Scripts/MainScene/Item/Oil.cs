using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour, UseableObject
{
    public Sprite itemImagePrefab;
    //아이템 상호작용시
    public void objectIneractive()
    {
        if (GameManager.Inst.ItemManager.saveItem(Itemlist.Oil)) //인벤토리에 추가하고
        {
            Destroy(gameObject); //게임오브젝트 삭제
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
