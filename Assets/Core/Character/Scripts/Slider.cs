using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IInputHandler))]
public class Slider : MonoBehaviour
{
    [SerializeField] private Transform[] _positions;
    [SerializeField] private float _slideSpeed = 1f;
    [SerializeField] private AnimationCurve _curve;

    private PositionSwither _swither;
    private Transform _target;
    private CharacterAnimator _animator;

    private void Start()
    {
        _swither = new PositionSwither(_positions, 1);
        _target = _swither.CurrentPosition;
        _animator = GetComponent<CharacterAnimator>();
    }

    private void FixedUpdate()
    {
        if (transform.position.z != _target.position.z)
            transform.position = Vector3.Lerp(transform.position, _target.position, _curve.Evaluate(Time.deltaTime * _slideSpeed));
    }

    public void SlideRight() => _target = _swither.TryMoveRight();
    public void SlideLeft() => _target = _swither.TryMoveLeft();
}
