using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopMenu : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);    
    }
    /// <summary>
    /// 게임 재개 
    /// </summary>
    public void resume()
    {        
        GameManager.Inst.Player.offMenu();
    }
    /// <summary>
    /// 홈 화면으로 이동
    /// </summary>
    public void goToHome()
    {
        GameManager.Inst.Player.offMenu();
        SceneManager.LoadScene("SelectScene");
    }

    /// <summary>
    /// 도움말 보기
    /// </summary>
    public void openHelpBoard()
    {        
        GameManager.Inst.HelpBoard.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
