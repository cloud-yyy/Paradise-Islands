using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private float _jumpDuration = 1.5f;
    [SerializeField] private AnimationCurve _curve;

    private TouchInputHandler _inputHandler;
    private bool _isJumping = false;

    private void Start()
    {
        _inputHandler = GetComponent<TouchInputHandler>();
        _inputHandler.OnTouched += TryJump;
    }

    private void OnDisable()
    {
        _inputHandler.OnTouched -= TryJump;
    }

    private void TryJump()
    {
        if (!_isJumping)
            StartCoroutine(StartJumping());
    }

    private IEnumerator StartJumping()
    {
        _isJumping = true;

        for (float t = 0; t < _jumpDuration; t += Time.deltaTime)
        {
            transform.position = new Vector3(transform.position.x, _curve.Evaluate(t / _jumpDuration) * _jumpHeight, transform.position.z);
            yield return null;
        }

        _isJumping = false;
    }
}
