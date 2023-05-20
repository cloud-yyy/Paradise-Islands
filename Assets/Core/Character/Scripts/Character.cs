using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private LootCounter _counter;
    public event Action OnStopped;
    public event Action OnFinished;

    private int _lootableCount = 0;
    private Slider _slider;
    private Jumper _jumper;
    private IInputHandler _inputHandler;

    private void Start()
    {
#if UNITY_STANDALONE
        _inputHandler = GetComponent<KeyboardInputHandler>();
#else
        _inputHandler = GetComponent<TouchInputHandler>();
#endif

        _slider = GetComponent<Slider>();
        _jumper = GetComponent<Jumper>();

        _slider.Init(_inputHandler);
        _jumper.Init(_inputHandler);

        EnableMovement(false);
    }

    public void Loot()
    {
        _counter.Add();
        _lootableCount++;
    }

    public void EnableMovement(bool enabled)
    {
        _slider.enabled = enabled;
        _jumper.enabled = enabled;
    }

    public void Destroy()
    {
        EnableMovement(false);

        OnStopped?.Invoke();
    }

    public void Finish()
    {
        EnableMovement(false);

        OnStopped?.Invoke();
        OnFinished?.Invoke();
    }
}
