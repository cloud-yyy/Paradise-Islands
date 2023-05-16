using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntitiesSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _tickTime;
    [SerializeField] private PathSpawner _pathSpawner;
    [SerializeField] private LootableSpawner _lootableSpawner;
    [SerializeField] private EnviromentSpawner _enviromentSpawner;

    private List<ITickable> _tickables;

    private void Start()
    {
        _tickables = new List<ITickable>() { _pathSpawner, _lootableSpawner, _enviromentSpawner };
    }

    public void StartSpawning() => StartCoroutine(StartTicking());

    public void StopSpawning() => StopAllCoroutines();

    private void Tick()
    {
        if (_pathSpawner.HasChunks())
        {
            foreach (var tickable in _tickables)
                tickable.Tick(_spawnPoint);
        }
    }

    private IEnumerator StartTicking()
    {
        while (true)
        {
            Tick();
            yield return new WaitForSeconds(_tickTime);
        }
    }
}
