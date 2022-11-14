using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using static ItemManager;
using System;
using Unity.VisualScripting;

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

    //몬스터 리스폰 함수
    public void monsterRespawn()
    {
        StartCoroutine(respawnTimer()); //몬스터 리스폰 코루틴 실행
    }

    IEnumerator respawnTimer()
    {
        yield return new WaitForSeconds(30.0f); //30초 이후에
        monsterSpawner.spawnMonster(); //몬스터 재생성함수 실행
    }

    /// <summary>
    /// 플레이어가 죽었을때 실행될 함수
    /// </summary>
    public void PlayerDead()
    {
        SceneManager.LoadScene("SelectScene"); // 시작 씬으로 이동
    }
}
