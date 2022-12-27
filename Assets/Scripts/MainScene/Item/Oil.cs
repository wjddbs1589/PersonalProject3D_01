using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour, UseableObject
{
    public Sprite itemImagePrefab;
    ItemManager itemManager;
    private void Start()
    {
        itemManager = GameManager.Inst.ItemManager;
    }
    //아이템 상호작용시
    public void objectIneractive()
    {
        if (itemManager.currentItemCount[(int)Itemlist.Oil] < itemManager.maxItemCount[(int)Itemlist.Oil]) //현재 가진 아이템이 최대 소지 개수보다 적을 때
        {
            if (GameManager.Inst.ItemManager.saveItem(Itemlist.Oil)) //인벤토리에 추가하고
            {
                GameManager.Inst.MissionObject.gainOil();
                Destroy(gameObject); //게임오브젝트 삭제
            }
        }
        
    }
    public string objectName()
    {
        string name = "오일";
        if (itemManager.currentItemCount[(int)Itemlist.Oil] == itemManager.maxItemCount[(int)Itemlist.Oil])
        {
            name = "더이상 소지 불가";
        }
        return name;
    }

    public void UseItem()
    {
        
    }

    public Sprite returnItemSprite()
    {
        return itemImagePrefab;
    }
}
