using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainBullet : MonoBehaviour, UseableObject
{
    Handgun bullet;
    private void Awake()
    {
        bullet = GameObject.Find("Handgun").gameObject.GetComponent<Handgun>();       
    }

    public void objectIneractive()
    {
        if(bullet.HaveBullet < bullet.MaxBullet)
        {
            bullet.HaveBullet += 15;
            Destroy(gameObject);
        }
    }

    public string objectName()
    {
        string itemName = "총알";
        if (bullet.HaveBullet == bullet.MaxBullet)
        {
            itemName = "더 이상 소지할 수 없습니다.";
        }
        return itemName;
    }

    public void UseItem()
    {
       
    }
}
