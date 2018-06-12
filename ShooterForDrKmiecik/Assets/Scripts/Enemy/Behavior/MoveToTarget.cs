using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : Node
{
    private Enemy _enemy = null;

    public override void ParticualEnter(Tick tick)
    {
        _enemy = tick.Target as Enemy;
    }

    public override NodeState ParticularTick(Tick tick)
    {
        _enemy.SetAnimationState(AnimationState.RUN);
        _enemy.MoveToTarget();
        if(_enemy.IsInTarget)
        {
            _enemy.RemoveTarget();
            return NodeState.SUCCESS;
        }

        return NodeState.RUNNING;
    }

}

