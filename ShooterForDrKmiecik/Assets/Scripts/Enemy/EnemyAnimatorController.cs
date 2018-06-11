using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyAnimatorController
{
    [Inject] private Settings _settings = null;

    private readonly Animator _animator = null;

    public EnemyAnimatorController(Animator animator)
    {
        _animator = animator;
    }

    public void SetAnimationState(AnimationState state)
    {
        _animator.SetInteger(_settings.AnimatorStateString, (int)state);
    }

    [Serializable]
    public class Settings
    {
        public string AnimatorStateString;
    }
}
