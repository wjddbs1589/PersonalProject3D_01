using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainBullet : MonoBehaviour, UseableObject
{
    Handgun bullet;
    public Sprite itemImagePrefab;
    private void Awake()
    {
        bullet = GameObject.Find("Handgun").gameObject.GetComponent<Handgun>();       
    }

    /// <summary>
    /// 아이템 상호작용시 총알 획득, 현재 소지량에 따라 최대치를 넘길 수 없음
    /// </summary>
    public void objectIneractive()
    {
        if(bullet.HaveBullet < bullet.MaxBullet)
        {
            bullet.HaveBullet += 15;
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 커서를 가져다 댔을 때 아이템의 이름을 표시
    /// </summary>
    /// <returns>총알이 최대치가 아니면 "총알", 최대치 일땐 소지할수 없음을 반환</returns>
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

    public Sprite returnItemSprite()
    {
        return itemImagePrefab;
    }
}
