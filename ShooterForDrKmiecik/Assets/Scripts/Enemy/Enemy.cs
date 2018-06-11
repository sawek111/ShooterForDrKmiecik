using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    private EnemyBehavior _behevior = null;
    private EnemyHealth _health = null;
    private EnemyAnimatorController _animatorController = null;
    private EnemyMover _enemyMover = null;
    private EnemyDistanceSkills _distanceSkills = null;

    [Inject]
    public void Construct(EnemyBehavior behevior, EnemyHealth health, EnemyAnimatorController animatorController, EnemyMover enemyMover, EnemyDistanceSkills distanceSkills)
    {
        _behevior = behevior;
        _health = health;
        _animatorController = animatorController;
        _enemyMover = enemyMover;
        _distanceSkills = distanceSkills;
    }

    public void UpdateBehavior()
    {
        _behevior.FixedUpdate();
    }

    public int GetMaxHealth()
    {
        return _health.GetMaxHealth();
    }

    public void SetAnimationState(AnimationState state)
    {
        _animatorController.SetAnimationState(state);
    }

    public int GetCurrentHealth()
    {
        return _health.CurrentHealth;
    }

    public bool CanSeePlayer()
    {
        return _distanceSkills.CanSeePlayer();
    }

    public bool CanShootPlayer()
    {
        return _distanceSkills.CanShootPlayer();
    }

}
