using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShootPlayer : Node
{
    private Enemy _enemy = null;

    public override void ParticualEnter(Tick tick)
    {
        _enemy = tick.Target as Enemy;
    }

    public override NodeState ParticularTick(Tick tick)
    {
        return _enemy.CanShootPlayer() ? NodeState.SUCCESS : NodeState.FAILURE;
    }

}
