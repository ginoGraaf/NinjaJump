using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    private Touch touch;
    public Action OnStartTouch;
    public Action OnEndTouch;

    public static InputManager Instance { get; set; }
    // Start is called before the first frame update
    private void Awake()
    {
        touch = new Touch();
        Instance = this;
    }

    private void OnEnable()
    {
        touch.Enable();
        TouchSimulation.Enable();
        EnhancedTouchSupport.Enable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
    }
    private void OnDisable()
    {
        touch.Disable();
        TouchSimulation.Disable();
        EnhancedTouchSupport.Disable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    private void Start()
    {
        //touch.TouchAction.TouchPress.started += ctx => StartTouch(ctx);
        //touch.TouchAction.TouchPress.canceled += ctx => EndTouch(ctx);
        //touch.TouchAction.TouchPress.performed += ctx => StartTouch(ctx);
    
    }

    private void StartTouch(InputAction.CallbackContext contex)
    {
        Debug.Log("Started: " + contex.ReadValue<float>());
        if(OnStartTouch!=null)
        {
            OnStartTouch();
        }
    }


    private void EndTouch(InputAction.CallbackContext contex)
    {
        Debug.Log("Ended: ");
        if(OnEndTouch!=null)
        {
            OnEndTouch();
        }
    }

    private void FingerDown(Finger finger)
    {
        if(OnStartTouch!=null)
        {
            OnStartTouch();
        }
    }

    private void Update()
    {

    }
}
