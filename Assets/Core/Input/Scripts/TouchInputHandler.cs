using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInputHandler : MonoBehaviour
{
    [SerializeField] private float _minDeltaSwipeCoefficient = 0.08f;
    private Vector3 _lastPosition;

    public event Action OnTouched;
    public event Action<Vector3> OnSwiped;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _lastPosition = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            var delta = Input.mousePosition - _lastPosition;

            if (Mathf.Abs(delta.x) >= Screen.width * _minDeltaSwipeCoefficient)
                OnSwiped?.Invoke(delta);
            else 
                OnTouched?.Invoke();
        }
    }
}
