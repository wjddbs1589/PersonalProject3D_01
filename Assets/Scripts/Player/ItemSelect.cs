using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelect : MonoBehaviour
{
    Player player;
    public Transform itemPos;
    public int preItemNum;
    public GameObject nowItem;
    UseableObject obj;
    private void Awake()
    {
    }
    private void Start()
    {
        player = GameManager.Inst.Player;
        player.onItemChange += ItemChange;
    }

    private void ItemChange(int itemNumber)
    {
        if (player.SelectedItemNumber != 0 && GameManager.Inst.PlayerInventory.inventory[itemNumber] != null)
        {
            Destroy(nowItem);
            nowItem = Instantiate(GameManager.Inst.PlayerInventory.inventory[itemNumber], itemPos.position, itemPos.transform.rotation);
            nowItem.transform.parent = transform;
        }
    }

    public void Use()
    {
        UseableObject obj = nowItem.GetComponent<UseableObject>();
        
        obj.UseItem();
    }
}
