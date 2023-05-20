using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawner : MonoBehaviour, IEntitiesMover
{
    [SerializeField] private Character _character;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _tickTime;

    [Header("Spawners")]
    [SerializeField] private ChunkSpawner _chunkSpawner;
    [SerializeField] private LootableSpawner _lootableSpawner;
    [SerializeField] private EnviromentSpawner _enviromentSpawner;

    [Header("Pre-Start")]
    [SerializeField] private int _preStartSpawnCount;
    [SerializeField] private Vector3 _preStartOffset;

    public void InitPath(Chunk[] path)
    {
        _chunkSpawner.Init(path);
        PreStartSpawnEntities(_startPosition.position);
    }

    private void PreStartSpawnEntities(Vector3 position)
    {
        for (int i = 0; i < _preStartSpawnCount; i++)
        {
            var currentPosition = position + _preStartOffset * i;
            Spawn(currentPosition, false);
        }
    }
    private void OnEnable()
    {
        _character.OnStopped += Stop;
    }

    private void OnDisable()
    {
        _character.OnStopped -= Stop;
    }

    public void Run()
    {
        _character.EnableMovement(true);

        StartCoroutine(Ticking());
        StartMovement();
    }

    public void Stop()
    {
        StopAllCoroutines();
        StopMovement();
    }

    private IEnumerator Ticking()
    {
        while(true)
        {
            yield return new WaitForSeconds(_tickTime);
            Spawn(_startPosition.position, true);
        }
    }

    private void Spawn(Vector3 position, bool isMoving)
    {
        if (_chunkSpawner.CanSpawn)
        {
            _enviromentSpawner.Spawn(position, isMoving);
            _chunkSpawner.Spawn(position, isMoving);

            if (_chunkSpawner.CanSpawn)
                _lootableSpawner.Spawn(_chunkSpawner.PathItemPosition, isMoving);
        }
    }

    public void StartMovement()
    {
        _chunkSpawner.StartMovement();
        _lootableSpawner.StartMovement();
        _enviromentSpawner.StartMovement();
    }

    public void StopMovement()
    {
        _chunkSpawner.StopMovement();
        _lootableSpawner.StopMovement();
        _enviromentSpawner.StopMovement();
    }
}
