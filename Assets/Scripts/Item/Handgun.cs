using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Handgun : MonoBehaviour, UseableObject
{
    float originDelay = 1.0f;
    float shotDelay = 1.0f;
    bool noBullet = false;
    public bool Reloading = false;
    Animator anim;
    GameObject reloadText;
    public Sprite itemImagePrefab;

    //public GameObject bullet;
    public Transform bulletPos;

    int maxBullet = 50;
    public int MaxBullet => maxBullet; //총알 최대 소지 갯수 
    //----------------------------------------------------------------------------
    int canReloadBulletCount = 15; // 장전가능한 총알 개수
    int reloadedBullet = 15;       // 장전된 총알 개수
    public int ReloadedBulletCount 
    {
        get => reloadedBullet;
        set 
        {
            reloadedBullet = Mathf.Clamp(value, 0, canReloadBulletCount);
            changeBullet?.Invoke(reloadedBullet);
        }
    }
    public Action<int> changeBullet;
    //----------------------------------------------------------------------------
    int haveBullet = 0;  // 소지한 총알 개수
    public int HaveBullet
    {
        get => haveBullet;
        set
        {
            haveBullet = Mathf.Clamp(value, 0, MaxBullet);
            changeBullet?.Invoke(haveBullet);   
        }
    }
    public Action<int> changeHaveBullet;
    //----------------------------------------------------------------------------
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
    public void objectIneractive()
    {
        shotHandgun();
    }

    public string objectName()
    {
        return "권총";
    }

    public void shotHandgun()
    {
        if (shotDelay <= 0.0f && !Reloading)
        {
            if (!noBullet)
            {
                shotDelay = originDelay;
                //GameObject obj =  Instantiate(bullet, bulletPos);
                //obj.transform.parent = null;
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
        if (!Reloading && (HaveBullet > 0) && (ReloadedBulletCount != canReloadBulletCount)) // 장전중이 아니고 장전된 총알수가 최대장전수와 같지 않을때
        {
            Reloading = true;
            reloadText.SetActive(true);
            anim.SetTrigger("Reload");
            StartCoroutine(reload());
        }
    }
    IEnumerator reload()
    {        
        yield return new WaitForSeconds(1.7f);

        int needBulletToReload = canReloadBulletCount - ReloadedBulletCount; // 장전에 필요한 총알갯수        
        if(needBulletToReload > HaveBullet) // 장전에 필요한 총알이 가진 총알보다 많을 때
        {
            needBulletToReload = HaveBullet;      
        }
        HaveBullet -= needBulletToReload;
        ReloadedBulletCount += needBulletToReload;

        anim.SetBool("noBullet", false);
        noBullet = false;        
        reloadText.SetActive(false);
        Reloading = false;
    }

    public void BulletCountDecrease()
    {
        ReloadedBulletCount--;
        if (ReloadedBulletCount == 0)
        {
            noBullet = true;
            anim.SetBool("noBullet", true);
        }
    }

    public void UseItem()
    {
        shotHandgun();
    }

    public Sprite returnItemSprite()
    {
        return itemImagePrefab;
    }
}
