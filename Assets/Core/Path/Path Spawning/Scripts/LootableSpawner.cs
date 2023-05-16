using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootableSpawner : EntitySpawner
{
    public override void Tick(Transform position)
    {
        if (Pool.HasFreeElements(out var elements) && elements.Count > 0)
            Pool.GetFreeElement(position.position);
    }
}
