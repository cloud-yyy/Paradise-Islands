using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputHandler
{
    public event Action OnSlideUp;
    public event Action OnSlideDown;
    public event Action OnSlideRight;
    public event Action OnSlideLeft;
}
