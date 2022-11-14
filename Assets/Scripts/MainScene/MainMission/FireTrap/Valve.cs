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
   
    public void objectIneractive()
    {
        if (!used)
        {
            used = true;
            StartCoroutine(valveRotate());
            trap.ValveCount += 1;
        }        
    }
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
