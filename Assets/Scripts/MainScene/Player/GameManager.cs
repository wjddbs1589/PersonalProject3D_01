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
    [SerializeField] static GameManager instance = null;
    public static GameManager Inst => instance;
    //---------------------------------------------
    [SerializeField] Player player;
    public Player Player => player;
    //---------------------------------------------    
    [SerializeField] ItemManager itemManager;
    public ItemManager ItemManager => itemManager;
    //---------------------------------------------
    [SerializeField] PlayerInventory playerInventory;
    public PlayerInventory PlayerInventory => playerInventory;
    //---------------------------------------------
    [SerializeField] KeyRoomBattery keyRoomBattery;
    public KeyRoomBattery KeyRoomBattery => keyRoomBattery;
    //---------------------------------------------
    [SerializeField] MonsterSpawner monsterSpawner;
    public MonsterSpawner MonsterSpawner => monsterSpawner;

    //---------------------------------------------
    [SerializeField] StopMenu stopMenu;
    public StopMenu StopMenu => stopMenu;
    //---------------------------------------------
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            instantiate();
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

    public void openMenu()
    {
        stopMenu.transform.gameObject.SetActive(true);
    }
    public void closeMenu()
    {
        stopMenu.transform.gameObject.SetActive(false);
    }

    /// <summary>
    /// 플레이어가 죽었을때 실행될 함수
    /// </summary>
    public void PlayerDead()
    {
        SceneManager.LoadScene("SelectScene"); // 시작 씬으로 이동
    }
    public void instantiate()
    {
        player = FindObjectOfType<Player>();
        keyRoomBattery = FindObjectOfType<KeyRoomBattery>();
        itemManager = FindObjectOfType<ItemManager>();
        playerInventory = FindObjectOfType<PlayerInventory>();
        monsterSpawner = FindObjectOfType<MonsterSpawner>();
        stopMenu = FindObjectOfType<StopMenu>();
    }
}
