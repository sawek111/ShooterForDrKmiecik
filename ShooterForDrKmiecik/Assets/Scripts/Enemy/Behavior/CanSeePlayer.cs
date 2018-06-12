﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSeePlayer : Node
{
    private Enemy _enemy = null;

    public override void ParticualEnter(Tick tick)
    {
        _enemy = tick.Target as Enemy;
    }

    public override NodeState ParticularTick(Tick tick)
    {
        if (_enemy.CanSeePlayer())
        {
            return NodeState.SUCCESS;
        }

        _enemy.IsEscaping = false;
        return NodeState.FAILURE;
    }

}
