using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner<T> : MonoBehaviour, IPoolSpawnable where T : MonoBehaviour
{
    [SerializeField] private int _poolSize;
    [SerializeField] private T[] _prefabs;

    private PoolMono<T> _pool;

    private void Start()
    {
        _pool = new PoolMono<T>(_prefabs, _poolSize);
    }

    public virtual void Spawn(Vector3 position) { }

    protected bool TrySpawn(Vector3 position)
    {
        if (_pool.HasElement())
        {
            _pool.GetRandomElement(position);
            return true;
        }
        return false;
    }
}
