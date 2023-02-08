using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionObject : MonoBehaviour
{
    // 소지중인 오일 갯수
    [SerializeField]int oilCount = 0;

    // 수리된 발전기 개수
    [SerializeField]int fixedGenerateCount = 0;

    // 잠군 가스밸브 개수
    [SerializeField]int lockedGasvalveCount = 0;

    // 미션 목표가 저장된 배열
    //0.기관실찾기
    //1.발전기 수리하기
    //2.가스밸브 잠그기
    //3.탈출선 연료 구하기
    [SerializeField]TextMeshProUGUI[] missions;

    private void Awake()
    {
        //제목을 제외한 나머지 텍스트만 배열로 저장
        missions = new TextMeshProUGUI[transform.childCount-1];
        for(int i = 0;i<transform.childCount-1; i++)
        {
            missions[i] = transform.GetChild(i+1).GetComponent<TextMeshProUGUI>();
        }
    }

    //1번째 미션. 기관실 찾으면 미션 갱신
    public void findMainroom()
    {
        missions[0].text = "기관실에 들어갈 방법 찾기";
    }
    //1번째 미션. 기관실을 찾았고, 발전기를 모두 가동시켜서 기관실 내에 레버를 작동 햇을때 미션 갱신
    public void useLever()
    {
        missions[0].text = "탈출구 찾기";
    }

    //2번째 미션 관리 함수
    public void fixGenerate()
    {
        fixedGenerateCount++;
        missions[1].text = $"발전기 수리하기({fixedGenerateCount}/4)";
        if (fixedGenerateCount == 5)
        {
            missions[1].text = $"<s>{missions[1].text}</s>";
        }      
    }


    //3번째 미션 관리 함수. 잠군 가스밸브의 개수를 증가시킴
    public void lockGasvalve()
    {
        lockedGasvalveCount++;
        missions[2].text = $"가스밸브 잠그기({lockedGasvalveCount}/5)";
        if (lockedGasvalveCount == 5)
        {
            missions[2].text = $"<s>{missions[2].text}</s>";
        }    
    }

    //4번째 미션 관리 함수. 획득한 오일 개수 증가
    public void gainOil()
    {
        oilCount++;
        missions[3].text = $"탈출용 우주션 연료 구하기({oilCount}/5)";
        if (oilCount == 5)
        {
            missions[3].text = $"<s>{missions[3].text}</s>";
        }      
    } 
}
