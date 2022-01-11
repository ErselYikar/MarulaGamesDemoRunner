// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""TouchMovement"",
            ""id"": ""2ec3b8ce-74d9-4d08-bc28-1c692976cfbc"",
            ""actions"": [
                {
                    ""name"": ""Touch"",
                    ""type"": ""Button"",
                    ""id"": ""56fab8da-f5c5-4642-9536-bc9e5d3f5c19"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Delta"",
                    ""type"": ""Value"",
                    ""id"": ""beb1b547-b67e-4943-afb7-e61651a3eb61"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""dda97dd6-efe7-4d4a-9da7-ec26147c4820"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""61075de5-eee5-4067-88a6-4f4add4e67f8"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""037ac87b-1da3-4ac2-ad54-c8cdf9bd2a6c"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""343eb534-7506-480b-8d57-ca02a3b1faf1"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TouchMovement
        m_TouchMovement = asset.FindActionMap("TouchMovement", throwIfNotFound: true);
        m_TouchMovement_Touch = m_TouchMovement.FindAction("Touch", throwIfNotFound: true);
        m_TouchMovement_Delta = m_TouchMovement.FindAction("Delta", throwIfNotFound: true);
        m_TouchMovement_Position = m_TouchMovement.FindAction("Position", throwIfNotFound: true);
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

    // TouchMovement
    private readonly InputActionMap m_TouchMovement;
    private ITouchMovementActions m_TouchMovementActionsCallbackInterface;
    private readonly InputAction m_TouchMovement_Touch;
    private readonly InputAction m_TouchMovement_Delta;
    private readonly InputAction m_TouchMovement_Position;
    public struct TouchMovementActions
    {
        private @PlayerInput m_Wrapper;
        public TouchMovementActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Touch => m_Wrapper.m_TouchMovement_Touch;
        public InputAction @Delta => m_Wrapper.m_TouchMovement_Delta;
        public InputAction @Position => m_Wrapper.m_TouchMovement_Position;
        public InputActionMap Get() { return m_Wrapper.m_TouchMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchMovementActions set) { return set.Get(); }
        public void SetCallbacks(ITouchMovementActions instance)
        {
            if (m_Wrapper.m_TouchMovementActionsCallbackInterface != null)
            {
                @Touch.started -= m_Wrapper.m_TouchMovementActionsCallbackInterface.OnTouch;
                @Touch.performed -= m_Wrapper.m_TouchMovementActionsCallbackInterface.OnTouch;
                @Touch.canceled -= m_Wrapper.m_TouchMovementActionsCallbackInterface.OnTouch;
                @Delta.started -= m_Wrapper.m_TouchMovementActionsCallbackInterface.OnDelta;
                @Delta.performed -= m_Wrapper.m_TouchMovementActionsCallbackInterface.OnDelta;
                @Delta.canceled -= m_Wrapper.m_TouchMovementActionsCallbackInterface.OnDelta;
                @Position.started -= m_Wrapper.m_TouchMovementActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_TouchMovementActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_TouchMovementActionsCallbackInterface.OnPosition;
            }
            m_Wrapper.m_TouchMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Touch.started += instance.OnTouch;
                @Touch.performed += instance.OnTouch;
                @Touch.canceled += instance.OnTouch;
                @Delta.started += instance.OnDelta;
                @Delta.performed += instance.OnDelta;
                @Delta.canceled += instance.OnDelta;
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
            }
        }
    }
    public TouchMovementActions @TouchMovement => new TouchMovementActions(this);
    public interface ITouchMovementActions
    {
        void OnTouch(InputAction.CallbackContext context);
        void OnDelta(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
    }
}
