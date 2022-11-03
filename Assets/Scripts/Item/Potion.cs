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

    public void objectIneractive()
    {
        if (GameManager.Inst.ItemManager.saveItem(Itemlist.HpPotion))
        {
            Destroy(gameObject);
        }
        //if (player.HP < 100)
        //{
        //    player.HP += 20.0f;
        //    Destroy(transform.parent.gameObject);
        //    Destroy(gameObject);
        //}
    }
    public string objectName()
    {
        return "체력포션";
    }

    public void UseItem()
    {
        if (player.HP < 100)
        {
            player.HP += 20.0f;
            itemManager.currentItemCount[(int)Itemlist.HpPotion]--;
            if (itemManager.currentItemCount[(int)Itemlist.HpPotion] == 0)
            {
                itemManager.ItemDelete(Itemlist.HpPotion);
                Destroy(gameObject);
            }
        }
    }
    public Sprite returnItemSprite()
    {
        return itemImagePrefab;
    }
}
