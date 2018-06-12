using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : Node
{
    private const float DESTINATION_AVAILABLE_OFFSET = 0.5f;

    private Enemy _enemy = null;

    public override void ParticualEnter(Tick tick)
    {
        _enemy = tick.Target as Enemy;
    }

    public override NodeState ParticularTick(Tick tick)
    {
        _enemy.SetAnimationState(AnimationState.RUN);

        if(!_enemy.IsEscaping)
        {
            _enemy.CreateEscapingTarget();
        }

        _enemy.MoveTowards(_enemy.EscapingTarget);
        if((_enemy.transform.position - _enemy.EscapingTarget).sqrMagnitude > DESTINATION_AVAILABLE_OFFSET)
        {
            return NodeState.RUNNING;
        }

        return NodeState.SUCCESS;
    }

}

