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
        sliderRate = player.CurrentStamina / player.MaxStamina;
        slider.value = sliderRate;
        fill.color = Color.Lerp(Color.red,Color.green, sliderRate);
    }
}
