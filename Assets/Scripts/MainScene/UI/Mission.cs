using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mission : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        
    }
}
