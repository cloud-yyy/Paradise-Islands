using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    [SerializeField] private LootCounter _counter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterLooter looter))
        {
            _counter.Add();
            Destroy();
        }
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
