using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Node
{
    private Enemy _enemy = null;
    private float _timer = 0f;


    public override void ParticualEnter(Tick tick)
    {
        _enemy = tick.Target as Enemy;
    }

    public override NodeState ParticularTick(Tick tick)
    {
        if (_timer > 5f)
        {
            _timer = 0f;
            return NodeState.SUCCESS;
        }

        _timer += Time.fixedDeltaTime;
        _enemy.SetAnimationState(AnimationState.IDLE);
        return NodeState.RUNNING;

    }

}
