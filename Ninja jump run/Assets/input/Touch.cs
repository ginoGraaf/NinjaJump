// GENERATED AUTOMATICALLY FROM 'Assets/input/Touch.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Touch : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Touch()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Touch"",
    ""maps"": [
        {
            ""name"": ""TouchAction"",
            ""id"": ""2f244747-9fff-4102-a817-db2cf88804e4"",
            ""actions"": [
                {
                    ""name"": ""TouchInput"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4e53ed23-c8f5-4a62-9ad1-a8b0c84405a5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""4aa6473b-b775-48d8-acde-1af8d6690637"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap(duration=0.3)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e3c6c138-1246-4efa-ba66-288b012f18c6"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8e5be45-921f-4a4f-9ab3-cde7004dad31"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TouchAction
        m_TouchAction = asset.FindActionMap("TouchAction", throwIfNotFound: true);
        m_TouchAction_TouchInput = m_TouchAction.FindAction("TouchInput", throwIfNotFound: true);
        m_TouchAction_TouchPress = m_TouchAction.FindAction("TouchPress", throwIfNotFound: true);
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

    // TouchAction
    private readonly InputActionMap m_TouchAction;
    private ITouchActionActions m_TouchActionActionsCallbackInterface;
    private readonly InputAction m_TouchAction_TouchInput;
    private readonly InputAction m_TouchAction_TouchPress;
    public struct TouchActionActions
    {
        private @Touch m_Wrapper;
        public TouchActionActions(@Touch wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchInput => m_Wrapper.m_TouchAction_TouchInput;
        public InputAction @TouchPress => m_Wrapper.m_TouchAction_TouchPress;
        public InputActionMap Get() { return m_Wrapper.m_TouchAction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActionActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActionActions instance)
        {
            if (m_Wrapper.m_TouchActionActionsCallbackInterface != null)
            {
                @TouchInput.started -= m_Wrapper.m_TouchActionActionsCallbackInterface.OnTouchInput;
                @TouchInput.performed -= m_Wrapper.m_TouchActionActionsCallbackInterface.OnTouchInput;
                @TouchInput.canceled -= m_Wrapper.m_TouchActionActionsCallbackInterface.OnTouchInput;
                @TouchPress.started -= m_Wrapper.m_TouchActionActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_TouchActionActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_TouchActionActionsCallbackInterface.OnTouchPress;
            }
            m_Wrapper.m_TouchActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchInput.started += instance.OnTouchInput;
                @TouchInput.performed += instance.OnTouchInput;
                @TouchInput.canceled += instance.OnTouchInput;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
            }
        }
    }
    public TouchActionActions @TouchAction => new TouchActionActions(this);
    public interface ITouchActionActions
    {
        void OnTouchInput(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
    }
}
