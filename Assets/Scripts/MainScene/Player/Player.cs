using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.HID;
using InfimaGames.LowPolyShooterPack;
using Unity.VisualScripting;

public class Player : MonoBehaviour, HealthInfoManager
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
            if(hp <= 0)
            {
                PlayerDead();
            }
        } 
    }
    public Action<float> HpChange;

    // 이동관련 변수
    PlayerController actions;
    CharacterController controller;
    Vector2 inputMove;
    Vector3 moveDir;
    public float moveSpeed = 5.0f;
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public float sitSpeed = 2.5f;

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
    public GameObject cameraTarget; //카메라타겟, 시네머신카메라가 따라올 대상
    Vector2 look;

    [Header("카메라최대/최소각도")]
    public float TopClamp = 60.0f;
    public float BottomClamp = -45.0f;
    private float mouseDirX;
    private float mouseDirY;

    //플레이어 플래쉬라이트
    GameObject playerLight;
    bool onLight = false;   // 플래쉬를 사용 여부

    // 필드 아이템 상호작용
    TextMeshProUGUI itemNameText;
    UseableObject useable;

    // 무기 - 권총
    Handgun handgun;

    //우클릭으로 사용할 아이템
    ItemSelect selectItem;

    //esc로 메뉴 사용
    bool menuState = false;
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
        actions.Player.Shot.performed += Shot;
        actions.Player.UseItem.performed += UseItem;
        actions.Player.GunReload.performed += onReload;
        actions.Player.itemselect1.performed += select1Item;
        actions.Player.itemselect2.performed += select2Item;
        actions.Player.itemselect3.performed += select3Item;
        actions.Player.itemselect4.performed += select4Item;
        actions.Player.itemselect5.performed += select5Item;
        actions.Player.itemselect6.performed += select6Item;

        actions.Menu.Enable();
        actions.Menu.Esc.performed += useESC;
    }
    private void OnDisable()
    {
        actions.Menu.Esc.performed -= useESC;
        actions.Menu.Disable();

        actions.Player.itemselect6.performed -= select6Item;
        actions.Player.itemselect5.performed -= select5Item;
        actions.Player.itemselect4.performed -= select4Item;
        actions.Player.itemselect3.performed -= select3Item;
        actions.Player.itemselect2.performed -= select2Item;
        actions.Player.itemselect1.performed -= select1Item;
        actions.Player.GunReload.performed -= onReload;
        actions.Player.Shot.performed -= Shot;
        actions.Player.UseItem.performed -= UseItem;
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
        selectItem = FindObjectOfType<ItemSelect>();
        cameraTarget = transform.GetChild(0).gameObject;
        playerLight = transform.GetChild(2).gameObject;
        playerLight.SetActive(false);

        itemNameText = GameObject.Find("ItemName").gameObject.GetComponent<TextMeshProUGUI>();

        handgun = cameraTarget.transform.Find("Handgun").gameObject.transform.GetComponent<Handgun>();

        Cursor.lockState = CursorLockMode.Locked;   // 게임 창 밖으로 마우스가 안나감, 마우스를 게임 중앙 좌표에 고정시키고 숨김
    }

    private void Update()
    {
        // WASD 이동이 있을때
        if (moveDir.sqrMagnitude > 0.0f)
        {
            // 앉아있지 않고 달리기를 눌렀을 때 & 스태미너가 남아 있을 때 = 달리고 있을때
            if (!OnSit && onSprint)
            {
                currentStamina -= Time.deltaTime; // 스태미너 감소
                
                //스태미너가 다 떨어졌으면
                if (currentStamina <= 0.0f)
                {
                    onSprint = false; // 달리기 상태 변경
                }
                moveSpeed = runSpeed;
            }
            // 달리고 있지 않을때
            else 
            {
                currentStamina += Time.deltaTime * 0.5f; // 스태미너 회복
                // 앉아있을 때
                if (OnSit)
                {
                    moveSpeed = sitSpeed;
                }
                // 서 있을때
                else
                {
                    moveSpeed = walkSpeed;
                }
            }
            controller.Move((transform.forward * moveDir.z * moveSpeed * Time.deltaTime) // 앞으로 이동
                + (transform.right * moveDir.x * moveSpeed * Time.deltaTime));           // 옆으로 이동            
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


        // Physics.Raycast(원점: 캡슐 위치, 방향: 캡슐의 앞 방향, 충돌감지: hit, 거리: 15)에 있는 물체의 LayerMask가 Useable이면 true 반환
        if (Physics.Raycast(cameraTarget.transform.position, cameraTarget.transform.forward, out RaycastHit hit, 2.5f, LayerMask.GetMask("Useable")))
        {
            useable = hit.transform.GetComponent<UseableObject>(); 

            //상호작용 가능한 오브젝트인지 확인
            if (useable != null)
            {
                itemNameText.text = useable.objectName();
            }            
        }
        else
        {
            useable = null;
            itemNameText.text = null;
        }
        //ray Debug 사용가능한 아이템 오브젝트 확인용
        //Debug.DrawRay(cameraTarget.transform.position, cameraTarget.transform.forward * 2.5f, Color.blue);
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

    //마우스의 움직임을 입력 받음
    private void onLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }


    // 필드 아이템 상호작용 기능 -----------------------------------------------
    // E키를 눌러 대상의 상호작용 함수 실행. 
    private void onInteractive(InputAction.CallbackContext _)
    {
        if(useable != null)
        {
            useable.objectIneractive();
        }
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
        float yPos = 0.75f;       // 캐릭터 콜라이더의 중간 높이
        float centerYPos = 0.75f; // 높이 조정용 변수

        //앉은상태가 아니면
        if (!OnSit)
        {
            yPos *= -1;                                     // 카메라와 플래쉬 라이트 위치 감소용
            controller.center = new(0, centerYPos*0.5f, 0); // 센터 높이 절반 감소
            controller.height = centerYPos;                 // 전체 높이 절반 감소 
            OnSit = true;                                   // 앉은상태 여부 저장
        }
        else
        {
            yPos *= 1;                                  // 카메라와 플래쉬 라이트 위치 증가용
            controller.center = new(0, centerYPos, 0);  // 센터 높이 복구
            controller.height = centerYPos*2;           // 전체 높이 복구
            OnSit = false;                              // 앉은상태 여부 저장
        }

        cameraTarget.transform.position = new Vector3(transform.position.x, cameraTarget.transform.position.y + yPos, transform.position.z); // 카메라의 위치를 눈높이로 변경
        playerLight.transform.position = new Vector3(transform.position.x, playerLight.transform.position.y + yPos, transform.position.z);   // 플래쉬라이트의 위치를 눈높이로 변경
    }

    /// <summary>
    /// R키를 누르면 재장전 한다.
    /// </summary>
    /// <param name="_"></param>
    private void onReload(InputAction.CallbackContext _)
    {
        handgun.ReloadHandgun();        
    }

    //아이템 선택 1~6
    int selectedItemNumber = 0;
    public int SelectedItemNumber
    {
        get => selectedItemNumber;
        set
        {
            selectedItemNumber = value;
            onItemChange?.Invoke(selectedItemNumber);
        }
    }
    public Action<int> onItemChange;

    private void select1Item(InputAction.CallbackContext _)
    {
        selectItem.preItemNum = SelectedItemNumber;
        SelectedItemNumber = 0;           
    }
    private void select2Item(InputAction.CallbackContext _)
    {
        selectItem.preItemNum = SelectedItemNumber;
        SelectedItemNumber = 1;
    }
    private void select3Item(InputAction.CallbackContext _)
    {
        selectItem.preItemNum = SelectedItemNumber;
        SelectedItemNumber = 2;
    }
    private void select4Item(InputAction.CallbackContext _)
    {
        selectItem.preItemNum = SelectedItemNumber;
        SelectedItemNumber = 3;
    }
    private void select5Item(InputAction.CallbackContext _)
    {
        selectItem.preItemNum = SelectedItemNumber;
        SelectedItemNumber = 4;
    }
    private void select6Item(InputAction.CallbackContext _)
    {
        selectItem.preItemNum = SelectedItemNumber;
        SelectedItemNumber = 5;
    }

    /// <summary>
    /// esc를 눌렀을때 메뉴 상호작용
    /// </summary>
    /// <param name="_"></param>
    private void useESC(InputAction.CallbackContext _)
    {
        //메뉴 사용중이 아니고 도움말 사용중이 아닐때
        if (!menuState && GameManager.Inst.usingHelp == false) 
        {
            Time.timeScale = 0.0f;      //게임속도 0으로 설정
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;      //커서 숨김 비활성화
            actions.Player.Disable();   //인풋액션 비활성화
            GameManager.Inst.openMenu();//메뉴 활성화
            menuState = true;           //메뉴 활성상태 활성으로 변경
        } 
    }

    /// <summary>
    /// 메뉴 닫기
    /// </summary>
    public void offMenu()
    {
        Time.timeScale = 1.0f;                    //게임속도 원상복구
        GameManager.Inst.closeMenu();             //메뉴창 비 활성화
        actions.Player.Enable();                  //플레이어 인풋액션 활성화
        Cursor.visible = false;                   //커서 숨김
        Cursor.lockState = CursorLockMode.Locked; //커서 중간에 고정 
        menuState = false;                        //메뉴 활성상태 비활성으로 변경
    }

    //우클릭으로 선택한 아이템 사용
    private void UseItem(InputAction.CallbackContext _)
    {
        if (selectItem.nowItem.gameObject != null)
        {
            selectItem.Use();
        }
    }
    //사격 좌클릭
    private void Shot(InputAction.CallbackContext _)
    {
        if (!handgun.Reloading)
        {
            handgun.shotHandgun();
        }
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

    // damage만큼 hp를 감소시킴
    public void takeDamage(float damage)
    {
        HP -= damage;
    }

    /// <summary>
    /// 플레이어가 죽으면 처음 선택화면으로 돌아감
    /// </summary>
    void PlayerDead()
    {
        SceneManager.LoadScene("SelectScene");
    }
}
