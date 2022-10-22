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
        handgun.changeBulletCount += bulletCount;
    }

    private void bulletCount(int obj)
    {
        text.text = $"{handgun.CurrentBulletCount}/{handgun.MaxBulletCount}";
    }
}
