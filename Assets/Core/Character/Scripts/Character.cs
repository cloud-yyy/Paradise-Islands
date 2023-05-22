using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public event Action<int> OnFinished;
    public event Action OnDestroyed;

    private CharacterAnimator _animator;

    private CharacterMovement _movement;
    private Barman _barman;

    private void Start()
    {
        _animator = GetComponent<CharacterAnimator>();
        _barman = GetComponent<Barman>();
        _movement = GetComponent<CharacterMovement>();
        EnableMovement(false);
    }

    public void EnableMovement(bool enabled)
    {
        _movement.enabled = enabled;
        if (enabled) _animator?.SetRunning();
    }

    public void Destroy()
    {
        EnableMovement(false);
        OnDestroyed?.Invoke();

        gameObject.SetActive(false);
    }

    public void Finish()
    {
        _animator.SetIdle();
        EnableMovement(false);

        var coins = _barman.GetAllLootable();
        OnFinished?.Invoke(coins);
    }
}
