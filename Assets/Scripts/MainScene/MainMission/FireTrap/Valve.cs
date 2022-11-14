using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour, UseableObject
{
    FireTrap trap;
    bool used = false;
    bool usingValve = true;
    float rotateTime = 0;
    private void Awake()
    {
        trap = FindObjectOfType<FireTrap>();
    }
   
    // 아이템 상호작용
    public void objectIneractive()
    {
        //아직 사용하지 않은 상태일때 상호작용후 사용됨으로 변경
        if (!used)
        {
            used = true;
            StartCoroutine(valveRotate());
            trap.ValveCount += 1;
        }        
    }
    // 아이템을 사용했을때 while문을 이용하여 밸브를 일정 시간동안 회전시키고 일정시간이 지나면 while문 탈출하여 멈춤
    IEnumerator valveRotate()
    {
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
