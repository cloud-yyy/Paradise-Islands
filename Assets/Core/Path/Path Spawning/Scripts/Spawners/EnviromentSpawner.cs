using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentSpawner : EntitySpawner<Enviroment>
{
    [SerializeField] private Vector3 _offset;

    public override void Spawn(Vector3 position, bool isMoving)
    {
        TrySpawn(position + _offset, isMoving, out var entity1);
        TrySpawn(position - _offset, isMoving, out var entity2);
    }
}
