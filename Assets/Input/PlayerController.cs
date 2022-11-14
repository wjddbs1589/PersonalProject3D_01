//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/PlayerController.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerController : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""8b21df1f-a66c-461a-bf38-8e6e2491d2cf"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a40a64f6-ebe0-4e13-8902-30a2154f783d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""ae37b952-1ddd-4f28-ae8d-7b4a4779ebf7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""a7d384a6-9a1b-49ca-bf14-99d6dae11a75"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Flash"",
                    ""type"": ""Button"",
                    ""id"": ""2a1f5ec0-d806-4a97-b1bc-c4ef42f8b9b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""544e0572-5973-4ae7-bb51-7ef563fcb5b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interactive"",
                    ""type"": ""Button"",
                    ""id"": ""10c6f4e6-cded-4727-a20e-e8af28f3a9b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sit"",
                    ""type"": ""Button"",
                    ""id"": ""daa8ede2-8030-4c32-a8d2-4b334bfa418b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shot"",
                    ""type"": ""Button"",
                    ""id"": ""596e3c3b-19bd-4f8a-8314-079b39594545"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseItem"",
                    ""type"": ""Button"",
                    ""id"": ""9d893fb0-5ddd-4bc7-bc64-b146b8628560"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GunReload"",
                    ""type"": ""Button"",
                    ""id"": ""d3eee423-1ece-473b-af66-bd81ddc2eb5e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""itemselect1"",
                    ""type"": ""Button"",
                    ""id"": ""55fa2228-6b40-4790-84be-278acf73862e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""itemselect2"",
                    ""type"": ""Button"",
                    ""id"": ""5ede37f7-8d0d-4b36-8324-e31c338b3989"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""itemselect3"",
                    ""type"": ""Button"",
                    ""id"": ""53bcfe48-d05a-417e-820e-b734c8238306"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""itemselect4"",
                    ""type"": ""Button"",
                    ""id"": ""5f6f69ee-c7b9-4e09-aa6a-98a715ee71ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""itemselect5"",
                    ""type"": ""Button"",
                    ""id"": ""18944db9-8d8e-45ec-8dde-d0184cbd9dd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""itemselect6"",
                    ""type"": ""Button"",
                    ""id"": ""ee696b84-7e71-4262-a925-26444a64a2b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""d071dc15-7a0a-4ffb-9ef9-c5e42976a9ea"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1bcf89c8-b9aa-4fc1-bf43-849b443b6719"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f444e875-88ab-461f-a39a-30b56d72b16a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5932a820-60d0-4765-8fa5-c99e01ad485c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6268865a-dc07-4ad0-a2f6-c9dc5072ab76"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""89a27b8d-786c-4b77-b8ad-de69f951bd14"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e33c1d8-1036-452c-b23a-b08febc7bf13"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false),ScaleVector2(x=0.05,y=0.05)"",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9eab1af1-5770-496a-bd62-404699f628de"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""Flash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""436e4400-50d0-41c6-9885-5f5dd5f2f536"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59609e29-609b-41e4-8a19-2b5d9bb2ebd8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""Interactive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14407336-0582-49fc-a435-573a453e9ce2"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""Sit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06d38281-970a-48c3-8f66-4326d3e18384"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""Shot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e3628bc-3851-484e-acb2-379361984d6c"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""GunReload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19fbd7fc-7c5f-49ef-a7e5-de24f675b9b3"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""itemselect1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2df94f81-2f35-467f-a5b2-a99c9829cae3"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""itemselect2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e42afb2d-9ed3-42bc-ac97-c2ea39f20ebe"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""itemselect3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19d4bf1d-9378-49bc-91e5-e9bab5a6720e"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""itemselect4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e77ff796-e2af-46a2-b556-d46046ce31ef"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""itemselect5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19e51853-66cb-466b-bc26-12ccaf48c402"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""itemselect6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1802ef65-2a65-4136-8498-f8e71bd9a530"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""32ac44bf-1fb8-4788-90e5-9ddb7e069334"",
            ""actions"": [
                {
                    ""name"": ""Esc"",
                    ""type"": ""Button"",
                    ""id"": ""e947d9f1-a2a2-4777-97d9-18c774ccff6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e7a8850e-e55c-4121-ad57-0447c995c45a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardMouse"",
                    ""action"": ""Esc"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyBoardMouse"",
            ""bindingGroup"": ""KeyBoardMouse"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Sprint = m_Player.FindAction("Sprint", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_Flash = m_Player.FindAction("Flash", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Interactive = m_Player.FindAction("Interactive", throwIfNotFound: true);
        m_Player_Sit = m_Player.FindAction("Sit", throwIfNotFound: true);
        m_Player_Shot = m_Player.FindAction("Shot", throwIfNotFound: true);
        m_Player_UseItem = m_Player.FindAction("UseItem", throwIfNotFound: true);
        m_Player_GunReload = m_Player.FindAction("GunReload", throwIfNotFound: true);
        m_Player_itemselect1 = m_Player.FindAction("itemselect1", throwIfNotFound: true);
        m_Player_itemselect2 = m_Player.FindAction("itemselect2", throwIfNotFound: true);
        m_Player_itemselect3 = m_Player.FindAction("itemselect3", throwIfNotFound: true);
        m_Player_itemselect4 = m_Player.FindAction("itemselect4", throwIfNotFound: true);
        m_Player_itemselect5 = m_Player.FindAction("itemselect5", throwIfNotFound: true);
        m_Player_itemselect6 = m_Player.FindAction("itemselect6", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Esc = m_Menu.FindAction("Esc", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Sprint;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_Flash;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Interactive;
    private readonly InputAction m_Player_Sit;
    private readonly InputAction m_Player_Shot;
    private readonly InputAction m_Player_UseItem;
    private readonly InputAction m_Player_GunReload;
    private readonly InputAction m_Player_itemselect1;
    private readonly InputAction m_Player_itemselect2;
    private readonly InputAction m_Player_itemselect3;
    private readonly InputAction m_Player_itemselect4;
    private readonly InputAction m_Player_itemselect5;
    private readonly InputAction m_Player_itemselect6;
    public struct PlayerActions
    {
        private @PlayerController m_Wrapper;
        public PlayerActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Sprint => m_Wrapper.m_Player_Sprint;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @Flash => m_Wrapper.m_Player_Flash;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Interactive => m_Wrapper.m_Player_Interactive;
        public InputAction @Sit => m_Wrapper.m_Player_Sit;
        public InputAction @Shot => m_Wrapper.m_Player_Shot;
        public InputAction @UseItem => m_Wrapper.m_Player_UseItem;
        public InputAction @GunReload => m_Wrapper.m_Player_GunReload;
        public InputAction @itemselect1 => m_Wrapper.m_Player_itemselect1;
        public InputAction @itemselect2 => m_Wrapper.m_Player_itemselect2;
        public InputAction @itemselect3 => m_Wrapper.m_Player_itemselect3;
        public InputAction @itemselect4 => m_Wrapper.m_Player_itemselect4;
        public InputAction @itemselect5 => m_Wrapper.m_Player_itemselect5;
        public InputAction @itemselect6 => m_Wrapper.m_Player_itemselect6;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Sprint.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Flash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFlash;
                @Flash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFlash;
                @Flash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFlash;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Interactive.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractive;
                @Interactive.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractive;
                @Interactive.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractive;
                @Sit.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSit;
                @Sit.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSit;
                @Sit.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSit;
                @Shot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShot;
                @Shot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShot;
                @Shot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShot;
                @UseItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseItem;
                @UseItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseItem;
                @UseItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseItem;
                @GunReload.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGunReload;
                @GunReload.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGunReload;
                @GunReload.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGunReload;
                @itemselect1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect1;
                @itemselect1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect1;
                @itemselect1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect1;
                @itemselect2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect2;
                @itemselect2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect2;
                @itemselect2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect2;
                @itemselect3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect3;
                @itemselect3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect3;
                @itemselect3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect3;
                @itemselect4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect4;
                @itemselect4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect4;
                @itemselect4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect4;
                @itemselect5.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect5;
                @itemselect5.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect5;
                @itemselect5.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect5;
                @itemselect6.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect6;
                @itemselect6.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect6;
                @itemselect6.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemselect6;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Flash.started += instance.OnFlash;
                @Flash.performed += instance.OnFlash;
                @Flash.canceled += instance.OnFlash;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Interactive.started += instance.OnInteractive;
                @Interactive.performed += instance.OnInteractive;
                @Interactive.canceled += instance.OnInteractive;
                @Sit.started += instance.OnSit;
                @Sit.performed += instance.OnSit;
                @Sit.canceled += instance.OnSit;
                @Shot.started += instance.OnShot;
                @Shot.performed += instance.OnShot;
                @Shot.canceled += instance.OnShot;
                @UseItem.started += instance.OnUseItem;
                @UseItem.performed += instance.OnUseItem;
                @UseItem.canceled += instance.OnUseItem;
                @GunReload.started += instance.OnGunReload;
                @GunReload.performed += instance.OnGunReload;
                @GunReload.canceled += instance.OnGunReload;
                @itemselect1.started += instance.OnItemselect1;
                @itemselect1.performed += instance.OnItemselect1;
                @itemselect1.canceled += instance.OnItemselect1;
                @itemselect2.started += instance.OnItemselect2;
                @itemselect2.performed += instance.OnItemselect2;
                @itemselect2.canceled += instance.OnItemselect2;
                @itemselect3.started += instance.OnItemselect3;
                @itemselect3.performed += instance.OnItemselect3;
                @itemselect3.canceled += instance.OnItemselect3;
                @itemselect4.started += instance.OnItemselect4;
                @itemselect4.performed += instance.OnItemselect4;
                @itemselect4.canceled += instance.OnItemselect4;
                @itemselect5.started += instance.OnItemselect5;
                @itemselect5.performed += instance.OnItemselect5;
                @itemselect5.canceled += instance.OnItemselect5;
                @itemselect6.started += instance.OnItemselect6;
                @itemselect6.performed += instance.OnItemselect6;
                @itemselect6.canceled += instance.OnItemselect6;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Esc;
    public struct MenuActions
    {
        private @PlayerController m_Wrapper;
        public MenuActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Esc => m_Wrapper.m_Menu_Esc;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Esc.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnEsc;
                @Esc.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnEsc;
                @Esc.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnEsc;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Esc.started += instance.OnEsc;
                @Esc.performed += instance.OnEsc;
                @Esc.canceled += instance.OnEsc;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_KeyBoardMouseSchemeIndex = -1;
    public InputControlScheme KeyBoardMouseScheme
    {
        get
        {
            if (m_KeyBoardMouseSchemeIndex == -1) m_KeyBoardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyBoardMouse");
            return asset.controlSchemes[m_KeyBoardMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnFlash(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteractive(InputAction.CallbackContext context);
        void OnSit(InputAction.CallbackContext context);
        void OnShot(InputAction.CallbackContext context);
        void OnUseItem(InputAction.CallbackContext context);
        void OnGunReload(InputAction.CallbackContext context);
        void OnItemselect1(InputAction.CallbackContext context);
        void OnItemselect2(InputAction.CallbackContext context);
        void OnItemselect3(InputAction.CallbackContext context);
        void OnItemselect4(InputAction.CallbackContext context);
        void OnItemselect5(InputAction.CallbackContext context);
        void OnItemselect6(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnEsc(InputAction.CallbackContext context);
    }
}
