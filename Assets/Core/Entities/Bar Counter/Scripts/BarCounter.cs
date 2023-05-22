using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCounter : Entity
{
    [SerializeField] private float _coinsPerLootable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character character))
        {
            character.Finish();
        }
    }
}
