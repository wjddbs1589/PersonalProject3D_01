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

    public bool immediatelyUseable()
    {
        return true;
    }

    public void objectIneractive()
    {
        bullet.HaveBullet += 15;
        Destroy(gameObject);
    }

    public string objectName()
    {
        return "총알";
    }

    public int maxCount()
    {
        return 0;
    }
}
