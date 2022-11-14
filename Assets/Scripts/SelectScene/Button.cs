using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    /// <summary>
    /// 게임시작 버튼을 누르면 게임 씬으로 이동
    /// </summary>
    public void startButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    /// <summary>
    /// 게임종료 버튼을 누르면 프로그램 실행/디버깅 종료
    /// </summary>
    public void endButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif

    }
}
