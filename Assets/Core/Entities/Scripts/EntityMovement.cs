using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 37f;
    [SerializeField] private float _smoothingTime = 0.5f;
    [SerializeField] private Vector3 _direction = Vector3.right;
    [SerializeField] private AnimationCurve _curve;

    private Vector3 _deltaPosition = Vector3.zero;

    private void FixedUpdate()
    {
        transform.position += _deltaPosition;

        if (Input.GetKey(KeyCode.Q)) StartMovement();
        if (Input.GetKey(KeyCode.W)) StopMovement();
    }

    public void StartMovement()
    {
        StartCoroutine(StartSmoothed());
    }

    public void StopMovement()
    {
        StartCoroutine(StopSmoothed());
    }

    private IEnumerator StopSmoothed()
    {
        for (float t = _smoothingTime; t >= 0f; t -= Time.fixedDeltaTime)
        {
            _deltaPosition  = _direction * _curve.Evaluate(t / _smoothingTime) * _speed * Time.fixedDeltaTime;
            yield return null;
        }
    }

    private IEnumerator StartSmoothed()
    {
        for (float t = 0; t < _smoothingTime; t += Time.fixedDeltaTime)
        {
            _deltaPosition = _direction * _curve.Evaluate(t / _smoothingTime) * _speed * Time.fixedDeltaTime;
            yield return null;
        }
    }
}
