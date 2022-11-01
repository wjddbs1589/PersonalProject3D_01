using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using static ItemManager;

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


    //---------------------------------------------
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;              
            DontDestroyOnLoad(this.gameObject); 
            player = FindObjectOfType<Player>();
            itemManager = FindObjectOfType<ItemManager>();
            playerInventory = FindObjectOfType<PlayerInventory>();
            keyRoomBattery = FindObjectOfType<KeyRoomBattery>();
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }   
}
