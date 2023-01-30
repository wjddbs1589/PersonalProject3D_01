using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Handgun : MonoBehaviour, UseableObject
{
    float damage = 15.0f;
    float originDelay = 0.3f;
    float shotDelay = 0.3f;
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
            changeBullet?.Invoke();
        }
    }
    public Action changeBullet;
    //----------------------------------------------------------------------------
    int haveBullet = 0;  // 소지한 총알 개수
    public int HaveBullet
    {
        get => haveBullet;
        set
        {
            haveBullet = Mathf.Clamp(value, 0, MaxBullet);
            changeBullet?.Invoke();   
        }
    }
    public Action changeHaveBullet;
    //----------------------------------------------------------------------------
    private void Awake()
    {
        anim = GetComponent<Animator>();
        reloadText = GameObject.Find("reloadText").gameObject;
        reloadText.SetActive(false);
    }
    void Update()
    {
        //재 사격 딜레이가 남아 있으면
        if(shotDelay >= 0.0f)
        {
            shotDelay -= Time.deltaTime; // 발사 딜레이 감소시킴
            shotDelay = Mathf.Clamp(shotDelay, 0.0f, originDelay); // 발사딜레이가 최소 0 최대 originDelay범위 내에 잇도록 설정
        }
    }
    public void objectIneractive()
    {
        shotHandgun();
    }

    /// <summary>
    /// 아이템의 이름 반환
    /// </summary>
    /// <returns>아이템의 이름</returns>
    public string objectName()
    {
        return "권총";
    }

    /// <summary>
    /// 핸드건 사격
    /// </summary>
    public void shotHandgun()
    {
        if (shotDelay <= 0.0f && !Reloading)  // 사격 딜레이가 다 돌았고 재장전중이 아닐때
        {
            if (!noBullet) // 총알이 없는 상태가 아니면
            {
                Ray ray = new(transform.position, transform.forward);                               //이 트랜스폼의 위치에서 트랜스 폼의 앞방향으로 ray설정
                if(Physics.Raycast(ray, out RaycastHit hit, 1000.0f, LayerMask.GetMask("Monster"))) //ray에 저장된것을 토대로 생성하여 1000사거리 내의 Monster 레이어를 가진 대상이 ray에 닿으면 true반환
                {
                    hit.transform.GetComponent<HealthInfoManager>().takeDamage(damage);  //맞은 대상에게 데미지 만큼 체력을 감소시킴
                }
                Debug.DrawRay(transform.position, transform.forward * 1000.0f, Color.green); //ray를 그려줌
                shotDelay = originDelay;    // 발사 딜레이 리셋
                anim.SetTrigger("Shot");    // 애니메이션 트리거 발동하여 애니메이션 재생
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
            Reloading = true;           // 재장선 상태로 변경
            reloadText.SetActive(true); // 재장전 문구 띄움
            anim.SetTrigger("Reload");  // 애니메이션 재생
            StartCoroutine(reload());   // 재장전 코루틴 함수 실행
        }
    }
    IEnumerator reload()
    {        
        yield return new WaitForSeconds(1.7f);

        int needBulletToReload = canReloadBulletCount - ReloadedBulletCount; // 장전에 필요한 총알갯수 저장       
        if(needBulletToReload > HaveBullet) // 장전에 필요한 총알이 가진 총알보다 많을 때
        {
            needBulletToReload = HaveBullet;   //남은 총알을 모두 장전하게 한다
        }
        HaveBullet -= needBulletToReload;          // 가진 총알에서 장전에 필요한 총알 수 만큼 감소
        ReloadedBulletCount += needBulletToReload; // 장전된 총알에 장전에 필요한 수만큼 증가

        anim.SetBool("noBullet", false);    // 애니메이션 변경 
        noBullet = false;                   // 장전했으므로 상태 변경
        reloadText.SetActive(false);        // 재장전 문구 숨김
        Reloading = false;                  // 재장전이 끝났으므로 상태변경
    }   

    // 총알이 감소하는 함수
    public void BulletCountDecrease()
    {
        ReloadedBulletCount--; // 장전된 총알의 개수 감소
        if (ReloadedBulletCount == 0)// 총알이 모두 소진되면
        {
            noBullet = true;                // 총알상태 변경
            anim.SetBool("noBullet", true); // 총의 애니메이션 변경
        }
    }

    //아이템 사용시
    public void UseItem()
    {
        shotHandgun(); //총을 발사하는 함수 호출
    }

    /// <summary>
    /// 현재 아이템이 가지고있는 sprite반환
    /// </summary>
    /// <returns>현재 아이템이 가지고있는 sprite</returns>
    public Sprite returnItemSprite()
    {
        return itemImagePrefab;
    }
}
