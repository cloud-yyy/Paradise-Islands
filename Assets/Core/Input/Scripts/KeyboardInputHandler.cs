using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInputHandler : MonoBehaviour, IInputHandler
{
    public event Action OnSlideUp;
    public event Action OnSlideDown;
    public event Action OnSlideRight;
    public event Action OnSlideLeft;

    private GameInput _input;

    private void Awake()
    {
        _input = new GameInput();
        _input.Enable();
    }

    private void OnEnable()
    {
        _input.Gameplay.HorizontalMovement.performed += MoveHorizontal;
        _input.Gameplay.VerticalMovement.performed += MoveVertical;
    }

    private void OnDisable()
    {
        _input.Gameplay.HorizontalMovement.performed -= MoveHorizontal;
        _input.Gameplay.VerticalMovement.performed -= MoveVertical;
    }

    private void MoveHorizontal(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();

        if (value > 0) OnSlideRight?.Invoke();
        else OnSlideLeft?.Invoke();
    }

    private void MoveVertical(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();

        if (value > 0) OnSlideUp?.Invoke();
        else OnSlideDown?.Invoke();
    }
}
