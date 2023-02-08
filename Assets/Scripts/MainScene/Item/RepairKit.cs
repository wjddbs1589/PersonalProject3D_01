using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class RepairKit : MonoBehaviour, UseableObject
{
    public Sprite itemImagePrefab;
    ItemManager itemManager;
    private void Start()
    {
        itemManager = GameManager.Inst.ItemManager;
    }
    //아이템 상호작용시 발생하는 함수
    public void objectInteractive()
    {
        if (itemManager.currentItemCount[(int)Itemlist.RepairKit] < itemManager.maxItemCount[(int)Itemlist.RepairKit]) //현재 가진 아이템이 최대 소지 개수보다 적을 때
        {
            if (itemManager.saveItem(Itemlist.RepairKit)) //인벤토리에 저장후
            {
                Destroy(gameObject); //상호작용한 게임오브젝트 삭제
            }
        }
    }
    
    public string objectName()
    {
        string name = "수리키트";
        if(itemManager.currentItemCount[(int)Itemlist.RepairKit] == itemManager.maxItemCount[(int)Itemlist.RepairKit])
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
