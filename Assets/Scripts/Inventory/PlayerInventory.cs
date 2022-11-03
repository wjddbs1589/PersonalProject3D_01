using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [Header("인벤토리에 저장된 아이템 목록")]
    public GameObject[] inventory;

    public int savePos = 0;
    public int usePos = 0;

    [Header("빈 인벤토리 이미지")]
    public Sprite blankInvetoryImage;

    [SerializeField]Image[] itemSprite; //인벤토리에서 아이템의 이미지를 저장할 배열

    public TextMeshProUGUI[] itemCountText;
    private void Awake()
    {
        inventory = new GameObject[6];
        itemSprite = new Image[6];
        for(int i = 0; i < 6; i++)
        {
            itemSprite[i] = transform.GetChild(i).GetComponent<Image>();
        }
        itemCountText = GetComponentsInChildren<TextMeshProUGUI>();
    }

    //아이템을 가지고 있는지 확인, 맵에 여러 기믹에 상호작용전 확인용
    public bool hasItem()
    {
        bool result = false;
        return result;
    }

    /// <summary>
    /// 아이템의 정보와 위치를 받아와서, 해당위치의 아이템의 이미지를 넣는다
    /// </summary>
    /// <param name="item">이미지에 해당하는 아이템</param>
    /// <param name="itemPos">이미지를 넣을 위치</param>
    public void insertItemImage(GameObject item = null)
    {
        if (item != null)
        {
            Sprite sprite = item.GetComponent<UseableObject>().returnItemSprite();
            if (sprite != null)
            {
                itemSprite[savePos].sprite = sprite;
            }
        }
        else
        {
            itemSprite[savePos].sprite = blankInvetoryImage;
        }
    }

    /// <summary>
    /// 아이템의 순서를 앞당기고 뒤의칸 공백으로 변경
    /// </summary>
    /// <param name="item">앞으로 한칸 당길 아이템</param>
    /// <param name="itemPos">당겨서 넣을</param>
    public void changeItemImage(int itemPos)
    {
        if (inventory[itemPos + 1] != null)
        {
            inventory[itemPos] = inventory[itemPos + 1];                                                          //뒤의 아이템을 당겨옴
            itemSprite[itemPos].sprite = inventory[itemPos + 1].GetComponent<UseableObject>().returnItemSprite(); //이미지 당겨옴
            itemCountText[itemPos].text = itemCountText[itemPos + 1].text;                                                  //아이템 개수 당겨옴
            itemSprite[itemPos + 1].sprite = blankInvetoryImage;                                                  //당겨진칸 이미지 비우기
            inventory[itemPos + 1] = null;                                                                        //당겨진칸 아이템 비우기
            itemCountText[itemPos + 1].text = "";                                                                    //당겨진칸 아이템수 비우기
        }
        else
        {
            inventory[itemPos] = null;
            itemSprite[itemPos].sprite = blankInvetoryImage;
            itemCountText[itemPos].text = "";
        }
    }

}
