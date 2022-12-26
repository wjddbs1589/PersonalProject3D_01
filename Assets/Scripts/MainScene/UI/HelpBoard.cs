using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpBoard : MonoBehaviour
{
    public TextMeshProUGUI pageNumber;  

    int currentPage = 1; // 현재 페이지

    private void Start()
    {
        GameManager.Inst.HelpBoard.gameObject.SetActive(false); // 게임 시작시 숨김
    }

    /// <summary>
    /// 이전 페이지로 이동
    /// </summary>
    public void pageDown()
    {
        if(currentPage < 6 && currentPage > 1)
        {
            currentPage--;
            pageNumber.text = $"{currentPage}/5";
            Debug.Log("이전 페이지로 이동");
        }
    }
    /// <summary>
    /// 다음 페이지로 이동
    /// </summary>
    public void pageUp()
    {
        if (currentPage > 0 && currentPage < 5)
        {
            currentPage++;
            pageNumber.text = $"{currentPage}/5";
            Debug.Log("다음 페이지로 이동");
        }
    }

    /// <summary>
    /// 도움말 닫기
    /// </summary>
    public void closeHelp()
    {
        gameObject.SetActive(false);
        Debug.Log("창을 닫습니다.");
        GameManager.Inst.StopMenu.gameObject.SetActive(true);
    }
}
