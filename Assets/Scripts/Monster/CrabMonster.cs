using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public enum monsterState
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
    Animator anim;
    //-----------------------------------
    float monsterHP = 50; 
    public float HP
    {
        get => monsterHP;
        set
        {
            monsterHP = value;
            if (monsterHP <= 0.0)
            {
                changeMonsterHP?.Invoke();
            }
        }
    }
    public System.Action changeMonsterHP;
    //----------------------------------
    monsterState monsterState;
    public monsterState MonsterState
    {
        get => monsterState;
        set
        {
            switch (value)
            {
                case monsterState.idle:
                    break;
                case monsterState.move:
                    break;
                case monsterState.recognition:
                    break;
                case monsterState.chase:
                    break;
                case monsterState.attack:
                    break;
                case monsterState.die:
                    break;
                default:
                    break;
            }
            monsterState = value;
        }
    }

    bool staying = false; // 머무르는 코루틴이 여러번 실행되는것 방지
    //-------------------------------------------
    float attackCoolTimeOrigin = 3.0f;
    float attackCoolTime = 0.0f;   

    //-------------------------------------------
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        changeMonsterHP += monsterDead;
        MonsterState = monsterState.idle;
    }

    private void monsterDead()
    {
        if (GameManager.Inst.MonsterDead == false)
        {
            MonsterState = monsterState.die;
            GameManager.Inst.MonsterDead = true;
            Destroy(gameObject);
        }
            
    }
    private void Update()
    {
        if (agent.pathPending) // navmesh가 도중에 경로를 재탐색 하여 거리가 0이 되는 경우를 방지. 경로가 계산될때까지 호출 무시
            return;
        switch (MonsterState)
        {
            case monsterState.idle: // 패트롤 지점에 도착 했을때
                if (!staying)
                {
                    staying = true;
                    StartCoroutine(stay());
                }                
                break;
            case monsterState.move: // 패트롤 지점으로 이동                
                Debug.Log(agent.remainingDistance);
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    Debug.Log("도착");
                    MonsterState = monsterState.idle;
                }  
                break;
            case monsterState.recognition: // 플레이어를 찾았을때
                int IntimidateType = Random.Range(1, 4);
                anim.SetInteger("FindPlayer", IntimidateType);
                MonsterState = monsterState.chase;
                break;
            case monsterState.chase: //플레이어 추격
                anim.SetInteger("FindPlayer", 0);
                agent.SetDestination(GameManager.Inst.Player.transform.position);
                if (agent.remainingDistance <= agent.stoppingDistance)
                { 
                    MonsterState = monsterState.attack;
                }
                break;
            case monsterState.attack:
                if(attackCoolTime <= 0)
                {
                    int AttackType = Random.Range(1, 6);
                    anim.SetInteger("FindPlayer", AttackType);
                    attackCoolTime = attackCoolTimeOrigin;
                }
                else
                {
                    attackCoolTime -= Time.deltaTime;
                }                
                break;
            case monsterState.die:
                anim.SetTrigger("Die");
                break;
            default:
                break;
        }        
    }

    IEnumerator stay()
    {
        anim.SetBool("Moving", false);
        yield return new WaitForSeconds(5.0f);
        if(MonsterState == monsterState.idle)
        {            
            MonsterState = monsterState.move;
            anim.SetBool("Moving", true);
            int randNum = Random.Range(1, 23);
            Transform destination = GameManager.Inst.MonsterSpawner.spawnPos[randNum];
            Debug.Log(destination.position);
            agent.SetDestination(destination.position);
            staying = false;
        }
    }
}
