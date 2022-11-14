using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class KeyRoomBattery : MonoBehaviour
{
    Battery[] batterys;
    Material[] materials;
    //배터리 개수-------------------------------------------------------
    int batteryCount = 0;
    public int BatteryCount
    {
        get => batteryCount;
        set
        {
            batteryCount = Mathf.Clamp(value,0,4);
            OnBattery?.Invoke(batteryCount);
        }
    }
    public Action<int> OnBattery;
    //-------------------------------------------------------

    private void Awake()
    {        
        batterys = GetComponentsInChildren<Battery>();        
    }
    private void Start()
    {
        OnBattery += BatteryLightChange;
    }

    /// <summary>
    /// 발전기가 작동되어 불이 켜질때 마다 자식오브젝트의 2번째 material의 _EmissionColor를 변경하는 함수
    /// </summary>
    /// <param name="count">발전기 작동 카운트</param>
    private void BatteryLightChange(int count)
    {
        materials = batterys[count-1].gameObject.GetComponent<Renderer>().materials;
        materials[1].SetColor("_EmissionColor",Color.green);
    }
}
