using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{    
    void Update()
    {
        transform.Rotate(0,5 * Time.deltaTime,0);
    }
}
