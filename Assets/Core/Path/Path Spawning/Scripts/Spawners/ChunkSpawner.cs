using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField] private int _pathLength;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _highLootableOffset;

    [SerializeField] private ObstaclesSpawner _lowObstacleSpawner;
    [SerializeField] private ObstaclesSpawner _highObstacleSpawner;
    [SerializeField] private ChunkedPathGenerator _generator;
    [SerializeField] private BarCounter _barCounterPrefab;

    private List<Chunk> _path;
    private int _currentIndex = 0;

    public Vector3 PathItemPosition { get; private set; }
    public bool CanSpawn => _currentIndex < _path.Count;

    private void Start()
    {
        _path = _generator.CreatePath(_pathLength);
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
                SpawnBarCounter(position);
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
    }
}
