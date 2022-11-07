using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
enum monsterState
{
    idle=0,
    move,
    recognition,
    chase,
    attack,
    die
}

public class CrabMonster : MonoBehaviour
{
    NavMeshAgent agent;
    Transform destination;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = GameObject.Find("destination").transform;
        agent.destination = destination.position;
    }
}
