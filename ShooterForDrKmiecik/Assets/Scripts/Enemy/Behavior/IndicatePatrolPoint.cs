using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class IndicatePatrolPoint : Node
{
    private Enemy _enemy = null;
    private PathFinder _pathFinder = null;

    public IndicatePatrolPoint(DiContainer container)
    {
        _pathFinder = container.Resolve<PathFinder>();
    }

    public override void ParticualEnter(Tick tick)
    {
        _enemy = tick.Target as Enemy;
    }

    public override NodeState ParticularTick(Tick tick)
    {
        if(_enemy.TargetType != TargetType.PATROL)
        {
            Vector3 randomPos = _pathFinder.GetRandomPosition();
            _enemy.SetNewTarget(randomPos, TargetType.PATROL);
        }
        
        return NodeState.SUCCESS;
    }

}
