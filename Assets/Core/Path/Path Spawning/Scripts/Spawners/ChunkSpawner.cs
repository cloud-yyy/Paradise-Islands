using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour, IPoolSpawnable
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _highLootableOffset;

    [Header("Spawners")]
    [SerializeField] private ObstaclesSpawner _lowObstacleSpawner;
    [SerializeField] private ObstaclesSpawner _highObstacleSpawner;
    [SerializeField] private BarCounterSpawner _barCounterSpawner;
    [SerializeField] private BarCounter _barCounterPrefab;

    private Chunk[] _path;
    private int _currentIndex = 0;

    public Vector3 PathItemPosition { get; private set; }
    public bool CanSpawn => _path != null && _currentIndex < _path.Length;

    public void Init(Chunk[] path, Vector3 startPosition)
    {
        _path = path;
    }


    public void StopAllEntities()
    {
        _lowObstacleSpawner.StopAllEntities();
        _highObstacleSpawner.StopAllEntities();
        _barCounterSpawner.StopAllEntities();
    }

    public void Spawn(Vector3 position)
    {
        var chunk = _path[_currentIndex];

        for (int i = 0; i < chunk.Items.Length; i++)
        {
            var currentPosition = position + (i - 1) * _offset;
            var type = chunk.Items[i];

            if (i == chunk.PathItemIndex)
                PathItemPosition = type == ChunkItemType.Free ? currentPosition : currentPosition + _highLootableOffset;

            if (type == ChunkItemType.BarCounter)
                _barCounterSpawner.Spawn(currentPosition);
            if (type == ChunkItemType.LowObstacle)
                _lowObstacleSpawner.Spawn(currentPosition);
            if (type == ChunkItemType.HighObstacle)
                _highObstacleSpawner.Spawn(currentPosition);
        }
        _currentIndex++;
    }

    private void SpawnBarCounter(Vector3 position)
    {
        var element = Object.Instantiate(_barCounterPrefab);
        element.transform.position = position;
        element.gameObject.SetActive(true);
        element.Movement.StartMoving();
    }
}
