using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowStick : MonoBehaviour, UseableObject
{
    Rigidbody rigid;
    ItemManager itemManager;
    Transform itemUsePos;
    public Sprite itemImagePrefab;
    Player player;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
        itemUsePos = GameObject.Find("ItemPos").transform;
    }
    private void Start()
    {
        player = GameManager.Inst.Player;
        itemManager = GameManager.Inst.ItemManager;
    }

    /// <summary>
    /// 아이템 상호작용시 인벤토리에 저장하고 게임오브젝트 제거
    /// </summary>
    public void objectIneractive()
    {
        if (GameManager.Inst.ItemManager.saveItem(Itemlist.GlowStick))
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 아이템의 이름을 반환
    /// </summary>
    /// <returns>아이템 이름</returns>
    public string objectName()
    {
        return "야광봉";
    }

    /// <summary>
    /// 아이템을 들고있을때 사용하면 발생하는 함수
    /// </summary>
    public void UseItem()
    {
        if (itemManager.currentItemCount[(int)Itemlist.GlowStick] != 0)
        {
            GameObject obj = Instantiate(GameManager.Inst.ItemManager.SavedItem[(int)Itemlist.GlowStick]);  //해당 아이템 생성
            obj.transform.position = itemUsePos.position;  // 아이템이 사용되었을때 생성위치(플레이어 안에 내재된 아이템 사용위치)로 이동
            obj.GetComponent<Rigidbody>().useGravity = true;         // 아이템에 중력 적용
            obj.GetComponent<Collider>().isTrigger = false;          // 아이템의 isTrigger 변경

            itemManager.decreaseItemCount(Itemlist.GlowStick);       // 아이템을 사용 하였으므로 인벤토리에서 개수 감소
            if (itemManager.currentItemCount[(int)Itemlist.GlowStick] == 0) //아이템을 사용하여 아이템의 개수가 0개가 되면 
            {
                itemManager.ItemDelete(Itemlist.GlowStick); // 인벤토리에서 삭제
                player.SelectedItemNumber -= 1;             // 선택된 아이템 슬롯 앞당김
            }
        }
        
    }
    public Sprite returnItemSprite()
    {
        return itemImagePrefab;
    }
}
