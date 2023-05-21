using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public event Action<int> OnFinished;
    public event Action OnDestroyed;

    private Slider _slider;
    private Jumper _jumper;
    private IInputHandler _inputHandler;
    private Barman _barman;

    private void Start()
    {
#if UNITY_STANDALONE
        _inputHandler = GetComponent<KeyboardInputHandler>();
#else
        _inputHandler = GetComponent<TouchInputHandler>();
#endif

        _slider = GetComponent<Slider>();
        _jumper = GetComponent<Jumper>();
        _barman = GetComponent<Barman>();

        _slider.Init(_inputHandler);
        _jumper.Init(_inputHandler);

        EnableMovement(false);
    }

    public void EnableMovement(bool enabled)
    {
        _slider.enabled = enabled;
        _jumper.enabled = enabled;
    }

    public void Destroy()
    {
        EnableMovement(false);
        OnDestroyed?.Invoke();

        gameObject.SetActive(false);
    }

    public void Finish()
    {
        EnableMovement(false);

        var coins = _barman.GetAllLootable();
        OnFinished?.Invoke(coins);
    }
}
