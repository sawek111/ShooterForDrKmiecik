using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shoot : Node
{
    private Enemy _enemy = null;
    private readonly Player _player = null;

    private float timer = 0f;

    public Shoot(DiContainer container)
    {
        _player = container.Resolve<Player>();
    }

    public override void ParticualEnter(Tick tick)
    {
        _enemy = tick.Target as Enemy;
    }

    public override NodeState ParticularTick(Tick tick)
    {
        _enemy.SetAnimationState(AnimationState.SHOT);
        _enemy.StopMoving();
        _enemy.LookAt(_player.Transform);

        if(timer >= 0.7f)
        {
            timer = 0f;
            _enemy.Shoot(_player.transform);
            return NodeState.SUCCESS;
        }

        timer += Time.deltaTime;
        return NodeState.RUNNING;
    }

}
