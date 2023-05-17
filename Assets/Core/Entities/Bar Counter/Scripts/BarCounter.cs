using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCounter : Entity
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Barman barman))
        {
            Debug.Log("entered bar counter");

            // stop game
            // turn on animations, converting lootables into drinks than into coins
            // when animations finished, set dancing animations, end level
        }
    }
}
