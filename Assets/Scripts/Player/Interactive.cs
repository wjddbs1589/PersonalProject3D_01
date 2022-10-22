using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Useable"))
        {
            Debug.Log(collision.transform.name);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Useable"))
        {
            Debug.Log(other.name);            
        }        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Useable"))
        {
            Debug.Log(other.name);
        }
    }
}
