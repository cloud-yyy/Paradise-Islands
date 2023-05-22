using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public event Action<int> OnFinished;
    public event Action OnDestroyed;

    private CharacterMovement _movement;
    private Barman _barman;

    private void Start()
    {
        _barman = GetComponent<Barman>();
        _movement = GetComponent<CharacterMovement>();
        EnableMovement(false);
    }

    public void EnableMovement(bool enabled) => _movement.enabled = enabled;

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
