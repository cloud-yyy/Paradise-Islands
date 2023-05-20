using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : Entity
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character character))
        {
            character.Loot();
            Destroy();
        }
    }


    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
