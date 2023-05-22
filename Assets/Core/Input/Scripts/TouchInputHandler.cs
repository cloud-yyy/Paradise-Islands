using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInputHandler : MonoBehaviour, IInputHandler
{
    [SerializeField] private float _minSwipeMagnitude = 0.08f;
    private Vector3 _lastPosition;

    public event Action OnSlideUp;
    public event Action OnSlideDown;
    public event Action OnSlideRight;
    public event Action OnSlideLeft;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _lastPosition = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            var delta = Input.mousePosition - _lastPosition;

            if (delta.magnitude > Screen.width * _minSwipeMagnitude)
            {
                if (Math.Abs(delta.y) >= Math.Abs(delta.x))
                {
                    if (delta.y >= 0) OnSlideUp?.Invoke();
                    else OnSlideDown?.Invoke();
                }
                else
                {
                    if (delta.x >= 0) OnSlideRight?.Invoke();
                    else OnSlideLeft?.Invoke();
                }

            }
        }
    }
}
