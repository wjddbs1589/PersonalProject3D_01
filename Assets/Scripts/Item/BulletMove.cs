using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float moveSpeed = 100.0f;
    Rigidbody rigid;
    public GameObject HitEffect;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        Destroy(gameObject, 5.0f);
    }
    private void Update()
    {
        rigid.MovePosition(transform.position + (transform.forward * moveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"총알이 {collision.transform.name}와 충돌 하였음");
        GameObject effect = Instantiate(HitEffect, collision.transform.position, collision.transform.rotation);
        effect.transform.parent = null;
        Destroy(gameObject);
    }

}
