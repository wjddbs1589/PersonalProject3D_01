using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [Header("인벤토리에 저장된 아이템 목록")]
    public GameObject[] inventory;
    public int savePos = 0;  //아이템이 저장될 인벤토리 위치

    [Header("빈 인벤토리 이미지")]
    public Sprite blankInvetoryImage; // Inspector창에서 이미지 넣음

    [SerializeField]Image[] itemSprite; //인벤토리에서 아이템의 이미지를 저장할 배열

    public TextMeshProUGUI[] itemCountText; // 현재 선택된 아이템을 몇개 가지고 있는지 표시할 text
    private void Awake()
    {
        int count = transform.childCount;  // 가지고 있는 자식의 수

        inventory = new GameObject[count]; 
        itemSprite = new Image[count];
        
        for (int i = 0; i < count; i++)
        {
            itemSprite[i] = transform.GetChild(i).GetComponent<Image>();
        }
        itemCountText = GetComponentsInChildren<TextMeshProUGUI>();
    }

    //아이템을 가지고 있는지 확인, 맵의 구조물에 상호작용전 확인용
    public bool hasItem()
    {
        bool result = false;
        return result;
    }

    /// <summary>
    /// 아이템의 정보와 위치를 받아와서, 해당위치의 아이템의 이미지를 넣는다
    /// </summary>
    /// <param name="item">이미지에 해당하는 아이템</param>
    public void insertItemImage(GameObject item)
    {
        Sprite sprite = item.GetComponent<UseableObject>().returnItemSprite();
        itemSprite[savePos].sprite = sprite;
    }

    /// <summary>
    /// 아이템 소진시 뒤의 아이템들을 당겨올때 실행될 함수
    /// </summary>
    /// <param name="item">앞으로 한칸 당길 아이템</param>
    /// <param name="itemPos">아이템을 당겨서 넣을 위치</param>
    public void changeItemPosition(int itemPos)
    {
        // 소진된 아이템 다음칸에 다른 아이템이 있는 경우
        if (inventory[itemPos + 1] != null)
        {                                                                                                            
            inventory[itemPos] = inventory[itemPos + 1];                                                          // 뒤의 아이템을 당겨옴
            itemSprite[itemPos].sprite = inventory[itemPos + 1].GetComponent<UseableObject>().returnItemSprite(); // 이미지 당겨옴
            itemCountText[itemPos].text = itemCountText[itemPos + 1].text;                                        // 아이템 개수 당겨옴

            inventory[itemPos + 1] = null;                                                                        // 당겨진칸 아이템 비우기
            itemSprite[itemPos + 1].sprite = blankInvetoryImage;                                                  // 당겨진칸 이미지 비우기
            itemCountText[itemPos + 1].text = "";                                                                 // 당겨진칸 아이템개수 비우기
        }
        else 
        {
            inventory[itemPos] = null;
            itemSprite[itemPos].sprite = blankInvetoryImage;
            itemCountText[itemPos].text = "";
        }
    }

}
