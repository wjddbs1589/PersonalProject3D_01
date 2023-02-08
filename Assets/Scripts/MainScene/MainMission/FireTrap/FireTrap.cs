using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireTrap : MonoBehaviour
{
    ParticleSystem particle; 
    SphereCollider col;

    float valveCount = 0; //사용된 밸브 갯수
    public float ValveCount
    {
        get => valveCount;
        set
        {
            valveCount = Mathf.Clamp(value,0,5);
            ChangeValveCount?.Invoke(value);
        }
    }
    Action<float> ChangeValveCount;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        col = GetComponent<SphereCollider>();
    }
    private void Start()
    {
        ChangeValveCount += CheckValveUse;
    }
    //밸브사용여부 체크
    void CheckValveUse(float valveCount)
    {
        //모든 밸브를 사용했으면
        if (valveCount == 5)
        {
            StartCoroutine(TrapStop()); //함정을 끄는 코루틴 실행
        }
    }

    IEnumerator TrapStop()
    {
        yield return new WaitForSeconds(5.0f); //5초이후에
        particle.Stop();                       //파티클 시스템 멈춤
        col.enabled = false;                   //콜라이더 비활성화
    }

    private void OnTriggerEnter(Collider other)
    {     
        //플레이어가 닿으면
        if (other.CompareTag("Player"))
        {
            other.transform.GetComponent<HealthInfoManager>().takeDamage(1000.0f); //1000데미지를 줌
        }
    }

}
