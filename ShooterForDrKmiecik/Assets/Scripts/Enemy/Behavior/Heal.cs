using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal :  Node
{
    private Enemy _enemy = null;

    public override void ParticualEnter(Tick tick)
    {
        _enemy = tick.Target as Enemy;
    }

    public override NodeState ParticularTick(Tick tick)
    {
        if(_enemy.GetCurrentHealth() < _enemy.GetMaxHealth())
        {
            return NodeState.RUNNING;
        }

        return NodeState.SUCCESS;
    }
}
