using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BulletCount : MonoBehaviour
{
    TextMeshProUGUI text;

    Handgun handgun;
    private void Awake()
    {
        handgun = GameObject.Find("Handgun").gameObject.GetComponent<Handgun>();
        text = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        handgun.changeBullet += bulletCount;
        handgun.changeHaveBullet += haveBullet;
    }  
    private void bulletCount(int obj)
    {
        text.text = $"{handgun.ReloadedBulletCount}/{handgun.HaveBullet}";
    }
    private void haveBullet(int obj)
    {
        text.text = $"{handgun.ReloadedBulletCount}/{handgun.HaveBullet}";
    }
}
