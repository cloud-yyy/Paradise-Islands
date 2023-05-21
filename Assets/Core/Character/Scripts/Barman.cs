using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barman : MonoBehaviour
{
    [SerializeField] private LootCounter _counter;

    [SerializeField] private float _coinsPerLootable = 10f;
    private Character _character;

    private void Start()
    {
        _character = GetComponent<Character>();
    }

    public void Loot()
    {
        _counter.Add();
    }

    public int GetAllLootable()
    {
        var lootableCount = _counter.Count;
        _counter.Reset();
        return Mathf.RoundToInt(_coinsPerLootable * lootableCount);
    }
}
