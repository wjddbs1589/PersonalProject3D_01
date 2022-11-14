using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//모든 아이템 리스트
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
    [SerializeField]int[] maxItemCount = {1,20,5,4,0,20};             //인벤토리 한 칸에 소지가능한 아이템 수

    [Header("소지중인 아이템 종류별 갯수")]
    public int[] currentItemCount = {1,0,0,0,0,0};          //현재 소지 수

    public int[] maxSpawnCount = {0,20,5,4,20,20};          //아이템 스폰 최대수
    public int[] currentSpawnCount = { 0, 0, 0, 0, 0, 0 };  //현재 스폰된 수

    private void Awake()
    {
        playerInventory = GameManager.Inst.PlayerInventory;
        playerInventory.inventory[playerInventory.savePos] = SavedItem[(int)Itemlist.Handgun]; // 인벤토리에 권총 아이템 넣음
        currentItemCount[(int)Itemlist.Handgun]++; // 권총의 아이템 카운트 증가
        playerInventory.savePos++;                 // 인벤토리에 아이템이 저장될 위치 변경
    }

    /// <summary>
    /// 아이템을 저장하는 함수
    /// </summary>
    /// <param name="itemName">아이템을 얻기위해 상호작용 했을때 넘겨받을 아이템의 enum 정보</param>
    /// <returns>아이템이 저장되었으면 true, 아니면 false반환</returns>
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
                playerInventory.inventory[playerInventory.savePos] = SavedItem[itemNum]; //인벤토리에 아이템이름에 해당하는 프리펩 저장
                playerInventory.insertItemImage(SavedItem[itemNum]);                     // 인벤토리에 아이템이 저장된 칸에 해당 아이템의 이미지를 저장

                increaseItemCount(itemName); //아이템 갯수 증가
                playerInventory.savePos++;   //아이템 저장위치 변경
            }
            else //있으면 갯수만 증가
            {
                increaseItemCount(itemName);
            }
            result = true;
        }
        else //인벤토리가 가득 찼을 때
        {
            Debug.Log("인벤토리가 가득 찼습니다.");
        }
        return result;       
    }

    //아이템 제거하는 함수
    public void ItemDelete(Itemlist item)
    {
        GameObject obj = SavedItem[(int)item]; // 저장된 아이템을 가져와서 게임오브젝트로 저장
        for (int i = 1; i < 6; i++) //반복문을 돌며 같은 아이템이 있는지 확인
        {
            if (playerInventory.inventory[i] == obj) //같은 아이템이면
            {
                for (int j = i; j < 5; j++)
                {
                    playerInventory.changeItemPosition(j); //없어진 아이템 뒤의 아이템을 한칸씩 앞으로 당겨오는 함수 실행
                }
                playerInventory.savePos--; // 아이템의 저장위치 한칸 감소
            }
        }
    }

    void increaseItemCount(Itemlist item)
    {
        GameObject obj = SavedItem[(int)item]; //얻은 아이템 저장

        //인벤토리칸 돌며 얻은아이템 찾음
        for (int i = 1; i < 6; i++)
        {
            if (playerInventory.inventory[i] == obj) //아이템을 찾았으면 개수 증가시키고 숫자 표시 바꿈
            {
                currentItemCount[(int)item] += 1;                                               //얻은 아이템의 개수 증가
                playerInventory.itemCountText[i].text = currentItemCount[(int)item].ToString(); //얻은 아이템의 개수 text변경
            }                
        }
    }

    public void decreaseItemCount(Itemlist item)
    {
        GameObject obj = SavedItem[(int)item];   //게임오브젝트

        for (int i = 1; i < 6; i++)
        {
            if (playerInventory.inventory[i] == obj) //아이템 비교해서 같은 아이템이면
            {
                currentItemCount[(int)item] -= 1;   //해당 아이템의 개수 감소
                playerInventory.itemCountText[i].text = currentItemCount[(int)item].ToString(); //해당 아이템의 개수 텍스트 변경
            }

        }
    }

}