// GENERATED AUTOMATICALLY FROM 'Assets/Action Maps/_actionmap_Player01.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @_actionmap_Player01 : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @_actionmap_Player01()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""_actionmap_Player01"",
    ""maps"": [
        {
            ""name"": ""actmap_Player01"",
            ""id"": ""785b3520-8fe5-417d-b62b-858dd534068d"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""032aaf22-189b-47bd-9269-b37f49fe68b7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AirButton"",
                    ""type"": ""Button"",
                    ""id"": ""cbbf3a6c-7b0c-4fd4-a2d3-057ffa221cb1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireButton"",
                    ""type"": ""Button"",
                    ""id"": ""e98fe1d7-8697-4220-9540-e2dd23f0d07e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WaterButton"",
                    ""type"": ""Button"",
                    ""id"": ""11deaaef-c3d6-4cfd-b5b4-a9893aad4be5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EarthButton"",
                    ""type"": ""Button"",
                    ""id"": ""0ad35812-0d85-4d54-98b3-b475b6c2fe0a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartButton"",
                    ""type"": ""Button"",
                    ""id"": ""b3185d61-889f-4ff1-974d-72a63b2b6536"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b93fef65-6eb4-4baf-9880-1ac68a4f574e"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""511881d4-34ab-4d70-abbf-7bac99644d11"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AirButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6db1f1f9-0e46-4c1e-bdb7-373578715309"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ad249bf-5802-465f-b7d1-20283bb1a19a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WaterButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e54880ae-6486-4ac4-b857-dd04ddea0ef7"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EarthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b857ded9-86e9-40c5-b50c-da1209e23a51"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ca92ce9-8fd2-4b32-9dd7-2be950c34262"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""actmap_Player2"",
            ""id"": ""804c47fc-7fb5-4439-bd2f-d350f026ad65"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""2ba93ab5-4306-4aae-ae5d-35bb3745d66c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AirButton"",
                    ""type"": ""Button"",
                    ""id"": ""2cb17e17-228e-4521-a14d-c52a27657cbf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireButton"",
                    ""type"": ""Button"",
                    ""id"": ""cd6a1ac9-3214-430d-a28a-5ede68d2dd33"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WaterButton"",
                    ""type"": ""Button"",
                    ""id"": ""896132c8-8740-4457-b32b-9fa0e4730c5b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EarthButton"",
                    ""type"": ""Button"",
                    ""id"": ""d9f7578a-2543-4ab6-b57e-c6718a2c5c21"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartButton"",
                    ""type"": ""Button"",
                    ""id"": ""30654c57-f1cc-47b0-9ea5-99ccb0f8edd8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""d974348c-40bc-43ea-aa7a-e5bfb4053f37"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""11889349-f6dd-46a1-9620-98426f3e890b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1b9f2172-5c16-4d5a-bf20-8a2e15e8e2d1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fbd5f14c-6193-442d-b725-8019577202ee"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e26ff305-33eb-4b58-ad8c-8307ed241af3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e4aef8a0-30a7-42cc-a3f0-bfcaf0bf7f08"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AirButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6495932-52cd-426d-b170-bc6cf4280286"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbf7e97e-9e8a-4ea2-bb7c-2efa76e9488b"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WaterButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b50914ab-52c4-4e4e-8420-1a9e2de88327"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EarthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4adfdf9d-c781-45a5-86f6-fda9388d9c17"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb63eccf-4b2b-46f2-a225-5720bfdce89e"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""actmap_Player3"",
            ""id"": ""23c2e626-7773-42e0-b73e-bc5f3b469cef"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""3fd2bd26-bc19-4436-a374-ec29223aae57"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AirButton"",
                    ""type"": ""Button"",
                    ""id"": ""9bab0899-9199-45fa-9291-f2b46e48d1eb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireButton"",
                    ""type"": ""Button"",
                    ""id"": ""a83eb34d-508c-48db-beea-3bea4c539a33"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WaterButton"",
                    ""type"": ""Button"",
                    ""id"": ""2bdca0a6-1d09-4009-ba88-2e705171235c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EarthButton"",
                    ""type"": ""Button"",
                    ""id"": ""a7684a35-0efc-4c59-bcc5-88e9c595df3f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartButton"",
                    ""type"": ""Button"",
                    ""id"": ""f63d6e38-0992-48ac-9dfd-61c0a902287a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b1fa376c-6675-44d3-8220-1b9194dc4c4d"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""be43d995-067d-4790-bd5b-a4de9ff2d918"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""_ControlScheme_Default"",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""337a7e07-5e61-4b1f-90fc-02e0dbc0a56e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""_ControlScheme_Default"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""624d6023-4fa6-4fbd-b759-58539034a7d2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""_ControlScheme_Default"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""97301698-e21b-4e8e-bb32-1e65a16fc6e2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""_ControlScheme_Default"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b886d9ca-121c-4fa5-ada8-6fdce98b373a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""_ControlScheme_Default"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5479976b-856d-4dc1-86d1-5c2143339b7c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AirButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b30d6fc2-742a-4aab-b79c-9e9ca5d28ee3"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""_ControlScheme_Default"",
                    ""action"": ""AirButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6d47ec4-1adc-479b-8170-79d6bc6a3231"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19f34356-bcff-4f86-ae4b-6e1006c586e4"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""_ControlScheme_Default"",
                    ""action"": ""FireButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""adf6c3a7-7f0e-42d6-8d4c-1d487cf53e9e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WaterButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e78409b9-a9a1-464a-a018-7a8432a23e4a"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""_ControlScheme_Default"",
                    ""action"": ""WaterButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c6259ff-2d26-47dd-81e0-93441bd0e389"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EarthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ef92213-4b99-487b-b021-d33f00ea770e"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""_ControlScheme_Default"",
                    ""action"": ""EarthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c711f0c-8315-4341-922f-736bbe69f174"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c749b345-70d0-4ffa-88e6-ef317154bf13"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""_ControlScheme_Default"",
            ""bindingGroup"": ""_ControlScheme_Default"",
            ""devices"": []
        }
    ]
}");
        // actmap_Player01
        m_actmap_Player01 = asset.FindActionMap("actmap_Player01", throwIfNotFound: true);
        m_actmap_Player01_Movement = m_actmap_Player01.FindAction("Movement", throwIfNotFound: true);
        m_actmap_Player01_AirButton = m_actmap_Player01.FindAction("AirButton", throwIfNotFound: true);
        m_actmap_Player01_FireButton = m_actmap_Player01.FindAction("FireButton", throwIfNotFound: true);
        m_actmap_Player01_WaterButton = m_actmap_Player01.FindAction("WaterButton", throwIfNotFound: true);
        m_actmap_Player01_EarthButton = m_actmap_Player01.FindAction("EarthButton", throwIfNotFound: true);
        m_actmap_Player01_StartButton = m_actmap_Player01.FindAction("StartButton", throwIfNotFound: true);
        // actmap_Player2
        m_actmap_Player2 = asset.FindActionMap("actmap_Player2", throwIfNotFound: true);
        m_actmap_Player2_Movement = m_actmap_Player2.FindAction("Movement", throwIfNotFound: true);
        m_actmap_Player2_AirButton = m_actmap_Player2.FindAction("AirButton", throwIfNotFound: true);
        m_actmap_Player2_FireButton = m_actmap_Player2.FindAction("FireButton", throwIfNotFound: true);
        m_actmap_Player2_WaterButton = m_actmap_Player2.FindAction("WaterButton", throwIfNotFound: true);
        m_actmap_Player2_EarthButton = m_actmap_Player2.FindAction("EarthButton", throwIfNotFound: true);
        m_actmap_Player2_StartButton = m_actmap_Player2.FindAction("StartButton", throwIfNotFound: true);
        // actmap_Player3
        m_actmap_Player3 = asset.FindActionMap("actmap_Player3", throwIfNotFound: true);
        m_actmap_Player3_Movement = m_actmap_Player3.FindAction("Movement", throwIfNotFound: true);
        m_actmap_Player3_AirButton = m_actmap_Player3.FindAction("AirButton", throwIfNotFound: true);
        m_actmap_Player3_FireButton = m_actmap_Player3.FindAction("FireButton", throwIfNotFound: true);
        m_actmap_Player3_WaterButton = m_actmap_Player3.FindAction("WaterButton", throwIfNotFound: true);
        m_actmap_Player3_EarthButton = m_actmap_Player3.FindAction("EarthButton", throwIfNotFound: true);
        m_actmap_Player3_StartButton = m_actmap_Player3.FindAction("StartButton", throwIfNotFound: true);
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

    // actmap_Player01
    private readonly InputActionMap m_actmap_Player01;
    private IActmap_Player01Actions m_Actmap_Player01ActionsCallbackInterface;
    private readonly InputAction m_actmap_Player01_Movement;
    private readonly InputAction m_actmap_Player01_AirButton;
    private readonly InputAction m_actmap_Player01_FireButton;
    private readonly InputAction m_actmap_Player01_WaterButton;
    private readonly InputAction m_actmap_Player01_EarthButton;
    private readonly InputAction m_actmap_Player01_StartButton;
    public struct Actmap_Player01Actions
    {
        private @_actionmap_Player01 m_Wrapper;
        public Actmap_Player01Actions(@_actionmap_Player01 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_actmap_Player01_Movement;
        public InputAction @AirButton => m_Wrapper.m_actmap_Player01_AirButton;
        public InputAction @FireButton => m_Wrapper.m_actmap_Player01_FireButton;
        public InputAction @WaterButton => m_Wrapper.m_actmap_Player01_WaterButton;
        public InputAction @EarthButton => m_Wrapper.m_actmap_Player01_EarthButton;
        public InputAction @StartButton => m_Wrapper.m_actmap_Player01_StartButton;
        public InputActionMap Get() { return m_Wrapper.m_actmap_Player01; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Actmap_Player01Actions set) { return set.Get(); }
        public void SetCallbacks(IActmap_Player01Actions instance)
        {
            if (m_Wrapper.m_Actmap_Player01ActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnMovement;
                @AirButton.started -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnAirButton;
                @AirButton.performed -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnAirButton;
                @AirButton.canceled -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnAirButton;
                @FireButton.started -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnFireButton;
                @FireButton.performed -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnFireButton;
                @FireButton.canceled -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnFireButton;
                @WaterButton.started -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnWaterButton;
                @WaterButton.performed -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnWaterButton;
                @WaterButton.canceled -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnWaterButton;
                @EarthButton.started -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnEarthButton;
                @EarthButton.performed -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnEarthButton;
                @EarthButton.canceled -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnEarthButton;
                @StartButton.started -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnStartButton;
                @StartButton.performed -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnStartButton;
                @StartButton.canceled -= m_Wrapper.m_Actmap_Player01ActionsCallbackInterface.OnStartButton;
            }
            m_Wrapper.m_Actmap_Player01ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @AirButton.started += instance.OnAirButton;
                @AirButton.performed += instance.OnAirButton;
                @AirButton.canceled += instance.OnAirButton;
                @FireButton.started += instance.OnFireButton;
                @FireButton.performed += instance.OnFireButton;
                @FireButton.canceled += instance.OnFireButton;
                @WaterButton.started += instance.OnWaterButton;
                @WaterButton.performed += instance.OnWaterButton;
                @WaterButton.canceled += instance.OnWaterButton;
                @EarthButton.started += instance.OnEarthButton;
                @EarthButton.performed += instance.OnEarthButton;
                @EarthButton.canceled += instance.OnEarthButton;
                @StartButton.started += instance.OnStartButton;
                @StartButton.performed += instance.OnStartButton;
                @StartButton.canceled += instance.OnStartButton;
            }
        }
    }
    public Actmap_Player01Actions @actmap_Player01 => new Actmap_Player01Actions(this);

    // actmap_Player2
    private readonly InputActionMap m_actmap_Player2;
    private IActmap_Player2Actions m_Actmap_Player2ActionsCallbackInterface;
    private readonly InputAction m_actmap_Player2_Movement;
    private readonly InputAction m_actmap_Player2_AirButton;
    private readonly InputAction m_actmap_Player2_FireButton;
    private readonly InputAction m_actmap_Player2_WaterButton;
    private readonly InputAction m_actmap_Player2_EarthButton;
    private readonly InputAction m_actmap_Player2_StartButton;
    public struct Actmap_Player2Actions
    {
        private @_actionmap_Player01 m_Wrapper;
        public Actmap_Player2Actions(@_actionmap_Player01 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_actmap_Player2_Movement;
        public InputAction @AirButton => m_Wrapper.m_actmap_Player2_AirButton;
        public InputAction @FireButton => m_Wrapper.m_actmap_Player2_FireButton;
        public InputAction @WaterButton => m_Wrapper.m_actmap_Player2_WaterButton;
        public InputAction @EarthButton => m_Wrapper.m_actmap_Player2_EarthButton;
        public InputAction @StartButton => m_Wrapper.m_actmap_Player2_StartButton;
        public InputActionMap Get() { return m_Wrapper.m_actmap_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Actmap_Player2Actions set) { return set.Get(); }
        public void SetCallbacks(IActmap_Player2Actions instance)
        {
            if (m_Wrapper.m_Actmap_Player2ActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnMovement;
                @AirButton.started -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnAirButton;
                @AirButton.performed -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnAirButton;
                @AirButton.canceled -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnAirButton;
                @FireButton.started -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnFireButton;
                @FireButton.performed -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnFireButton;
                @FireButton.canceled -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnFireButton;
                @WaterButton.started -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnWaterButton;
                @WaterButton.performed -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnWaterButton;
                @WaterButton.canceled -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnWaterButton;
                @EarthButton.started -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnEarthButton;
                @EarthButton.performed -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnEarthButton;
                @EarthButton.canceled -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnEarthButton;
                @StartButton.started -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnStartButton;
                @StartButton.performed -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnStartButton;
                @StartButton.canceled -= m_Wrapper.m_Actmap_Player2ActionsCallbackInterface.OnStartButton;
            }
            m_Wrapper.m_Actmap_Player2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @AirButton.started += instance.OnAirButton;
                @AirButton.performed += instance.OnAirButton;
                @AirButton.canceled += instance.OnAirButton;
                @FireButton.started += instance.OnFireButton;
                @FireButton.performed += instance.OnFireButton;
                @FireButton.canceled += instance.OnFireButton;
                @WaterButton.started += instance.OnWaterButton;
                @WaterButton.performed += instance.OnWaterButton;
                @WaterButton.canceled += instance.OnWaterButton;
                @EarthButton.started += instance.OnEarthButton;
                @EarthButton.performed += instance.OnEarthButton;
                @EarthButton.canceled += instance.OnEarthButton;
                @StartButton.started += instance.OnStartButton;
                @StartButton.performed += instance.OnStartButton;
                @StartButton.canceled += instance.OnStartButton;
            }
        }
    }
    public Actmap_Player2Actions @actmap_Player2 => new Actmap_Player2Actions(this);

    // actmap_Player3
    private readonly InputActionMap m_actmap_Player3;
    private IActmap_Player3Actions m_Actmap_Player3ActionsCallbackInterface;
    private readonly InputAction m_actmap_Player3_Movement;
    private readonly InputAction m_actmap_Player3_AirButton;
    private readonly InputAction m_actmap_Player3_FireButton;
    private readonly InputAction m_actmap_Player3_WaterButton;
    private readonly InputAction m_actmap_Player3_EarthButton;
    private readonly InputAction m_actmap_Player3_StartButton;
    public struct Actmap_Player3Actions
    {
        private @_actionmap_Player01 m_Wrapper;
        public Actmap_Player3Actions(@_actionmap_Player01 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_actmap_Player3_Movement;
        public InputAction @AirButton => m_Wrapper.m_actmap_Player3_AirButton;
        public InputAction @FireButton => m_Wrapper.m_actmap_Player3_FireButton;
        public InputAction @WaterButton => m_Wrapper.m_actmap_Player3_WaterButton;
        public InputAction @EarthButton => m_Wrapper.m_actmap_Player3_EarthButton;
        public InputAction @StartButton => m_Wrapper.m_actmap_Player3_StartButton;
        public InputActionMap Get() { return m_Wrapper.m_actmap_Player3; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Actmap_Player3Actions set) { return set.Get(); }
        public void SetCallbacks(IActmap_Player3Actions instance)
        {
            if (m_Wrapper.m_Actmap_Player3ActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnMovement;
                @AirButton.started -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnAirButton;
                @AirButton.performed -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnAirButton;
                @AirButton.canceled -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnAirButton;
                @FireButton.started -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnFireButton;
                @FireButton.performed -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnFireButton;
                @FireButton.canceled -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnFireButton;
                @WaterButton.started -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnWaterButton;
                @WaterButton.performed -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnWaterButton;
                @WaterButton.canceled -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnWaterButton;
                @EarthButton.started -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnEarthButton;
                @EarthButton.performed -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnEarthButton;
                @EarthButton.canceled -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnEarthButton;
                @StartButton.started -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnStartButton;
                @StartButton.performed -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnStartButton;
                @StartButton.canceled -= m_Wrapper.m_Actmap_Player3ActionsCallbackInterface.OnStartButton;
            }
            m_Wrapper.m_Actmap_Player3ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @AirButton.started += instance.OnAirButton;
                @AirButton.performed += instance.OnAirButton;
                @AirButton.canceled += instance.OnAirButton;
                @FireButton.started += instance.OnFireButton;
                @FireButton.performed += instance.OnFireButton;
                @FireButton.canceled += instance.OnFireButton;
                @WaterButton.started += instance.OnWaterButton;
                @WaterButton.performed += instance.OnWaterButton;
                @WaterButton.canceled += instance.OnWaterButton;
                @EarthButton.started += instance.OnEarthButton;
                @EarthButton.performed += instance.OnEarthButton;
                @EarthButton.canceled += instance.OnEarthButton;
                @StartButton.started += instance.OnStartButton;
                @StartButton.performed += instance.OnStartButton;
                @StartButton.canceled += instance.OnStartButton;
            }
        }
    }
    public Actmap_Player3Actions @actmap_Player3 => new Actmap_Player3Actions(this);
    private int m__ControlScheme_DefaultSchemeIndex = -1;
    public InputControlScheme _ControlScheme_DefaultScheme
    {
        get
        {
            if (m__ControlScheme_DefaultSchemeIndex == -1) m__ControlScheme_DefaultSchemeIndex = asset.FindControlSchemeIndex("_ControlScheme_Default");
            return asset.controlSchemes[m__ControlScheme_DefaultSchemeIndex];
        }
    }
    public interface IActmap_Player01Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAirButton(InputAction.CallbackContext context);
        void OnFireButton(InputAction.CallbackContext context);
        void OnWaterButton(InputAction.CallbackContext context);
        void OnEarthButton(InputAction.CallbackContext context);
        void OnStartButton(InputAction.CallbackContext context);
    }
    public interface IActmap_Player2Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAirButton(InputAction.CallbackContext context);
        void OnFireButton(InputAction.CallbackContext context);
        void OnWaterButton(InputAction.CallbackContext context);
        void OnEarthButton(InputAction.CallbackContext context);
        void OnStartButton(InputAction.CallbackContext context);
    }
    public interface IActmap_Player3Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAirButton(InputAction.CallbackContext context);
        void OnFireButton(InputAction.CallbackContext context);
        void OnWaterButton(InputAction.CallbackContext context);
        void OnEarthButton(InputAction.CallbackContext context);
        void OnStartButton(InputAction.CallbackContext context);
    }
}
