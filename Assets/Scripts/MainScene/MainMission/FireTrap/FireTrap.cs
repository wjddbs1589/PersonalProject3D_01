using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UIElements;

public class FireTrap : MonoBehaviour
{
    ParticleSystem particle; 
    SphereCollider col;

    float valveCount = 0;
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

    void CheckValveUse(float valveCount)
    {
        if (valveCount == 5)
        {
            StartCoroutine(TrapStop());
        }
    }

    IEnumerator TrapStop()
    {
        yield return new WaitForSeconds(5.0f);
        particle.Stop();
        col.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {     
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name);
            other.transform.GetComponent<HealthInfoManager>().takeDamage(1000.0f);
        }
    }

}
