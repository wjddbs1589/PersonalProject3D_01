using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // 스폰될 아이템 수 --------------------------------------
    protected int maxSpawnCount;
    public int MaxSpawnCount => maxSpawnCount;
    // 스폰된 아이템 수 --------------------------------------
    protected int currentSpawnCount = 0;
    public int CurrentSpawnCount
    {
        get => currentSpawnCount;
        set
        {
            currentSpawnCount = value;
        }
    }
    //가질수 있는 아이템 수 --------------------------------------
    protected int maxItemCount;
    public int MaxItemCount => maxItemCount;

    //가지고 있는 아이템수  --------------------------------------
    protected int currentItemCount = 0;
    public int CurrentItemCount
    {
        get => currentItemCount;
        set
        {
            currentItemCount = value;
        }
    }
}
