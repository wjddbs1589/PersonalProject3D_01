using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{    
    //카메라를 초당 5도 회전 시킴
    void Update()
    {
        transform.Rotate(0,5 * Time.deltaTime,0);
    }
}
