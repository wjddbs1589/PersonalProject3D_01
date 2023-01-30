using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplainUI : MonoBehaviour
{
    [SerializeField]GameObject[] explainBoard;
    private void Awake()
    {
        explainBoard = new GameObject[7];
        for(int i = 0; i < 7; i++)
        {
            explainBoard[i] = transform.GetChild(i).gameObject;
            
        }
    }
    private void Start()
    {
        GameManager.Inst.HelpBoard.onPageChange += PageChange;
    }

    /// <summary>
    /// 다음 페이지 활성화, 이전 페이지 비활성화 시키는 함수
    /// </summary>
    /// <param name="nowPage">활성화될 페이지</param>
    /// <param name="beforePage">비활성화 될 페이지</param>
    private void PageChange(int nowPage, int beforePage)
    {
        explainBoard[nowPage].gameObject.SetActive(true);
        explainBoard[beforePage].gameObject.SetActive(false);
    }
}
