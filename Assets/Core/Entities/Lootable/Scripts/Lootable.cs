using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : Entity
{
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
