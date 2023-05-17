using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityMovement))]
public class Entity : MonoBehaviour
{
    public EntityMovement Movement { get; private set; }

    private void Awake()
    {
        Movement = GetComponent<EntityMovement>();
    }
}
