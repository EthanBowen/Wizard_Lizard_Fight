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
                    ""name"": ""Keyboard"",
                    ""id"": ""516c099c-d51b-4664-b5bf-6fff7db365b1"",
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
                    ""id"": ""434a1316-35cb-4ea5-875c-849fd075bec5"",
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
                    ""id"": ""a96efc1f-5b2a-4976-9793-45ef984b9b06"",
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
                    ""id"": ""638b2689-dcaf-4b07-a3da-79b556b5865c"",
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
                    ""id"": ""2707a925-e5cf-48dd-8d2d-7a092e27c18c"",
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
                    ""id"": ""c3b68b92-cdab-49ba-9360-b37247387518"",
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
                    ""id"": ""bdf409c0-3165-4bed-8ff1-9bf776b35080"",
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
                    ""id"": ""84710a13-ca7b-4961-8a52-b1d12cae4973"",
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
                    ""id"": ""62c53272-277f-43b5-85f4-3ac8ebb927bf"",
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
        }
    ],
    ""controlSchemes"": []
}");
        // actmap_Player01
        m_actmap_Player01 = asset.FindActionMap("actmap_Player01", throwIfNotFound: true);
        m_actmap_Player01_Movement = m_actmap_Player01.FindAction("Movement", throwIfNotFound: true);
        m_actmap_Player01_AirButton = m_actmap_Player01.FindAction("AirButton", throwIfNotFound: true);
        m_actmap_Player01_FireButton = m_actmap_Player01.FindAction("FireButton", throwIfNotFound: true);
        m_actmap_Player01_WaterButton = m_actmap_Player01.FindAction("WaterButton", throwIfNotFound: true);
        m_actmap_Player01_EarthButton = m_actmap_Player01.FindAction("EarthButton", throwIfNotFound: true);
        m_actmap_Player01_StartButton = m_actmap_Player01.FindAction("StartButton", throwIfNotFound: true);
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
    public interface IActmap_Player01Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAirButton(InputAction.CallbackContext context);
        void OnFireButton(InputAction.CallbackContext context);
        void OnWaterButton(InputAction.CallbackContext context);
        void OnEarthButton(InputAction.CallbackContext context);
        void OnStartButton(InputAction.CallbackContext context);
    }
}
