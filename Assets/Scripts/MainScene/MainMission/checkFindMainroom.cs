using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkFindMainroom : MonoBehaviour
{
    //플레이어가 기관실 찾기 미션을 완료했는지 확인하기 위한 코드

    // 기관실 앞쪽 부분에 존재하는 콜라이더와 닿았을때 미션 갱신시킴
    private void OnTriggerEnter(Collider other)
    {
        //플레이어가 닿으면
        if (other.CompareTag("Player"))
        {
            GameManager.Inst.MissionObject.findMainroom();
        }
    }
}
