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

    public void OpenDoor()
    {
        anim.SetBool("Open",true);
    }
}