using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private const string IdleTrigger = "";
    private const string RunningTrigger = "";
    private const string JumpingTrigger = "";
    private const string DancingTrigger = "";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

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

    public void SetDancing()
    {
        _animator.SetTrigger(DancingTrigger);
    }
}
