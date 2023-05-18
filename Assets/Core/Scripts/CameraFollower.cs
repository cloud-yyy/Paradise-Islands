using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothing = 1f;

    private void FixedUpdate()
    {
        if (transform.position != _target.position + _offset)
            transform.position = Vector3.Lerp(transform.position, _target.position + _offset, Time.fixedDeltaTime * _smoothing);
    }
}
