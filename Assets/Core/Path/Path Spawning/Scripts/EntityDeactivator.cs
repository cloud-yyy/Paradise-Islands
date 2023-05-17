using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDeactivator : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Entity entity))
            entity.gameObject.SetActive(false);
    }
}
