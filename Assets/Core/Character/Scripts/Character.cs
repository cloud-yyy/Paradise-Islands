using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private LootCounter _counter;
    public event Action OnStopped;

    private int _lootableCount = 0;
    private Slider _slider;
    private Jumper _jumper;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _jumper = GetComponent<Jumper>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Lootable lootable))
        {
            _counter.Add();
            _lootableCount++;
            lootable.Destroy();
        }
    }

    public void Destroy()
    {
        _slider.enabled = false;
        _jumper.enabled = false;

        OnStopped?.Invoke();
    }

    public void Finish()
    {
        _slider.enabled = false;
        _jumper.enabled = false;

        OnStopped?.Invoke();
    }
}
