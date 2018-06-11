using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour, IHealable, IHurtable
{
    private EnemyBehavior _behevior = null;
    private EnemyHealth _health = null;
    private EnemyAnimatorController _animatorController = null;
    private EnemyMover _enemyMover = null;
    private EnemyDistanceSkills _distanceSkills = null;

    private Shooter _shooter = null;

    [Inject]
    public void Construct(EnemyBehavior behevior, EnemyHealth health, EnemyAnimatorController animatorController, EnemyMover enemyMover, EnemyDistanceSkills distanceSkills, Shooter shooter)
    {
        _behevior = behevior;
        _health = health;
        _animatorController = animatorController;
        _enemyMover = enemyMover;
        _distanceSkills = distanceSkills;
        _shooter = shooter;
    }

    public void UpdateBehavior()
    {
        _behevior.FixedUpdate();
    }

    public bool IsEscaping
    {
        //TODO is escaping on behavior
        get; set;
    }

    public Vector3 EscapingTarget
    {
        //TODO  escaping mech behavior
        get;
    }

    public void CreateEscapingTarget()
    {
        //TODO  escaping mech behavior
    }

    public void Shoot()
    {
        _shooter.Shoot();
    }

    public void MoveTowards(Vector3 newPosition)
    {
        _enemyMover.MoveTo(newPosition);
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

    public void Heal(int value)
    {
        _health.ChangeHealth(value);
    }

    public void Hurt(int value)
    {
        _health.ChangeHealth(-value);
    }
}
