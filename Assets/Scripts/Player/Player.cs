using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.HID;

public class Player : MonoBehaviour
{
    float hp = 100.0f;
    float maxHP = 100.0f;
    public float HP 
    {
        get => hp;
        set
        {
            hp = Mathf.Clamp(value, 0,maxHP);
            HpChange?.Invoke(hp);
        } 
    }
    public Action<float> HpChange;

    // 이동관련 변수
    PlayerController actions;
    CharacterController controller;
    Vector2 inputMove;
    Vector3 moveDir;
    public float moveSpeed = 10.0f;
    public float walkSpeed = 10.0f;
    public float runSpeed = 15.0f;
    public float sitSpeed = 5.0f;

    //달리기 여부
    public bool onSprint = false;
    //달리기 스태미너
    float maxStamina = 5.0f;
    public float MaxStamina 
    {
        get => maxStamina;
    }
    float currentStamina = 5.0f;
    public float CurrentStamina 
    { 
        get => currentStamina; 
    }

    bool OnSit = false;
    public float gravity = -9.81f;

    // 카메라 관련변수
    GameObject cameraTarget; //카메라타겟, 시네머신카메라가 따라올 대상
    Vector2 look;
    [Header("카메라최대/최소각도")]
    public float TopClamp = 60.0f;
    public float BottomClamp = -45.0f;
    private float mouseDirX;
    private float mouseDirY;

    //플레이어 플래쉬라이트
    GameObject playerLight;
    Light FlashLight;
    bool onLight = false;                   // 플래쉬를 사용 여부
    //float DistanceToObject;                 // 물체까지의 거리
    //float DistanceRate;                     // 물체까지의 거리비율
    //float lightDecreaseDistance = 5.0f;     // 조명밝기 감소 최소거리
    //float LightNormalIntensity = 10.0f;     // 조명밝기 기본값
    //float lightIntensity = 10.0f;           // 적용할 조명밝기 값
    //[Header("플래쉬 라이트 최소/최대 밝기")]
    //public float lightMin = 3.0f;           // 최소 밝기 값
    //public float lightMax = 10.0f;          // 최대 밝기 값

    // 필드 아이템 상호작용
    GameObject InteractiveCheckPos;
    TextMeshProUGUI itemNameText;
    UseableObject useable;

    // 무기 - 권총
    Handgun handgun;
    

    private void OnEnable()
    {
        actions.Player.Enable();
        actions.Player.Move.performed += onMove;
        actions.Player.Move.canceled += onMove;
        actions.Player.Sprint.performed += UseSprint;
        actions.Player.Sprint.canceled += UseSprint;
        actions.Player.Flash.performed += UseFlash;
        actions.Player.Look.performed += onLook;
        actions.Player.Look.canceled += onLook;
        actions.Player.Interactive.performed += onInteractive;
        actions.Player.Sit.performed += onSit;
        actions.Player.Shot.performed += onShot;
        actions.Player.GunReload.performed += onReload;
    }
    private void OnDisable()
    {
        actions.Player.GunReload.performed -= onReload;
        actions.Player.Shot.performed -= onShot;
        actions.Player.Sit.performed -= onSit;
        actions.Player.Interactive.performed -= onInteractive;
        actions.Player.Look.canceled -= onLook;
        actions.Player.Look.performed -= onLook;
        actions.Player.Flash.performed -= UseFlash;
        actions.Player.Sprint.canceled -= UseSprint;
        actions.Player.Sprint.performed -= UseSprint;
        actions.Player.Move.canceled -= onMove;
        actions.Player.Move.performed -= onMove;
        actions.Player.Disable();
    }    

