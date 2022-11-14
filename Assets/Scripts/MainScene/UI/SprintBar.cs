using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SprintBar : MonoBehaviour
{
    Player player;
    Slider slider;
    Image fill;
    
    float sliderRate;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        slider = GetComponent<Slider>();
        fill = slider.fillRect.GetComponent<Image>();
    }
    
    private void Update()
    {
        sprint();
    }
    public void sprint()
    {        
        sliderRate = player.CurrentStamina / player.MaxStamina; //현재 스태미너의 남아있는 비율
        slider.value = sliderRate; //슬라이더를 비율만큼 조정함
        fill.color = Color.Lerp(Color.red,Color.green, sliderRate); //비율이 낮을수록 적색 높을수록 녹색으로 설정
    }
}
