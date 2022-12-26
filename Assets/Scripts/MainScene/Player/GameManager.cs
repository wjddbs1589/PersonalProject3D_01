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
    //플레이어---------------------------------------------
    [SerializeField] Player player;
    public Player Player => player;
    //아이템 매니저---------------------------------------------    
    [SerializeField] ItemManager itemManager;
    public ItemManager ItemManager => itemManager;
    //인벤토리---------------------------------------------
    [SerializeField] PlayerInventory playerInventory;
    public PlayerInventory PlayerInventory => playerInventory;
    //배터리---------------------------------------------
    [SerializeField] KeyRoomBattery keyRoomBattery;
    public KeyRoomBattery KeyRoomBattery => keyRoomBattery;
    //몬스터 스포너---------------------------------------------
    [SerializeField] MonsterSpawner monsterSpawner;
    public MonsterSpawner MonsterSpawner => monsterSpawner;

    //일시정지 메뉴 ui---------------------------------------------
    [SerializeField] StopMenu stopMenu;
    public StopMenu StopMenu => stopMenu;
    //도움말 ui---------------------------------------------
    [SerializeField] HelpBoard helpBoard;
    public HelpBoard HelpBoard => helpBoard;

    public bool tutorialCheck = false;

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
    private void Start()
    {
        
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
        playerInventory = FindObjectOfType<PlayerInventory>();
        keyRoomBattery = FindObjectOfType<KeyRoomBattery>();
        itemManager = FindObjectOfType<ItemManager>();
        monsterSpawner = FindObjectOfType<MonsterSpawner>();
        stopMenu = FindObjectOfType<StopMenu>();
        helpBoard = FindObjectOfType<HelpBoard>();
    }
}
