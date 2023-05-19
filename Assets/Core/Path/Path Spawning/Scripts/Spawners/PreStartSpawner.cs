using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreStartSpawner : MonoBehaviour
{
    [SerializeField] private MainSpawner _spawner;
    [SerializeField] private Transform _position;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private int _count;

    // public void SpawnEntities()
    // {
    //     for (int i = 0; i < _count; i++)
    //     {
    //         var position = _position.position + _offset * i;
    //         _spawner.Spawn(position);
    //     }
    // }
}
