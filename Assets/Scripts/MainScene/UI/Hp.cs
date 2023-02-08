using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hp : MonoBehaviour
{
    Player player;
    TextMeshProUGUI text;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        text = transform.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        player.HpChange += hpBarReset; //hp값이 변경될때 실행됨
    }

    // 플레이어의 체력에 따라 색상을 변경
    private void hpBarReset(float Hp)
    {   
        if (player.HP > 30.0f) //hp가 30보다 크면 
        {
            text.color = Color.white; //흰색으로 표시
        }
        else if (player.HP > 15.0f) //15보다 크면
        {
            text.color = Color.yellow; //노란색으로 표시
        }
        else //아니면 빨간색으로 표시
        {
            text.color = Color.red;
        }

        text.text = $"{Hp:0}"; // 표기될 HP 설정
    }
}

