using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawner : MonoBehaviour
{
    [SerializeField] private ChunkSpawner _chunkSpawner;
    [SerializeField] private LootableSpawner _lootableSpawner;
    [SerializeField] private EnviromentSpawner _enviromentSpawner;

    [SerializeField] private Transform _position;
    [SerializeField] private float _tickTime;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
            StartSpawning();
        if (Input.GetKeyUp(KeyCode.W))
            StopSpawning();
    }

    public void StartSpawning() => StartCoroutine(Ticking());
    public void StopSpawning() => StopAllCoroutines();

    private IEnumerator Ticking()
    {
        while(true)
        {
            Spawn();
            yield return new WaitForSeconds(_tickTime);
        }
    }

    private void Spawn()
    {
        if (_chunkSpawner.CanSpawn)
        {
            _enviromentSpawner.Spawn(_position.position);
            _chunkSpawner.Spawn(_position.position);
            _lootableSpawner.Spawn(_chunkSpawner.PathItemPosition);
        }
    }
}
