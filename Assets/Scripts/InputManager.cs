using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputManager : MonoBehaviour
{
    public delegate void StartTouchEvent(Vector2 position);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position);
    public event EndTouchEvent OnEndTouch;

    public Controls Controls { get; private set; }

    private void Awake()
    {
        Controls = new Controls();
    }

    private void OnEnable()
    {
        Controls.Enable();
    }

    private void OnDisable()
    {
        Controls.Disable();
    }

    private void Start()
    {
        Controls.Touch.Press.started += ctx => StartTouch(ctx);
        Controls.Touch.Press.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    { 
        Debug.Log("Touch started: " + Controls.Touch.Position.ReadValue<Vector2>());
        if (OnStartTouch != null)
        {
            OnStartTouch(Controls.Touch.Position.ReadValue<Vector2>());
        }
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch canceled: " + Controls.Touch.Position.ReadValue<Vector2>());
        if (OnEndTouch != null)
        {
            OnEndTouch(Controls.Touch.Position.ReadValue<Vector2>());
        }
    }
}
