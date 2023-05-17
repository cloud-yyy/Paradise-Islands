using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner<T> : MonoBehaviour, IPoolSpawnable where T : Entity
{
    [SerializeField] private int _poolSize;
    [SerializeField] private T[] _prefabs;

    private EntityPool<T> _pool;

    private void Start()
    {
        _pool = new EntityPool<T>(_prefabs, _poolSize);
    }

    public virtual void Spawn(Vector3 position) { }

    protected bool TrySpawn(Vector3 position)
    {
        if (_pool.HasElement())
        {
            var element = _pool.GetRandomElement(position);

            if (element == null) Debug.Log("null");

            element.Movement.StartMoving();
            return true;
        }
        return false;
    }
}
