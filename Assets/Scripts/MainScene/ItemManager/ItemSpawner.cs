using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    ItemSpawnPos[] itemSpawnPos; //아이템이 스폰될 위치 배열
    GameObject[] spawnPrefab;    //스폰될 아이템 프리펩 배열

    ItemManager itemManager;

    private void Awake()
    {
        spawnPrefab = new GameObject[6]; 
        itemSpawnPos = GetComponentsInChildren<ItemSpawnPos>();
    }


    private void Start()
    {
        itemManager = GameManager.Inst.ItemManager;
        for (int i = 0; i < spawnPrefab.Length; i++) // 스폰될 아이템 프리펩에 아이템들 저장
        {
            spawnPrefab[i] = itemManager.SavedItem[i];
        }

        int[] ItemNumber = new int[2]; // 크기2짜리 숫자배열 생성
        List<int> randNumList = new List<int>() { 1, 2, 3, 4, 5, 6 }; // 1 2 3 4 5 6을 가진 리스트 생성

        int randNum;  //중복없이 숫자 뽑기
        for (int i = 0; i < ItemNumber.Length; i++) // 숫자배열의 길이만큼 반복하여
        {
            randNum = Random.Range(0, randNumList.Count); //0에서 5(숫자리스트갯수(6)-1)까지의 숫자를 랜덤으로 뽑음
            ItemNumber[i] = randNumList[randNum];         // 숫자 배열에 랜덤으로 선택된 아이템 저장
            if (ItemNumber[i] != 1) //randNumList[i]번째의 수가 1이 아니면. 즉, randNum이 0이 아니라면
            {
                // 현재 스폰된 수가 최대 스폰수 보다 적을 때, 아이템 생성
                if (itemManager.currentSpawnCount[ItemNumber[i] - 1] < itemManager.maxSpawnCount[ItemNumber[i] - 1])
                {
                    itemManager.currentSpawnCount[ItemNumber[i] - 1]++; //스폰된 아이템의 스폰카운트 증가
                    GameObject obj = Instantiate(spawnPrefab[ItemNumber[i] - 1], itemSpawnPos[i].transform.position, transform.rotation); // 생성된 아이템을 아이템 스포너와 동일한 방향으로 회전시킴
                    obj.transform.position = itemSpawnPos[i].transform.position; // i번째 스폰 포인트에 위치로 이동시킴
                    obj.transform.parent = this.transform;  //생성된 아이템을 스포너의 자식으로 넣음
                }
            }           
            randNumList.RemoveAt(randNum); // 리스트에서 선택된 숫자 제거
        }
    }
}
