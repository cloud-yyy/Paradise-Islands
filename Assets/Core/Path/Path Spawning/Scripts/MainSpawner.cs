using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawner : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private ChunkSpawner _chunkSpawner;
    [SerializeField] private LootableSpawner _lootableSpawner;
    [SerializeField] private EnviromentSpawner _enviromentSpawner;

    [SerializeField] private Transform _position;
    [SerializeField] private float _tickTime;

    [SerializeField] private int _preStartSpawnCount;
    [SerializeField] private Vector3 _preStartOffset;

    public void InitPath(Chunk[] path)
    {
        _chunkSpawner.Init(path, _position.position);
        PreStartSpawnEntities(_position.position);
    }

    private void PreStartSpawnEntities(Vector3 position)
    {
        for (int i = 0; i < _preStartSpawnCount; i++)
        {
            var currentPosition = position + _preStartOffset * i;
            Spawn(currentPosition);
        }
    }
    private void OnEnable()
    {
        _character.OnStopped += StopEntities;
        _character.OnStopped += StopSpawning;
    }

    private void OnDisable()
    {
        _character.OnStopped -= StopEntities;
        _character.OnStopped -= StopSpawning;
    }
    
    private void StopEntities()
    {
        _chunkSpawner.StopAllEntities();
        _lootableSpawner.StopAllEntities();
        _enviromentSpawner.StopAllEntities();
    }

    public void StartSpawning() => StartCoroutine(Ticking());
    public void StopSpawning() => StopAllCoroutines();

    private IEnumerator Ticking()
    {
        while(true)
        {
            yield return new WaitForSeconds(_tickTime);
            Spawn(_position.position);
        }
    }

    public void Spawn(Vector3 position)
    {
        if (_chunkSpawner.CanSpawn)
        {
            _enviromentSpawner.Spawn(position);
            _chunkSpawner.Spawn(position);

            if (_chunkSpawner.CanSpawn)
                _lootableSpawner.Spawn(_chunkSpawner.PathItemPosition);
        }
    }
}
