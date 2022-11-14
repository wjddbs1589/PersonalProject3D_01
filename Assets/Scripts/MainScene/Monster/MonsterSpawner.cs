using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Transform[] spawnPos;        //몬스터가 스폰될 위치
    public GameObject monsterPrefab;    //소환될 몬스터 프리펩
    private void Awake()
    {
        spawnPos = GetComponentsInChildren<Transform>();
    }
    private void Start()
    {
        spawnMonster();
        spawnMonster();
        spawnMonster();
    }
    public void spawnMonster()
    {
        int rand = Random.Range(1, 23);                    //랜덤으로 숫자를 뽑아
        Instantiate(monsterPrefab, spawnPos[rand]);        //숫자에 상응하는 위치에 몬스터 생성   
    }
}
