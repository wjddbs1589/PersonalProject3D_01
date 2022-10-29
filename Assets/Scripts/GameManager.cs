using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;
    public static GameManager Inst => instance;
    //---------------------------------------------
    KeyRoomBattery keyRoomBattery;
    public KeyRoomBattery KeyRoomBattery => keyRoomBattery;
    //---------------------------------------------
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;              
            DontDestroyOnLoad(this.gameObject); 
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
