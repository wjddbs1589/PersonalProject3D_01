using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorMove : MonoBehaviour
{
    [SerializeField] Generator[] Generators = new Generator[4]; //제네레이터 배열
    [SerializeField] GeneratorSpawnPos SpawnPos;                //제네레이터 생성 위치
    private void Start()
    {
        //각 제네레이터 들을 랜덤한 위치에 놓고 방향돌림
        for (int i = 0; i < 4; i++)
        {
            Generators[i].transform.position = SpawnPos.selectedPosition[i].position;
            Generators[i].transform.rotation = SpawnPos.selectedPosition[i].rotation;
        }
    }

}
