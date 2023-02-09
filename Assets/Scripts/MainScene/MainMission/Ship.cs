using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour, UseableObject
{    
    float chargedOil = 0;
    ItemManager itemManager;    
    private void Start()
    {
        itemManager = GameManager.Inst.ItemManager;
    }
    public void objectInteractive()
    {
        //주유된 오일이 5개 미만일 때
        if(chargedOil < 5)
        {
            //인벤토리에 오일이 0개보다 많으면
            if (itemManager.currentItemCount[(int)Itemlist.Oil] > 0)
            {
                chargedOil += 1;                             //충전된 오일 갯수 증가
                itemManager.decreaseItemCount(Itemlist.Oil); //오일 아이템 갯수 감소

                //오일 아이템이 남아있지 않으면
                if (itemManager.currentItemCount[(int)Itemlist.Oil] == 0) 
                {
                    itemManager.ItemDelete(Itemlist.Oil);  //인벤토리에서 삭제
                }
            }
        }
        else // 연료가 모두 채워졌을 때
        {
            SceneManager.LoadScene("SelectScene"); // 처음씬으로 이동
        }
    }


    public string objectName()
    {
        //기름이 모두 채워지지 않았으면
        if(chargedOil < 5)
        {
            return $"연료 : {chargedOil}/5";
        }
        else //기름이 전부 채워졌으면
        {
            return "탈출";
        }
        
    }

    public Sprite returnItemSprite()
    {
        return null;
    }

    public void UseItem()
    {

    }
}
