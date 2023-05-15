using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInputHandler : MonoBehaviour
{
    [SerializeField] private float _minSwipeMagnitude = 0.08f;
    private Vector3 _lastPosition;

    public event Action<float> OnSwipedVertical;
    public event Action<float> OnSwipedHorizontal;

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
                    OnSwipedVertical?.Invoke(delta.y);
                else
                    OnSwipedHorizontal?.Invoke(delta.x);

            }
        }
    }
}
