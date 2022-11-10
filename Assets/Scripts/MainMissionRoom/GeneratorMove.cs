using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorMove : MonoBehaviour
{
    [SerializeField] Generator[] Generators = new Generator[4];
    [SerializeField] GeneratorSpawnPos SpawnPos;   
    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Generators[i].transform.position = SpawnPos.selectedPosition[i].position;
            Generators[i].transform.rotation = SpawnPos.selectedPosition[i].rotation;
        }
    }

}
