using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputHandler
{
    public event Action<float> OnVerticalInteracted;
    public event Action<float> OnHorizontalInteracted;
}
