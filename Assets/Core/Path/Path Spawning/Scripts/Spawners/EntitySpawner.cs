using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner<T> : MonoBehaviour, IPoolSpawnable<T>, IEntitiesMover where T : Entity
{
    [SerializeField] private int _poolSize;
    [SerializeField] private T[] _prefabs;

    private EntityPool<T> _pool;

    private void Awake()
    {
        _pool = new EntityPool<T>(_prefabs, _poolSize);
    }

    public bool CanSpawn() => _pool.HasElement();

    public bool TrySpawn(Vector3 position, bool isMoving, out T entity)
    {
        if (CanSpawn())
        {
            entity = _pool.GetRandomElement(position);
            if (isMoving) entity.Movement.StartMoving();
            return true;
        }
        entity = null;
        return false;
    }

    public virtual void Spawn(Vector3 position, bool isMoving)
    {
        if (!TrySpawn(position, isMoving, out var entity))
            throw new InvalidOperationException();
    }

    public void StopMovement()
    {
        var freeEntities = _pool.GetActiveElements();

        foreach (var item in freeEntities)
            item.Movement.StopMoving();
    }

    public void StartMovement()
    {
        var freeEntities = _pool.GetActiveElements();

        foreach (var item in freeEntities)
            item.Movement.StartMoving();
    }
}
