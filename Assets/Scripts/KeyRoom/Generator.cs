using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour, UseableObject
{
    Light GeneratorLight;
    bool Fixed = false;

    private void Awake()
    {
        GeneratorLight = transform.GetComponentInChildren<Light>();
    }
    public bool immediatelyUseable()
    {
        return true;
    }

    public void objectIneractive()
    {        
        if (!Fixed)
        {
            Fixed = true;
            GeneratorLight.color = Color.green;
            GameManager.Inst.KeyRoomBattery.BatteryCount += 1;
        }
    }

    public string objectName()
    {
        if (!Fixed)
        {
            return "발전기(수리필요)";
        }
        else
        {
            return "발전기(작동중)";
        }
    }

    public int maxCount()
    {
        return 0;
    }
}
