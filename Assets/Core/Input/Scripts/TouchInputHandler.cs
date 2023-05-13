using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInputHandler : MonoBehaviour
{
    [SerializeField] private float _horizontalSwipeCoefficient = 0.08f;
    [SerializeField] private float _verticalSwipeCoefficient = 0.12f;
    private Vector3 _lastPosition;

    public event Action OnSwipedVertical;
    public event Action<Vector3> OnSwipedHorizontal;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _lastPosition = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            var delta = Input.mousePosition - _lastPosition;

            if (delta.y >= Screen.height * _verticalSwipeCoefficient)
                OnSwipedVertical?.Invoke();
            else if (Mathf.Abs(delta.x) >= Screen.width * _horizontalSwipeCoefficient)
                OnSwipedHorizontal?.Invoke(delta);
        }
    }
}
