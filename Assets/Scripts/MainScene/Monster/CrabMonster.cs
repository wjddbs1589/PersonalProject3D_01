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

public class CrabMonster : MonoBehaviour, HealthInfoManager
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
                MonsterState = monsterState.die;
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
    GameObject target;
    float sightRange = 7.0f;    //시야 범위
    float sightAngle = 90.0f;   //-45 ~ +45 범위

    float attackCoolTimeOrigin = 2.0f;  //기본 공격 쿨타임
    float attackCoolTime = 0.0f;        //남은 공격 쿨타임
    float attackDamage = 30.0f;         //공격력
    bool useRecognizeAnimation = true;  //인식 애니메이션 재생 여부
    bool alive = true;                  //몬스터의 생존 여부
    Collider capsuleCol;

    Transform destination;
    float fixedSpeed = 0.0f; //멈추기 속도
    float idleSpeed = 5.0f;  //기본 속도
    float chaseSpeed = 7.0f; //추격 속도
    //-------------------------------------------
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        capsuleCol = GetComponent<Collider>();
    }
    private void Start()
    {
        MonsterState = monsterState.idle;
    }

   
    void Update()
    {
        // navmesh가 도중에 경로를 재탐색 하여 거리가 0이 되는 경우를 방지.
        // 경로가 계산될때까지 호출 무시
        if (agent.pathPending) 
            return;

        if (alive)
        {
            // 인식 애니메이션을 사용중일땐 일반행동 불가
            if (useRecognizeAnimation)
            {
                switch (MonsterState) //현재 몬스터의 상태에 따라
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
                    case monsterState.chase: //추격
                        ChasePlayer();
                        break;
                    case monsterState.attack: //공격
                        attack();
                        break;
                    case monsterState.die: //몬스터 사망
                        monsterDead();
                        break;
                    default:
                        break;
                }
            }
        }        
    }

    //기본 상태-----------------------------------------------------------------------------------------------------------------------------------------------
    void idle()
    {
        SearchPlayer();  // 플레이어를 탐색
        if (!staying)    // 현재 머무르는중이 아니면
        { 
            staying = true;         // 멈춤상태로 변경
            StartCoroutine(stay()); // 코루틴 실행
        }
    }
    IEnumerator stay()
    {
        anim.SetBool("Moving", false);         // 애니메이션 변경
        yield return new WaitForSeconds(5.0f); // 5초이후

        //몬스터가 아직 기본상태이면 이동상태로 변경
        if(MonsterState == monsterState.idle)
        {            
            MonsterState = monsterState.move;                                // 몬스터를 이동상태로 변경
            anim.SetBool("Moving", true);                                    // 이동 애니메이션 재생
            int randNum = Random.Range(1, 23);                               // 1에서22사이의 숫자를 뽑음
            destination = GameManager.Inst.MonsterSpawner.spawnPos[randNum]; // 선택된 숫자번째의 위치를 목적지로 저장
            agent.SetDestination(destination.position);                      // 목적지 지정
            staying = false;                                                 // 멈춤상태 취소
        }
    }

    //이동 상태-----------------------------------------------------------------------------------------------------------------------------------------------
    void move()
    {
        SearchPlayer();  //플레이어 탐색

        //남은거리가 멈춤거리보다 적으면
        if ( agent.remainingDistance <= agent.stoppingDistance) 
        {
            MonsterState = monsterState.idle; //기본상태로 변경
        }
    }

    //플레이어 탐색-----------------------------------------------------------------------------------------------------------------------------------------------
    void SearchPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, sightRange, LayerMask.GetMask("Player"));

        // 감지거리 내에 플레이어가 Player라는 레이어를 가진 콜라이더가 존재할 때
        if (colliders.Length > 0) 
        {
            Vector3 targetPosition = colliders[0].transform.position; // 콜라이더의 위치정보 가져옴

            // 플레이어의 현재 위치가 시야각 내에 있는지 확인
            if (InSightAngle(targetPosition)) 
            {
                // 플레이어의 현재 위치가 벽을 사이에 두고 있는지 확인
                if (!BlockByWall(targetPosition)) 
                {
                    target = colliders[0].gameObject;
                    Debug.Log("시야내에서 발견됨");
                    MonsterState = monsterState.recognition;
                }
            }
            // 몬스터와 가까운 거리에 있으면
            else if ((targetPosition-transform.position).sqrMagnitude < (sightRange*0.5)* (sightRange * 0.5)) 
            {
                Debug.Log("근처에서 발견됨");
                target = colliders[0].gameObject;
                MonsterState = monsterState.recognition;
            }
        }
    }   
    
    //타겟이 시야 내에 있는지 확인
    bool InSightAngle(Vector3 targetPosition)
    {
        // transform.forward와 targetPosition - transform.position의 사이각 반환
        float angle = Vector3.Angle(transform.forward, targetPosition - transform.position);

        return (sightAngle * 0.5f) > angle; // 시야각이 90도 이므로 +-45각도확인
    }
    /// <summary>
    /// 타겟과 이 오브젝트 사이에 다른 물체가 있는지 학인
    /// </summary>
    /// <param name="targetPosition">타겟의 위치</param>
    /// <returns>다른 물체가 있으면 true, 없으면 false</returns>
    bool BlockByWall(Vector3 targetPosition)
    {
        bool result = true;
        Ray ray = new(transform.position, targetPosition - transform.position); // Ray 만들기(시작점, 방향)

        // 몬스터의 눈높이로 레이 시작점을 높임 
        ray.origin += Vector3.up * 0.5f;
        
        if (Physics.Raycast(ray, out RaycastHit hit, LayerMask.GetMask("Player")))
        {
            result = false;
        }

        return result; 
    }

    //플레이어 인식
    void recognizePlayer()
    {
        useRecognizeAnimation = false;                  // 인식 애니메이션 재생 여부 
        anim.SetBool("Moving", true);                   // 애니메이션 재생 준비
        transform.LookAt(target.transform.position);    // 플레이어를 바라봄
        agent.speed = fixedSpeed;                       // 위치 고정
        int IntimidateType = Random.Range(1, 3);            
        anim.SetInteger("FindPlayer", IntimidateType);  // 인식 애니메이션 재생
    }
    //애니메이션에 포함된 함수.
    //애니메이션 종료후 상태를 추격상태로 변경
    void changeToChase()
    {
        MonsterState = monsterState.chase;  //추격상태로 변경
        useRecognizeAnimation = true;
        anim.SetInteger("FindPlayer", 0);
        agent.speed = chaseSpeed;  //추격속도로 변경
    }

    //플레이어 추격
    float chaseTime = 10.0f;
    float originChaseTime = 10.0f;
    void ChasePlayer()
    {
        agent.SetDestination(target.transform.position); //목적지를 타겟의 위치로 변경

        //거리가 가까워지면
        if (agent.remainingDistance <= agent.stoppingDistance) 
        {
            MonsterState = monsterState.attack; //공격 상태로 변경
        }

        // 남은 거리가 멈춤거리의 1.5배 이상일 경우
        if (agent.remainingDistance > agent.stoppingDistance * 1.5f) 
        {
            chaseTime -= Time.deltaTime; //추격시간 감소

            // 추격시간이 0이하일때
            if (chaseTime <= 0) 
            {
                // 목적지가 없으면 랜덤으로 목적지 지정
                if (destination == null) 
                {
                    int randNum = Random.Range(1, 23);
                    destination = GameManager.Inst.MonsterSpawner.spawnPos[randNum];
                }
                agent.SetDestination(destination.position); //목적지로 이동
                MonsterState = monsterState.idle;           //기본상태로 변경
                agent.speed = idleSpeed;                    //기본속도로 변경
                chaseTime = originChaseTime;                //추격시간 초기화
            }
        }
    }

    //공격 
    void attack()
    {        
        agent.SetDestination(target.transform.position); // 타겟의 위치로 목적지 설정
        transform.LookAt(target.transform.position);     // 타겟을 바라봄
        anim.SetBool("Moving", true);   //이동 멈춤

        //거리가 가까우면
        if (agent.remainingDistance <= agent.stoppingDistance)  
        {            
            chaseTime = originChaseTime; //추격시간 초기화
            anim.SetBool("Moving", false);  //이동 멈춤

            //공격 쿨타임이 다 돌았을때
            if (attackCoolTime <= 0)
            {
                int AttackType = Random.Range(1, 6);//랜덤으로 숫자뽑고

                //숫자에 따라 공격모션 실행
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
                attackCoolTime = attackCoolTimeOrigin; //공격 쿨타임 초기화
            }
            else
            {
                attackCoolTime -= Time.deltaTime;  //공격 쿨타임 감소
            }
        }
        else
        {
            MonsterState = monsterState.chase;
        }                
    }
    private void OnTriggerEnter(Collider other)
    {
        //triggerEnter한 대상이 Player태그를 가진 게임오브젝트일때
        if (other.CompareTag("Player"))
        {
            other.transform.GetComponent<HealthInfoManager>().takeDamage(attackDamage); //대상의 hp에 공격력만큼 데미지를 준다
        }
    }

    //몬스터 사망------------------------------------------------------------------------
   
    /// <summary>
    /// 공격을 받았을 때
    /// </summary>
    /// <param name="damage">받은 데미지</param>
    public void takeDamage(float damage)
    {
        if(MonsterState == monsterState.idle || MonsterState == monsterState.move) //기본상태이거나 이동상태이면
        {
            HP -= damage;  //hp를 damage만큼 감소시키고
            target = GameManager.Inst.Player.gameObject; // 타겟을 설정
            MonsterState = monsterState.recognition;     // 상태를 인식상태로 변경
        }

        if(HP > 0 && MonsterState != monsterState.recognition) //hp가 0이 아니거나 인식상태가 아니면
        {
            HP -= damage; //체력을 데미지 만큼 감소시킨다.
            agent.speed = fixedSpeed; //몬스터 자리에 멈춤
            anim.SetBool("Attacked", true); //애니메이션 설정
            int randAttackedType = Random.Range(1, 4); //랜덤으로 숫자를 뽑아 
            switch (randAttackedType) //숫자에 해당하는 애니메이션 재생
            {
                case 1:
                    anim.SetTrigger("AttackedMotion1");
                    break;
                case 2:
                    anim.SetTrigger("AttackedMotion1");
                    break;
                case 3:
                    anim.SetTrigger("AttackedMotion1");
                    break;
                default:
                    break;
            }
        }
    }

    // 애니메이션 내에 포함된 함수
    void recoveryToIdle()
    {
        //현재 죽은상태가 아니라면
        if (MonsterState != monsterState.die) 
        {
            agent.speed = chaseSpeed;        //추격속도로 변경
            anim.SetBool("Attacked", false); //애니메이션 변경
        }
    }

    /// <summary>
    /// 몬스터가 죽었을 때 실행될 함수
    /// </summary>
    private void monsterDead()
    {
        capsuleCol.enabled = false; //충돌판정 없애기 위해 콜라이더 비활성화
        agent.speed = fixedSpeed;   //이동 멈춤
        alive = false;              //생존 여부 변경

        //각종 애니메이션 설정 변경
        anim.SetBool("Alive", false);
        anim.SetBool("Moving", false);
        anim.SetTrigger("Die");
        GameManager.Inst.monsterRespawn(); //몬스터 리스폰 함수 실행
        Destroy(gameObject, 10.0f); //10초후에 이 게임오브젝트를 삭제
    }

    // 시야범위 및 탐지범위 표시(기즈모)-----------------------------------------------------------------------------------------------------------------------------------------------
//    private void OnDrawGizmos()
//    {
//        Handles.color = Color.green;
//        Handles.DrawWireDisc(transform.position, transform.up, sightRange);

//        Handles.color = Color.yellow;
//        Handles.DrawWireDisc(transform.position, transform.up, (sightRange * 0.5f));

//        //시야각도만큼 gizmo 그리기
//        Handles.color = Color.red;
//        Vector3 forward = transform.forward * sightRange;
//        Quaternion q1 = Quaternion.Euler(0.5f * sightAngle * transform.up);
//        Quaternion q2 = Quaternion.Euler(-0.5f * sightAngle * transform.up);
//        Handles.DrawLine(transform.position, transform.position + q1 * forward);    // 시야각 오른쪽 끝
//        Handles.DrawLine(transform.position, transform.position + q2 * forward);    // 시야각 왼쪽 끝
//        // 전체 시야범위
//        Handles.DrawWireArc(transform.position,  //선을 그릴 중심점
//            transform.up,                        //회전축
//            q2 * transform.forward,              //출발점 에서 우측  
//            sightAngle,                          //표시할 각도
//            sightRange,                          //반지름
//            5.0f);                               //선 두께
//    }
}
