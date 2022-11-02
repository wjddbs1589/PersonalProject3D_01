using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject[] inventory;
    public int savePos = 0;
    public int usePos = 0;

    private void Awake()
    {
        inventory = new GameObject[6];
    }

    //아이템을 가지고 있는지 확인, 맵에 여러 기믹에 상호작용전 확인용
    public bool hasItem()
    {
        bool result = false;
        return result;
    }

}
