using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEditor;
using Cinemachine.Utility;

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
    Vector3 targetPos;
    GameObject target;
    float sightRange = 7.0f; 
    float sightAngle = 90.0f;   //-45 ~ +45 범위

    float attackCoolTimeOrigin = 3.0f;
    float attackCoolTime = 0.0f;

    bool useRecognizeAnimation = true;

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
        // 인식 애니메이션을 사용중일땐 일반행동 불가
        if(useRecognizeAnimation)
        {
            switch (MonsterState)
            {
                case monsterState.idle: // 패트롤 지점에 도착 했을때
                    idle();
                    break;
                case monsterState.move: // 패트롤 지점으로 이동       
                    move();
                    break;
                case monsterState.recognition: // 플레이어를 찾았을때
                    recognizePlayer();
                    break;
                case monsterState.chase: //플레이어 추격
                    ChasePlayer();
                    break;
                case monsterState.attack:
                    attack();
                    break;
                case monsterState.die:
                    anim.SetTrigger("Die");
                    break;
                default:
                    break;
            }
        }   
    }

    //기본 상태-----------------------------------------------------------------------------------------------------------------------------------------------
    void idle()
    {
        SearchPlayer();
        if (!staying)
        {
            agent.radius = 0.75f;
            staying = true;
            StartCoroutine(stay());
        }
    }
    IEnumerator stay()
    {
        anim.SetBool("Moving", false);
        yield return new WaitForSeconds(5.0f);
        //몬스터가 아직 기본상태이면 이동상태로 변경
        if(MonsterState == monsterState.idle)
        {            
            MonsterState = monsterState.move;
            anim.SetBool("Moving", true);
            int randNum = Random.Range(1, 23);
            Transform destination = GameManager.Inst.MonsterSpawner.spawnPos[randNum];
            agent.SetDestination(destination.position);
            staying = false;
        }
    }

    //이동 상태-----------------------------------------------------------------------------------------------------------------------------------------------
    void move()
    {
        SearchPlayer();
        if ( agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.radius = 1.0f;
            MonsterState = monsterState.idle;
        }
    }

    //플레이어 탐색-----------------------------------------------------------------------------------------------------------------------------------------------
    void SearchPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, sightRange, LayerMask.GetMask("Player"));        
        if(colliders.Length > 0) // 감지거리 내에 플레이어가 Player라는 레이어를 가진 콜라이더가 존재할 때
        {
            Vector3 targetPosition = colliders[0].transform.position; // 콜라이더의 위치정보 가져옴
            
            if (InSightAngle(targetPosition)) // 플레이어의 현재 위치가 시야각 내에 있는지 확인
            {
                if (!BlockByWall(targetPosition)) // 플레이어의 현재 위치가 벽을 사이에 두고 있는지 확인
                {
                    targetPos = targetPosition;
                    target = colliders[0].gameObject;
                    Debug.Log("시야내에서 발견됨");
                    MonsterState = monsterState.recognition;
                }
            }
            if((targetPosition-transform.position).sqrMagnitude < (sightRange*0.5)* (sightRange * 0.5)) // 몬스터와 가까운 거리에 있으면
            {
                targetPos = targetPosition;
                Debug.Log("근처에서 발견됨");
                target = colliders[0].gameObject;
                MonsterState = monsterState.recognition;
            }
        }
    }   

    //타겟이 시야내에 있는지 확인
    bool InSightAngle(Vector3 targetPosition)
    {
        float angle = Vector3.Angle(transform.forward, targetPosition - transform.position); // transform.forward와 targetPosition - transform.position의 사이각 반환
        return (sightAngle * 0.5f) > angle; // 시야각이 90도 이므로 +-45각도확인
    }
    //타겟이 벽을 사이에 두고 있는지 확인
    bool BlockByWall(Vector3 targetPosition)
    {
        bool result = true;
        Ray ray = new(transform.position, targetPosition - transform.position); // 레이 만들기(시작점, 방향)
        ray.origin += Vector3.up * 0.5f;    // 몬스터의 눈높이로 레이 시작점을 높임        
        if (Physics.Raycast(ray, out RaycastHit hit, LayerMask.GetMask("Player")))
        {
            result = false;
        }

        return result; 
    }

    //플레이어 인식-----------------------------------------------------------------------------------------------------------------------------------------------
    
    void recognizePlayer()
    {
        useRecognizeAnimation = false;
        agent.SetDestination(target.transform.position);
        agent.speed = 0.0f;
        Debug.Log($"recognize:{useRecognizeAnimation}=>인식애니메이션 재생");
        int IntimidateType = Random.Range(1, 4);
        anim.SetInteger("FindPlayer", IntimidateType);
    }
    void changeToChase()
    {
        MonsterState = monsterState.chase;
        useRecognizeAnimation = true;
        anim.SetInteger("FindPlayer", 0);
        agent.speed = 5.0f;
    }

    //플레이어 추격-----------------------------------------------------------------------------------------------------------------------------------------------
    void ChasePlayer()
    {
        agent.SetDestination(target.transform.position);
        //anim.SetInteger("FindPlayer", 0);
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            MonsterState = monsterState.attack;
        }
    }
    //공격 -----------------------------------------------------------------------------------------------------------------------------------------------
    void attack()
    {
        agent.SetDestination(target.transform.position);
        anim.SetBool("Moving", true);
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            anim.SetBool("Moving", false);
            if (attackCoolTime <= 0)
            {
                Debug.Log("플레이어 공격");
                int AttackType = Random.Range(1, 6);
                switch (AttackType)
                {
                    case 1:
                        anim.SetTrigger("Attack1");
                        break;
                    case 2:
                        anim.SetTrigger("Attack2");
                        break;
                    case 3:
                        anim.SetTrigger("Attack3");
                        break;
                    case 4:
                        anim.SetTrigger("Attack4");
                        break;
                    case 5:
                        anim.SetTrigger("Attack5");
                        break;
                }
                attackCoolTime = attackCoolTimeOrigin;
            }
            else
            {
                attackCoolTime -= Time.deltaTime;
            }
        }

        //if (Vector3.SqrMagnitude(target.transform.position - transform.position) <= agent.stoppingDistance)
        //{
        //    Debug.Log("타겟이 이동하였습니다. 추격합니다.");
        //    MonsterState = monsterState.chase;
        //}

    }
    // 시야범위 및 탐지범위 표시-----------------------------------------------------------------------------------------------------------------------------------------------
    private void OnDrawGizmos()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, transform.up, sightRange);

        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, transform.up, (sightRange*0.5f));

        //시야각도만큼 gizmo 그리기
        Handles.color = Color.red;
        Vector3 forward = transform.forward * sightRange;
        Quaternion q1 = Quaternion.Euler(0.5f * sightAngle * transform.up);
        Quaternion q2 = Quaternion.Euler(-0.5f * sightAngle * transform.up);
        Handles.DrawLine(transform.position, transform.position + q1 * forward);    // 시야각 오른쪽 끝
        Handles.DrawLine(transform.position, transform.position + q2 * forward);    // 시야각 왼쪽 끝
        // 전체 시야범위
        Handles.DrawWireArc(transform.position,  //선을 그릴 중심점
            transform.up,                        //회전축
            q2 * transform.forward,              //출발점 에서 우측  
            sightAngle,                          //표시할 각도
            sightRange,                          //반지름
            5.0f);                               //선 두께
    }
}
