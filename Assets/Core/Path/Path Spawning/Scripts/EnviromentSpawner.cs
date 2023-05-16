using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentSpawner : EntitySpawner
{
    [SerializeField] private Vector3 _offset;

    public override void Tick(Transform position)
    {
        if (Pool.HasFreeElements(out var elements) && elements.Count >= 2)
        {
            PoolElement(position.position + _offset);
            PoolElement(position.position - _offset);
        }
    }

    private void PoolElement(Vector3 position)
    {
        var element = Pool.GetFreeRandomElement(position);
        element.gameObject.SetActive(true);
    }
}
