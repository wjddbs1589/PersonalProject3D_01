using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Timeline;
using UnityEngine;

public class GeneratorSpawnPos : MonoBehaviour
{
    Transform[] allPosition;
    public Transform[] selectedPosition;
    int[] PositionNumber  = new int[4];
    List<int> randNumList = new List<int>() {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16};
    int randNum;
    private void Awake()
    {
        allPosition = GetComponentsInChildren<Transform>();
        moveGenerator();
    }

    void moveGenerator()
    { 
        //중복없이 숫자 뽑기
        for (int i = 0; i < PositionNumber.Length; i++)
        {
            randNum = Random.Range(1, randNumList.Count);
            PositionNumber[i] = randNumList[randNum];
            randNumList.RemoveAt(randNum);
            selectedPosition[i] = allPosition[PositionNumber[i]];
        }      

    }
}
