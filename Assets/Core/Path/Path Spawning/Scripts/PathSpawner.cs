using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawner : MonoBehaviour, ITickable
{
    [SerializeField] public Vector3 Offset { get; private set; }
    [SerializeField] private Transform _startPosition;
    [SerializeField] private int _poolTotalCount;

    [Header("Prefabs")]
    [SerializeField] private Obstacle[] _lowObstacles;
    [SerializeField] private Obstacle[] _highObstacles;
    [SerializeField] private Obstacle _barCounter;

    private PoolMono<Obstacle> _lowObstaclesPool;
    private PoolMono<Obstacle> _highObstaclesPool;
    private PoolMono<Obstacle> _barCountersPool;

    public Chunk[] ChunkedPath { get; private set; }
    public int CurrentIndex { get; private set; } = 0;

    public event Action<Vector3> OnSpawned;

    private void Start()
    {
        _lowObstaclesPool = new PoolMono<Obstacle>(_lowObstacles, _startPosition, _poolTotalCount, false);
        _highObstaclesPool = new PoolMono<Obstacle>(_highObstacles, _startPosition, _poolTotalCount, false);
        _barCountersPool = new PoolMono<Obstacle>(new[] { _barCounter }, _startPosition, 1, false);
    }

    public void Tick(Transform position)
    {
        if (ChunkedPath == null) throw new NullReferenceException(nameof(ChunkedPath));
        if (!HasChunks()) throw new InvalidOperationException();

        for (int i = 0; i < ChunkedPath.Length; i++)
        {
            PoolRandomElementByType(ChunkedPath[CurrentIndex].Items[i], out var element);
            element.transform.position += Offset * (i - 1);
            element.gameObject.SetActive(true);
        }

        CurrentIndex++;
    }

    private bool PoolRandomElementByType(ChunkItemType type, out Obstacle element)
    {
        PoolMono<Obstacle> pool = null;
        switch (type)
        {
            case ChunkItemType.Free:
                break;
            case ChunkItemType.LowObstacle:
                pool = _lowObstaclesPool;
                break;
            case ChunkItemType.HighObstacle:
                pool = _highObstaclesPool;
                break;
            case ChunkItemType.BarCounter:
                pool = _barCountersPool;
                break;
            default:
                throw new ArgumentException(nameof(type));
        }

        return TryPoolElement(pool, out element);
    }

    private bool TryPoolElement(PoolMono<Obstacle> pool, out Obstacle element)
    {
        if (pool.HasFreeElements())
        {
            element = _highObstaclesPool.GetFreeRandomElement(_startPosition.position);
            return true;
        }
        element = null;
        return false;
    }

    public void InitPath(Chunk[] path)
    {
        ChunkedPath = path;
    }

    public bool HasChunks() => CurrentIndex < ChunkedPath.Length;
}
