using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerSmall : MonoBehaviour
{
    ItemSpawnPos[] itemSpawnPos;
    public GameObject[] spawnPrefab;

    ItemManager itemManager;
    
    private void Awake()
    {
        spawnPrefab = new GameObject[6];
        itemSpawnPos = GetComponentsInChildren<ItemSpawnPos>();
    }


    private void Start()
    {
        itemManager = GameManager.Inst.ItemManager;
        for (int i = 0; i < spawnPrefab.Length; i++)
        {
            spawnPrefab[i] = itemManager.SavedItem[i];
        }

        int[] ItemNumber = new int[2];
        List<int> randNumList = new List<int>() { 1,2, 3, 4, 5, 6 };

        int randNum;  //중복없이 숫자 뽑기
        for (int i = 0; i < ItemNumber.Length; i++)
        {
            randNum = Random.Range(0, randNumList.Count);
            ItemNumber[i] = randNumList[randNum];
            if(ItemNumber[i] != 1)
            {
                // 현재 스폰된 수가 최대 스폰수 보다 적을 때, 아이템 생성
                if (itemManager.currentSpawnCount[ItemNumber[i] - 1] < itemManager.maxSpawnCount[ItemNumber[i] - 1])
                {
                    GameObject obj = Instantiate(spawnPrefab[ItemNumber[i] - 1]);
                    obj.transform.position = itemSpawnPos[i].transform.position;
                    itemManager.currentSpawnCount[ItemNumber[i] - 1]++;
                }
            }
            randNumList.RemoveAt(randNum);
        }
    }
}
