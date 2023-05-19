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
    private IInputHandler _inputHandler;
    private Transform _target;
    private CharacterAnimator _animator;

    private void Start()
    {
        _swither = new PositionSwither(_positions, 1);
        _target = _swither.CurrentPosition;
        _animator = GetComponent<CharacterAnimator>();
    }

    public void Init(IInputHandler handler)
    {
        _inputHandler = handler;
        OnEnable();
    }

    private void OnEnable()
    {
        if (_inputHandler != null)
        {
            _inputHandler.OnSlideLeft += SlideLeft;
            _inputHandler.OnSlideRight += SlideRight;
        }
    }

    private void OnDisable()
    {
        _inputHandler.OnSlideRight -= SlideRight;
        _inputHandler.OnSlideLeft -= SlideLeft;
    }

    private void FixedUpdate()
    {
        if (transform.position.z != _target.position.z)
            transform.position = Vector3.Lerp(transform.position, _target.position, _curve.Evaluate(Time.deltaTime * _slideSpeed));
    }

    private void SlideRight() => _target = _swither.TryMoveRight();
    private void SlideLeft() => _target = _swither.TryMoveLeft();
}
