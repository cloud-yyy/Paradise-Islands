using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : EntitySpawner<Obstacle>
{
    public override void Spawn(Vector3 position)
    {
        TrySpawn(position);
    }
}
