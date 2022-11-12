using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Transform[] spawnPos;
    public GameObject monsterPrefab;
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
        int rand = Random.Range(1, 23);
        Instantiate(monsterPrefab, spawnPos[rand]);           
    }
}
