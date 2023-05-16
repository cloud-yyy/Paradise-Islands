using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour, ITickable
{
    [SerializeField] private EntityMovement[] _entities;
    [SerializeField] private int _totalCount;
    [SerializeField] protected Transform SpawnPosition;

    protected PoolMono<EntityMovement> Pool;

    private void Start()
    {
        Pool = new PoolMono<EntityMovement>(_entities, SpawnPosition, _totalCount, false);
    }

    public virtual void Tick(Transform position)
    {
        
    }
}
