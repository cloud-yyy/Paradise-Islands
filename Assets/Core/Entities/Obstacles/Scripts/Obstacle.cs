using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Entity
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character character))
            character.Destroy();
    }
}
