using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TouchInputHandler))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private float _jumpDuration = 1.5f;
    [SerializeField] private float _fallDuration = 0.4f;
    [SerializeField] private AnimationCurve _jumpingCurve;
    [SerializeField] private AnimationCurve _fallingCurve;

    private TouchInputHandler _inputHandler;
    private CharacterAnimator _animator;
    private bool _isJumping = false;

    private void Start()
    {
        _inputHandler = GetComponent<TouchInputHandler>();
        _inputHandler.OnSwipedVertical += TryJump;

        _animator = GetComponent<CharacterAnimator>();
    }

    private void OnDisable()
    {
        _inputHandler.OnSwipedVertical -= TryJump;
    }

    private void TryJump(float direction)
    {
        if (direction > 0 && !_isJumping)
            StartCoroutine(StartJumping());

        if (direction < 0 && _isJumping)
        {
            StopAllCoroutines();
            StartCoroutine(StartFalling());
        }
    }

    private IEnumerator StartJumping()
    {
        _isJumping = true;

        for (float t = 0; t < _jumpDuration; t += Time.deltaTime)
        {
            transform.position = new Vector3(transform.position.x, _jumpingCurve.Evaluate(t / _jumpDuration) * _jumpHeight, transform.position.z);
            yield return null;
        }

        _isJumping = false;
    }

    private IEnumerator StartFalling()
    {
        var deltaY = transform.position.y;
        var fallDuration = deltaY / _jumpHeight * _fallDuration;

        for (float t = 0; t <= fallDuration; t += Time.deltaTime)
        {
            transform.position = new Vector3(transform.position.x, _fallingCurve.Evaluate(t / fallDuration) * deltaY, transform.position.z);
            yield return null;
        }

        _isJumping = false;
    }
}
