using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpBoard : MonoBehaviour
{
    public TextMeshProUGUI pageNumber;  

    int currentPage = 0; // 현재 페이지
    int maxPage = 7;
    public Action<int,int> onPageChange;
    private void Start()
    {
        GameManager.Inst.HelpBoard.gameObject.SetActive(false); // 게임 시작시 숨김
    }

    /// <summary>
    /// 이전 페이지로 이동
    /// </summary>
    public void pageDown()
    {
        if(currentPage <= 6 && currentPage > 0)
        {
            currentPage--;
            onPageChange?.Invoke(currentPage, currentPage+1);
            pageNumber.text = $"{currentPage+1}/{maxPage}";
        }
    }
    /// <summary>
    /// 다음 페이지로 이동
    /// </summary>
    public void pageUp()
    {
        if (currentPage < 6 && currentPage >= 0)
        {
            currentPage++;
            onPageChange?.Invoke(currentPage, currentPage-1);
            pageNumber.text = $"{currentPage+1}/{maxPage}";
        }
    }

    /// <summary>
    /// 도움말 닫기
    /// </summary>
    public void closeHelp()
    {
        GameManager.Inst.usingHelp = false;
        GameManager.Inst.StopMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
