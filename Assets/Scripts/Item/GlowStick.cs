using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GlowStick : MonoBehaviour, UseableObject
{
    Rigidbody rigid;
    ItemManager itemManager;
    public ItemUsePos itemUsePos;
    public Sprite itemImagePrefab;
    Player player;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
        itemUsePos = FindObjectOfType<ItemUsePos>();
        player = GameManager.Inst.Player;
    }
    private void Start()
    {
        itemManager = GameManager.Inst.ItemManager;
    }
    public void objectIneractive()
    {
        if (GameManager.Inst.ItemManager.saveItem(Itemlist.GlowStick))
        {
            Destroy(gameObject);
        }
    }

    public string objectName()
    {
        return "야광봉";
    }

    public void UseItem()
    {
        if (itemManager.currentItemCount[(int)Itemlist.GlowStick] != 0)
        {
            GameObject obj = Instantiate(GameManager.Inst.ItemManager.SavedItem[(int)Itemlist.GlowStick]);
            obj.transform.position = itemUsePos.transform.position;
            obj.GetComponent<Rigidbody>().useGravity = true;
            obj.GetComponent<Collider>().isTrigger = false;

            itemManager.decreaseItemCount(Itemlist.GlowStick);
            if (itemManager.currentItemCount[(int)Itemlist.GlowStick] == 0)
            {
                itemManager.ItemDelete(Itemlist.GlowStick);
                player.SelectedItemNumber -= 1;
            }
        }
        
    }
    public Sprite returnItemSprite()
    {
        return itemImagePrefab;
    }
}
