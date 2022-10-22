using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, UseableObject
{
    Player player;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    public bool directUseable()
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
}