    private void Awake()
    {
        actions = new();
        controller = GetComponent<CharacterController>();

        cameraTarget = transform.GetChild(0).gameObject;
        playerLight = transform.GetChild(2).gameObject;
        FlashLight = playerLight.transform.GetComponent<Light>();
        playerLight.SetActive(false);
        InteractiveCheckPos = transform.GetChild(3).gameObject;

        itemNameText = GameObject.Find("ItemName").gameObject.GetComponent<TextMeshProUGUI>();

        handgun = cameraTarget.transform.Find("Handgun").gameObject.transform.GetComponent<Handgun>();
    }
    private void Update()
    {
        // 키보드 이동이 있을때
        if (moveDir.sqrMagnitude > 0.0f)
        {
            // 앉아있지 않고 달리기를 눌렀을 때 + 스태미너가 남아 있을 때
            if (!OnSit && onSprint)
            {
                currentStamina -= Time.deltaTime;
                
                if (currentStamina <= 0.0f)
                {
                    onSprint = false;
                }
                moveSpeed = runSpeed;
            }
            else
            {
                currentStamina += Time.deltaTime * 0.5f;
                // 앉아있을 때
                if (OnSit)
                {
                    moveSpeed = sitSpeed;
                }
                //서 있을때
                else
                {
                    moveSpeed = walkSpeed;
                }
            }
            controller.Move((transform.forward * moveDir.z * moveSpeed * Time.deltaTime) //앞으로 이동
                + (transform.right * moveDir.x * moveSpeed * Time.deltaTime)); // 옆으로 이동            
        }
        else
        {
            currentStamina += Time.deltaTime * 0.5f;
        }
        currentStamina = Mathf.Clamp(currentStamina, 0.0f, maxStamina);

        // 캐릭터가 땅에 닿아있지 않으면 중력 적용
        if (!controller.isGrounded)
        {
            controller.Move(-(Vector3.down * gravity * Time.deltaTime)); // 중력적용            
        }


        //ray에 닿았고 상호작용 범위에 있을때 사용가능 으로 만들어야 함
        //Physics.Raycast(원점: 캡슐 위치, 방향: 캡슐의 앞 방향, 충돌감지: hit, 거리: 15)에 뭔가 있으면 true
        if (Physics.Raycast(cameraTarget.transform.position, cameraTarget.transform.forward, out RaycastHit hit, 2.5f, LayerMask.GetMask("Useable")))
        {
            //Debug.Log($"{hit.transform.name}");
            useable = hit.transform.GetComponent<UseableObject>();
            itemNameText.text = useable.objectName();
        }
        else
        {
            useable = null;
            itemNameText.text = null;
        }
        //ray Debug 사용가능한 아이템 오브젝트 확인용
        Debug.DrawRay(cameraTarget.transform.position, cameraTarget.transform.forward * 2.5f, Color.blue);

        //물체가 가까울수록 조명 세기 감소 - 보류------------------------
        //if (Physics.Raycast(cameraTarget.transform.position, cameraTarget.transform.forward, out RaycastHit hitToObj))
        //{
        //    Debug.Log(hit.point);
        //    Debug.Log((cameraTarget.transform.position - hit.point).magnitude);

        //    DistanceToObject = (cameraTarget.transform.position - hit.point).magnitude;              // 내가 보고있는 시점에서 가까운 물체까지의 거리
        //    DistanceRate = DistanceToObject / lightDecreaseDistance;                                 // 가까운 물체까지의 거리 비율
        //    lightIntensity  = Mathf.Clamp(DistanceRate * LightNormalIntensity, lightMin, lightMax);  // 물체와 가까운 비율만큼 조명의 밝기 감소           
        //}
        //else
        //{
        //    lightIntensity = LightNormalIntensity;
        //}
        ////조명 밝기감소 거리 확인용
        //Debug.DrawRay(cameraTarget.transform.position, cameraTarget.transform.forward * 3.0f, Color.red);
        
    }
    private void LateUpdate()
    {
        CameraRotate();
    }

    //키보드 입력을 받아 방향에 맞게 저장
    private void onMove(InputAction.CallbackContext context)
    {
        inputMove = context.ReadValue<Vector2>();
        moveDir.x = inputMove.x;
        moveDir.y = 0.0f;
        moveDir.z = inputMove.y;
    }

