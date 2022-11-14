using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRoomDoor : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    /// <summary>
    /// 문 열기 애니메이션 재생
    /// </summary>
    public void OpenDoor()
    {
        anim.SetBool("Open",true);
    }
}