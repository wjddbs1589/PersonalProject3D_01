using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class RepairKit : MonoBehaviour, UseableObject
{
    public Sprite itemImagePrefab;

    //아이템 상호작용시 발생하는 함수
    public void objectIneractive()
    {
        if (GameManager.Inst.ItemManager.saveItem(Itemlist.RepairKit)) //인벤토리에 저장후
        {
            Destroy(gameObject); //상호작용한 게임오브젝트 삭제
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
