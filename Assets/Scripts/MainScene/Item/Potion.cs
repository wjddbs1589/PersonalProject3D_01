using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemManager;

public class Potion : MonoBehaviour, UseableObject
{
    Player player;
    ItemManager itemManager;
    public Sprite itemImagePrefab;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void Start()
    {
        itemManager = GameManager.Inst.ItemManager;
    }

    public void objectInteractive()
    {
        if (GameManager.Inst.ItemManager.saveItem(Itemlist.HpPotion)) // 인벤토리에 아이템 추가
        {
            Destroy(gameObject); // 현재 아이템 삭제
        }
    }
    public string objectName()
    {
        return "체력포션";
    }

    //아이템 사용함수
    public void UseItem()
    {
        if (player.HP < 100) // 피가 최대치가 아닐때
        {
            player.HP += 20.0f;                                            // 체력 회복, 최대치를 넘지 않음
            itemManager.decreaseItemCount(Itemlist.HpPotion);              // 아이템을 사용 하였으므로 개수 감소 
            if (itemManager.currentItemCount[(int)Itemlist.HpPotion] == 0) // 사용한 아이템이 마지막 이었을 경우
            {
                itemManager.ItemDelete(Itemlist.HpPotion); // 인벤토리에서 지우고
                Destroy(gameObject);                       // 들고있던 게임오브젝트 삭제
            }
        }
    }
    /// <summary>
    /// 포션이 가지고 있는 sprite반환
    /// </summary>
    /// <returns>이 아이템의 sprite</returns>
    public Sprite returnItemSprite()
    {
        return itemImagePrefab;
    }
}
