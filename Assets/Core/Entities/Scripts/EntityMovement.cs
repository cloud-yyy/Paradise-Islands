using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private Vector3 _direction = Vector3.right;

    private bool _stopped;

    private Vector3 _deltaPosition;

    private void FixedUpdate()
    {
        transform.position += _deltaPosition;
    }

    public void StartMoving()
    {
        _deltaPosition = _direction * _speed * Time.fixedDeltaTime;
    }

    public void StopMoving()
    {
        _deltaPosition = Vector3.zero;
    }
}
