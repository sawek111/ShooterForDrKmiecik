using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class IndicateHealingPoint : Node
{
    private HealArea _healArea = null;

    public IndicateHealingPoint(DiContainer Container)
    {
        _healArea = Container.Resolve<HealArea>();
    }

    private Enemy _enemy = null;

    public override void ParticualEnter(Tick tick)
    {
        _enemy = tick.Target as Enemy;
    }

    public override NodeState ParticularTick(Tick tick)
    {
        if(_enemy.TargetType != TargetType.HEAL)
        {
            _enemy.SetNewTarget(_healArea.Position, TargetType.HEAL);
            _enemy.IsHealing = true;
        }

        return NodeState.SUCCESS;
    }
}