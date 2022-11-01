using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum immediatelyItem
{
    Bullet = 0,
    HpPotion,
}
public enum Itemlist
{
    Handgun=0,
    GlowStick,
    Oil,
    RepairKit,
    
}
public class ItemManager : MonoBehaviour
{
    [Header("인벤토리에 저장될 아이템 목록")]
    public GameObject[] SavedItem;
    PlayerInventory inventory;

    private void Awake()
    {       
        inventory = GameManager.Inst.PlayerInventory;
    }

    public void saveItem(Itemlist item)
    {
        inventory.item[inventory.savePos] = SavedItem[(int)item];
        inventory.savePos++;
    }
}