using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    private void Awake()
    {
        //홈화면에 갓다 왔을때 게임매니저를 초기화 함
        if(GameManager.Inst != null)
        {
            GameManager.Inst.instantiate();
        }
    }
}
