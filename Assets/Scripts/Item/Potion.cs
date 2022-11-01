using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemManager;

public class Potion : MonoBehaviour, UseableObject
{
    Player player;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    public bool immediatelyUseable()
    {
        
        return true;
    }

    public void objectIneractive()
    {
        if (player.HP < 100)
        {
            player.HP += 20.0f;
            Destroy(gameObject);
        }
    }

    public string objectName()
    {
        return "체력포션";
    }

    public int maxCount()
    {
        return 0;
    }
}
