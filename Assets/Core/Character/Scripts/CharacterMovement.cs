using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private IInputHandler[] _inputHandlers;
    private Slider _slider;
    private Jumper _jumper;

    private void Start()
    {
        _inputHandlers = GetComponents<IInputHandler>();
        _slider = GetComponent<Slider>();
        _jumper = GetComponent<Jumper>();
        OnEnable();
    }

    public void OnEnable()
    {
        if (_inputHandlers != null)
            foreach (var handler in _inputHandlers)
            {
                handler.OnSlideDown += _jumper.TryFall;
                handler.OnSlideUp += _jumper.TryJump;
                handler.OnSlideLeft += _slider.SlideLeft;
                handler.OnSlideRight += _slider.SlideRight;
            }
    }

    public void OnDisable()
    {
        if (_inputHandlers != null)
            foreach (var handler in _inputHandlers)
            {
                handler.OnSlideDown -= _jumper.TryFall;
                handler.OnSlideUp -= _jumper.TryJump;
                handler.OnSlideLeft -= _slider.SlideLeft;
                handler.OnSlideRight -= _slider.SlideRight;
            }
    }
}
