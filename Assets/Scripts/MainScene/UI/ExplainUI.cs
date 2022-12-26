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

    private void PageChange(int nowPage, int beforePage)
    {
        explainBoard[nowPage].gameObject.SetActive(true);
        explainBoard[beforePage].gameObject.SetActive(false);
    }
}
