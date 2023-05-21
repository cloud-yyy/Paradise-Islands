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
            Debug.Log("entered bar counter");
            character.Finish();
            // stop game
            // turn on animations, converting lootables into drinks than into coins
            // when animations finished, set dancing animations, end level
        }
    }
}
