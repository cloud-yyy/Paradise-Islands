using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : Entity
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Barman barman))
        {
            barman.Loot();
            Destroy();
        }
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
