﻿
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
        return NodeState.FAILURE;
    }
}
