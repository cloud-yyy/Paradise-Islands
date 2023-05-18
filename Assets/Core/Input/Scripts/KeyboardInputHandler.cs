using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputHandler : MonoBehaviour, IInputHandler
{
    public event Action<float> OnVerticalInteracted;
    public event Action<float> OnHorizontalInteracted;
}
