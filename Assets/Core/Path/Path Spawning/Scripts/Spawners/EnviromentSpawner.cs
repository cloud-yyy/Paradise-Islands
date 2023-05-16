using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentSpawner : EntitySpawner<Enviroment>
{
    [SerializeField] private Vector3 _offset;

    public override void Spawn(Vector3 position)
    {
        TrySpawn(position + _offset);
        TrySpawn(position - _offset);
    }
}
