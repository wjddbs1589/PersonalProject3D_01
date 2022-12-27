using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour, UseableObject
{
    Light GeneratorLight;
    bool Fixed = false;
    ItemManager ItemManager;
    private void Awake()
    {
        GeneratorLight = transform.GetComponentInChildren<Light>();
        
    }
    private void Start()
    {
        ItemManager = GameManager.Inst.ItemManager;
    }
    public void objectIneractive()
    {
        if (GameManager.Inst.ItemManager.currentItemCount[(int)Itemlist.RepairKit] > 0) // 현재 수리키트 아이템을 0개보다 많이 가지고 있을때
        {
            if (!Fixed) //만약 수리된 상태가 아니면
            {
                Fixed = true; //상태 변경
                GeneratorLight.color = Color.green;                             //오브젝트의 빛 녹색으로 변경
                GameManager.Inst.KeyRoomBattery.BatteryCount += 1;              //수리된 배터리 개수 증가
                ItemManager.currentItemCount[(int)Itemlist.RepairKit]--;        //리페어 키트 개수 감소
                GameManager.Inst.MissionObject.fixGenerate();                   //미션 오브젝트 갱신
                if (ItemManager.currentItemCount[(int)Itemlist.RepairKit] == 0) //남은 리페어 키트가 없으면
                {
                    ItemManager.ItemDelete(Itemlist.RepairKit);                 //인벤토리에서 삭제
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
