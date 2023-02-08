using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour, UseableObject
{
    FireTrap trap;
    bool used = false;
    float rotateTime = 0;
    private void Awake()
    {
        trap = FindObjectOfType<FireTrap>();
    }
   
    // 아이템 상호작용
    public void objectInteractive()
    {
        //아직 사용하지 않은 상태일때 
        if (!used)
        {
            used = true;
            GameManager.Inst.MissionObject.lockGasvalve();
            StartCoroutine(valveRotate());
            trap.ValveCount += 1;
        }        
    }
    //밸브를 1초 동안 회전
    IEnumerator valveRotate()
    {
        bool usingValve = true;
        while (usingValve)
        {
            transform.Rotate(0,360.0f*Time.deltaTime, 0);
            rotateTime += Time.deltaTime;
            if(rotateTime > 1)
            {
                usingValve = false;
            }
            yield return null;
        }
    }

    /// <summary>
    /// 아이템의 사용여부에 따라 이름 설정
    /// </summary>
    /// <returns>아이템이 사용되기 전이면 이름을 표시, 사용되었으면 공백으로 반환</returns>
    public string objectName()
    {
        string name = "가스밸브(잠그기)";
        if (used)
        {
            name = "";
        }
        return name;
    }

    public Sprite returnItemSprite()
    {
        return null;
    }

    public void UseItem()
    {
        
    }
}
