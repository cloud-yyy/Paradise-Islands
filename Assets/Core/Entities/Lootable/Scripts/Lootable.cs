using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
