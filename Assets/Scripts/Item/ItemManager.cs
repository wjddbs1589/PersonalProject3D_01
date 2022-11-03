using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public enum Itemlist
{
    Handgun=0,
    GlowStick,
    Oil,
    RepairKit,
    Bullet,
    HpPotion,

}
public class ItemManager : MonoBehaviour
{
    [Header("인벤토리에 저장될 아이템 목록")]
    public GameObject[] SavedItem;
    PlayerInventory playerInventory;

    // 권총/형광봉/기름통/수리키트/총알/포션 - 순서

    [Header("한칸에 들어가는 아이템 갯수")]
    [SerializeField]int[] maxItemCount = {1,20,5,4,0,0};             //아이템 최대 소지수

    [Header("소지중인 아이템 종류별 갯수")]
    public int[] currentItemCount = {1,0,0,0,0,0};          //현재 소지 수

    [Header("현재 칸에 있는 아이템 목록")]
    [SerializeField] Itemlist[] haveItemlist;

    [SerializeField] int[] itemCount = {0,0,0,0,0,0};
    [SerializeField] int[] itemSavepos;

    public int[] maxSpawnCount = {0,20,5,4,20,20};          //아이템 스폰 최대수
    public int[] currentSpawnCount = { 0, 0, 0, 0, 0, 0 };  //현재 스폰된 수

    private void Awake()
    {
        playerInventory = GameManager.Inst.PlayerInventory;

        haveItemlist = new Itemlist[6];

        playerInventory.inventory[playerInventory.savePos] = SavedItem[(int)Itemlist.Handgun];
        currentItemCount[(int)Itemlist.Handgun]++;
        playerInventory.savePos++;

        //가지고 잇는 아이템 초기화
        //for(int i = 0; i < 6; i++)
        //{
        //    currentItemCount[i] = 0;
        //    currentSpawnCount[i] = 0;
        //}
    }

    public bool saveItem(Itemlist itemName)
    {
        bool result = false;
        int itemNum = (int)itemName;
        //인벤토리에 공간이 있으면
        if (playerInventory.savePos < playerInventory.inventory.Length)
        {
            //현재 아이템이 하나도 없으면 추가
            if (currentItemCount[itemNum] == 0 || currentItemCount[itemNum] == maxItemCount[itemNum])
            {
                playerInventory.inventory[playerInventory.savePos] = SavedItem[itemNum];
                playerInventory.insertItemImage(SavedItem[itemNum]);
                currentItemCount[itemNum]++;
                playerInventory.savePos++;
            }
            else //있으면 갯수만 증가
            {
                currentItemCount[itemNum]++;
            }
            Debug.Log($"{itemName}을 얻었습니다.");
            result = true;
        }
        else
        {
            Debug.Log("인벤토리가 가득 찼습니다.");
        }
        return result;       
    }

    public void ItemDelete(Itemlist item)
    {
        GameObject obj = SavedItem[(int)item];
        for (int i = 1; i < 6; i++)
        {
            if (playerInventory.inventory[i] == obj)
            {
                for (int j = i; j < 5; j++)
                {
                    playerInventory.changeItemImage(j);
                }
                playerInventory.savePos--;
            }
        }
    }
}