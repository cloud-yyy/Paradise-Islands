using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour, IEntitiesMover
{
    [SerializeField] private Vector3 _offsetByWidth;
    [SerializeField] private Vector3 _highLootableOffset;

    [Header("Spawners")]
    [SerializeField] private ObstaclesSpawner _lowObstacleSpawner;
    [SerializeField] private ObstaclesSpawner _highObstacleSpawner;
    [SerializeField] private BarCounterSpawner _barCounterSpawner;

    private Chunk[] _path;
    private int _currentIndex = 0;

    public Vector3 PathItemPosition { get; private set; }
    public bool CanSpawn => _path != null && _currentIndex < _path.Length;

    public void Init(Chunk[] path)
    {
        _path = path;
    }

    public void StartMovement()
    {
        _lowObstacleSpawner.StartMovement();
        _highObstacleSpawner.StartMovement();
        _barCounterSpawner.StartMovement();
    }

    public void StopMovement()
    {
        _lowObstacleSpawner.StopMovement();
        _highObstacleSpawner.StopMovement();
        _barCounterSpawner.StopMovement();
    }

    public void Spawn(Vector3 position, bool isMoving)
    {
        var chunk = _path[_currentIndex];

        for (int i = 0; i < chunk.Items.Length; i++)
        {
            var currentPosition = position + (i - 1) * _offsetByWidth;
            var type = chunk.Items[i];

            if (i == chunk.PathItemIndex)
                PathItemPosition = type == ChunkItemType.Free ? currentPosition : currentPosition + _highLootableOffset;

            if (type == ChunkItemType.BarCounter)
                _barCounterSpawner.Spawn(currentPosition, isMoving);
            if (type == ChunkItemType.LowObstacle)
                _lowObstacleSpawner.Spawn(currentPosition, isMoving);
            if (type == ChunkItemType.HighObstacle)
                _highObstacleSpawner.Spawn(currentPosition, isMoving);
        }
        _currentIndex++;
    }
}
