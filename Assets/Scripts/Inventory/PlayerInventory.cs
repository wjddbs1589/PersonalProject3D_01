using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject[] item;
    public int savePos = 0;
    public int usePos = 0;

    private void Awake()
    {
        item = new GameObject[6];
    }
}
