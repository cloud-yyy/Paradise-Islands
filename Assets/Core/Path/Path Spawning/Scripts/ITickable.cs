using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITickable
{
    public void Tick(Transform position);
}
