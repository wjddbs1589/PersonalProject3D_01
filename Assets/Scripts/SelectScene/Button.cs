using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;   // 게임 창 밖으로 마우스가 안나감, 마우스를 게임 중앙 좌표에 고정시키고 숨김
        Cursor.visible = true;
    }
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
