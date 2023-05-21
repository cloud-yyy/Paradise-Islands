using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPool<T> : PoolMono<T> where T : Entity
{
    public EntityPool(T[] prefabs, int size) : base(prefabs, size)
    {

    }
}
