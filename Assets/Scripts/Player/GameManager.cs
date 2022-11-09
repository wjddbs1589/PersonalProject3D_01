using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using static ItemManager;
using System;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;
    public static GameManager Inst => instance;
    //---------------------------------------------
    Player player;
    public Player Player => player;
    //---------------------------------------------    
    ItemManager itemManager;
    public ItemManager ItemManager => itemManager;
    //---------------------------------------------
    PlayerInventory playerInventory;
    public PlayerInventory PlayerInventory => playerInventory;
    //---------------------------------------------
    KeyRoomBattery keyRoomBattery;
    public KeyRoomBattery KeyRoomBattery => keyRoomBattery;
    //---------------------------------------------
    MonsterSpawner monsterSpawner;
    public MonsterSpawner MonsterSpawner => monsterSpawner;

    bool monsterDead = false;
    public bool MonsterDead
    {
        get => monsterDead;
        set 
        {
            monsterDead = value;
            if(monsterDead == true)
            {
                monsterRespawn();
            }
        }
    } 
    //---------------------------------------------
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;              
            player = FindObjectOfType<Player>();
            keyRoomBattery = FindObjectOfType<KeyRoomBattery>();
            itemManager = FindObjectOfType<ItemManager>();
            playerInventory = FindObjectOfType<PlayerInventory>();
            monsterSpawner = FindObjectOfType<MonsterSpawner>();
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void monsterRespawn()
    {
        StartCoroutine(respawnTimer());
    }

    IEnumerator respawnTimer()
    {
        yield return new WaitForSeconds(30.0f);
        Debug.Log("몬스터 재 생성");
        monsterSpawner.spawnMonster();
        monsterDead = false;
    }
}