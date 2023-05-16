using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootableSpawner : EntitySpawner<Lootable>
{
    public override void Spawn(Vector3 position)
    {
        TrySpawn(position);
    }
}
