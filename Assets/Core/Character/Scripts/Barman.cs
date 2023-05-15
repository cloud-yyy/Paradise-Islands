using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barman : MonoBehaviour
{
    [SerializeField] private LootCounter _counter;
    private int _lootableCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Lootable lootable))
        {
            _counter.Add();
            _lootableCount++;
            lootable.Destroy();
        }
    }
}
