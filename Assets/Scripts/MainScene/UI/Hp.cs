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

    private void hpBarReset(float Hp)
    {        
        if(player.HP < 16.0f) //hp가 16보다 작으면 
        {
            text.color = Color.red; //적색으로 표시
        }
        else if(player.HP < 30.0f) //30보다 적으면
        {
            text.color = Color.yellow; //노란색으로 표시
        }
        else //아니면 흰색으로 표시
        {
            text.color = Color.white;
        }
        text.text = $"{Hp:0}"; // hp가 몇인지 설정
    }
}
