using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TouchInputHandler))]
public class Slider : MonoBehaviour
{
    [SerializeField] private Transform[] _positions;
    [SerializeField] private float _slideSpeed = 1f;
    [SerializeField] private AnimationCurve _curve;

    private PositionSwither _swither;
    private TouchInputHandler _inputHandler;
    private Transform _target;
    private CharacterAnimator _animator;

    private void Start()
    {
        _swither = new PositionSwither(_positions, 1);
        _target = _swither.CurrentPosition;

        _inputHandler = GetComponent<TouchInputHandler>();
        _inputHandler.OnSwipedHorizontal += Slide;

        _animator = GetComponent<CharacterAnimator>();
    }

    private void OnDisable()
    {
        _inputHandler.OnSwipedHorizontal -= Slide;
    }

    private void FixedUpdate()
    {
        if (transform.position.z != _target.position.z)
            transform.position = Vector3
                .Lerp(transform.position, _target.position, _curve.Evaluate(Time.deltaTime * _slideSpeed));
    }

    private void Slide(float direction)
    {
        if (direction > 0)
            _target = _swither.TryMoveRight();
        else
            _target = _swither.TryMoveLeft();
    }
}