    // 왼쪽 쉬프트키를 누르고 있으면 달리기 사용
    private void UseSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onSprint = true;
        }
        if (context.canceled)
        {
            onSprint = false;
        }
    }

    //F키를 눌러 플레이어의 조명 켜고 끄기 변경
    private void UseFlash(InputAction.CallbackContext _)
    {
        if (!onLight)
        {
            playerLight.SetActive(true);
            onLight = true;
        }
        else
        {
            playerLight.SetActive(false);
            onLight = false;
        }
    }

    //마우스의 움직임을 받음
    private void onLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }


    // 필드 아이템 상호작용 기능 -----------------------------------------------
    // E키를 눌렀을 때 상호작용 가능한 아이템이 있으면 아이템을 사용
    private void onInteractive(InputAction.CallbackContext _)
    {
        if(useable != null)
        {
            //아이템이 즉시사용 가능하면 아이템 사용
            if (useable.directUseable())
            {
                useable.objectIneractive();
            }
            else
            {
                //아이템 인벤토리에 저장
            }
        }
    }
    // 사용가능한 아이템을 사용하는 함수
    void interactive(UseableObject obj)
    {
        obj.objectIneractive();
    }
    // 캐릭터 앉기 기능--------------------------------------------------------
    private void onSit(InputAction.CallbackContext obj)
    {
        sitChange();
    }
    /// <summary>
    /// 앉아있는 상태에 따라 카메라와 조명의 높낮이 조절
    /// </summary>
    void sitChange()
    {
        float yPos = 0.75f;
        if (!OnSit)
        {
            yPos *= -1;
            controller.center = new(0, 0.375f, 0);
            controller.height = 0.75f;            
            OnSit = true;
        }
        else
        {
            yPos *= 1;
            controller.center = new(0, 0.75f, 0);
            controller.height = 1.5f;
            OnSit = false;
        }
        cameraTarget.transform.position = new Vector3(transform.position.x, cameraTarget.transform.position.y + yPos, transform.position.z);
        playerLight.transform.position = new Vector3(transform.position.x, playerLight.transform.position.y + yPos, transform.position.z);
    }

    private void onReload(InputAction.CallbackContext _)
    {
        if(!handgun.Reloading && (handgun.CurrentBulletCount != handgun.MaxBulletCount))
        {
            handgun.ReloadHandgun();
        }
    }

    private void onShot(InputAction.CallbackContext _)
    {
        if(!handgun.Reloading)
        {
            handgun.shotHandgun();
            shotEffect();
        }
        
    }

    // 1안. ray를 쏴서 명중시킨다
    // 2안. 총알을 쏴서 명중시킨다 
    private void shotEffect()
    {

    }

    /// <summary>
    /// 마우스의 입력에 따라 카메라, 캐릭터를 회전시켜주는 함수
    /// </summary>
    private void CameraRotate()
    {                                            
        if (look.sqrMagnitude > 0.0f)
        {
            mouseDirX += look.x;
            mouseDirY += look.y;
        }

        // 각도 수정(일정범위 유지, 각도 초기화)
        mouseDirX = ClampAngle(mouseDirX, float.MinValue, float.MaxValue);
        mouseDirY = ClampAngle(mouseDirY, BottomClamp, TopClamp);

        transform.rotation = Quaternion.Euler(0.0f, mouseDirX, 0.0f);                         // 캐릭터 회전
        cameraTarget.transform.rotation = Quaternion.Euler(mouseDirY, mouseDirX, 0.0f);       // 카메라 타겟 회전
        playerLight.transform.rotation = Quaternion.Euler(mouseDirY, mouseDirX, 0.0f);        // 플래쉬 라이트를 시선에 맞춰 회전

        InteractiveCheckPos.transform.position = cameraTarget.transform.position;              // 아이템인식 오브젝트 카메라 위치랑 일치시킴
        InteractiveCheckPos.transform.rotation = Quaternion.Euler(mouseDirY, mouseDirX, 0.0f); // 카메라와 같은 각도로 회전
    }

    /// <summary>
    /// 좌우 각도가 범위를 벗어나면 초기화해서 계속 돌아갈수 있게 해줌, 상하각도가 일정범위 이상 벗어나지 않게 해줌
    /// </summary>
    /// <param name="angle">현재 돌아간 마우스 각도</param>
    /// <param name="Min">마우스 최소 각도</param>
    /// <param name="Max">마우스 최대 각도</param>
    /// <returns>조정된 마우스 각도</returns>
    private static float ClampAngle(float angle, float Min, float Max)
    {
        if (angle < -360f)
        {
            angle += 360f;
        }
        if (angle > 360f)
        {
            angle -= 360f;
        }
        return Mathf.Clamp(angle, Min, Max);
    }
}
