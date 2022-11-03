using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemCount : MonoBehaviour
{
    PlayerInventory inventory;
    private void Awake()
    {
        inventory = GameManager.Inst.PlayerInventory;
    }
}
