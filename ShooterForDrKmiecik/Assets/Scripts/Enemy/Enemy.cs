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

  
    public bool IsInTarget
    {
        get { return _enemyMover.IsInTarget; }
    }

    public TargetType TargetType
    {
        get { return _enemyMover.TargetType; }
    }


    public PatrolState PatrolState
    {
        get { return _behevior.PatrolState; }
        set { _behevior.PatrolState = value; }
    }

    public void MoveToTarget()
    {
        _enemyMover.MoveToTarget();
    }

    public void SetNewTarget(Vector3 newTargetPosition, TargetType targetType)
    {
        _enemyMover.SetNewTarget(newTargetPosition, targetType);
    }

    public void RemoveTarget()
    {
        _enemyMover.RemoveTarget();
    }

    public Vector3 PrepareEscapePosition(Vector3 playerPos)
    {
        return _enemyMover.PrepareEscapePosition(playerPos);
    }

    public bool IsDead
    {
        get { return _health.CurrentHealth <= 0; }
    }

    public void Shoot()
    {
        _shooter.Shoot();
    }

    public void SetAnimationState(AnimationState state)
    {
        _animatorController.SetAnimationState(state);
    }

    public bool CanSeePlayer()
    {
        return _distanceSkills.CanSeePlayer();
    }

    public bool CanShootPlayer()
    {
        return _distanceSkills.CanShootPlayer();
    }

    #region Health

    public void Heal(int value)
    {
        _health.ChangeHealth(value);
    }

    public void Hurt(int value)
    {
        _health.ChangeHealth(-value);
    }

    public int GetCurrentHealth()
    {
        return _health.CurrentHealth;
    }

    public int GetMaxHealth()
    {
        return _health.GetMaxHealth();
    }

    #endregion Health

    public class Factory : Factory<Enemy>{}
}
