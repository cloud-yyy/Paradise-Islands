using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private const string IdleTrigger = "Idle";
    private const string RunningTrigger = "Running";
    private const string JumpingTrigger = "Jumping";

    [SerializeField] private Animator _animator;

    public void SetIdle()
    {
        _animator.SetTrigger(IdleTrigger);
    }

    public void SetRunning()
    {
        _animator.SetTrigger(RunningTrigger);
    }

    public void SetJumping()
    {
        _animator.SetTrigger(JumpingTrigger);
    }

    public void SetDie()
    {

    }
}
