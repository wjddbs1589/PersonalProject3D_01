using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelect : MonoBehaviour
{
    Player player;
    Transform itemPos;
    public int preItemNum;
    public GameObject nowItem;
    UseableObject obj;
    private void Start()
    {
        player = GameManager.Inst.Player;
        player.onItemChange += ItemChange;
        itemPos = transform.Find("ItemPos").transform;
    }

    private void ItemChange(int itemNumber)
    {
        if(player.SelectedItemNumber == 0) // 현재 선택된 아이템 번호가 0이면
        {
            Destroy(nowItem); //지금 들고있는 아이템 제거
        }
        else if (player.SelectedItemNumber != 0 && GameManager.Inst.PlayerInventory.inventory[itemNumber] != null) //선택된 아이템번호가 0이 아니고 선택된 칸에 인벤토리가 비어있지 않으면 실행
        {
            Destroy(nowItem); //지금 들고있는 아이템 제거
            nowItem = Instantiate(GameManager.Inst.PlayerInventory.inventory[itemNumber], itemPos.position, itemPos.transform.rotation); // 인벤토리에서 선택된 번호의 위치에 있는 아이템을 생성, 아이템의 위치를 생성위치로 설정 , 회전도 동일하게 설정
            nowItem.transform.parent = transform; // 생성된 아이템의 부모 설정
        }
    }

    /// <summary>
    /// 선택된 아이템을 사용하는 함수
    /// </summary>
    public void Use()
    {
        UseableObject obj = nowItem.GetComponent<UseableObject>(); // 선택된 아이템이 가지고 있는 useableObject를 가져옴 
        
        obj.UseItem(); //사용함수 실행
    }
}
