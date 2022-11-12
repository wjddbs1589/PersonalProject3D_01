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
        player.HpChange += hpBarReset;
    }
    private void hpBarReset(float Hp)
    {        
        if(player.HP < 16.0f)
        {
            text.color = Color.red;
        }
        else if(player.HP < 30.0f)
        {
            text.color = Color.yellow;
        }
        else
        {
            text.color = Color.white;
        }
        text.text = $"{Hp:0}";
    }
}
