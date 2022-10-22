using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Handgun : MonoBehaviour
{
    float originDelay = 1.0f;
    float shotDelay = 1.0f;
    bool noBullet = false;
    public bool Reloading = false;
    Animator anim;
    GameObject reloadText;

    int maxBulletCount = 30;
    public int MaxBulletCount { get => maxBulletCount; }

    public Action<int> changeBulletCount;

    int currentBulletCount = 30;
    public int CurrentBulletCount 
    {
        get => currentBulletCount;
        set 
        {
            currentBulletCount = Mathf.Clamp(value, 0, 30);
            changeBulletCount?.Invoke(currentBulletCount);
        }
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
        reloadText = GameObject.Find("reloadText").gameObject;
        reloadText.SetActive(false);
    }
    void Update()
    {
        if(shotDelay >= 0.0f)
        {
            shotDelay -= Time.deltaTime;
            shotDelay = Mathf.Clamp(shotDelay, 0.0f, originDelay);
        }
    }

    public void shotHandgun()
    {
        if (shotDelay <= 0.0f && !Reloading)
        {
            if (!noBullet)
            {
                anim.SetTrigger("Shot");
            }
            else
            {
                ReloadHandgun();
            }
        }
    }    

    public void ReloadHandgun()
    {
        Reloading = true;
        reloadText.SetActive(true);
        anim.SetTrigger("Reload");
        StartCoroutine(reload());
    }
    IEnumerator reload()
    {        
        yield return new WaitForSeconds(1.7f);
        CurrentBulletCount = MaxBulletCount;
        anim.SetBool("noBullet", false);
        noBullet = false;        
        reloadText.SetActive(false);
        Reloading = false;
    }

    public void BulletCountDecrease()
    {
        CurrentBulletCount--;
        if (CurrentBulletCount == 0)
        {
            noBullet = true;
            anim.SetBool("noBullet", true);
        }
    }
}
