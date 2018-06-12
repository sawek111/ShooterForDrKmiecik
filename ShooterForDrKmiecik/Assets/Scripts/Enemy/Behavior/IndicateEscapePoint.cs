using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class IndicateEscapePoint : Node
{
    private Player _player = null;

    public IndicateEscapePoint(DiContainer Container)
    {
        _player = Container.Resolve<Player>();
    }

    private Enemy _enemy = null;

    public override void ParticualEnter(Tick tick)
    {
        _enemy = tick.Target as Enemy;
    }

    public override NodeState ParticularTick(Tick tick)
    {
        if (_enemy.TargetType != TargetType.ESCAPE)
        {
            Vector3 escapePoint = _enemy.PrepareEscapePosition(_player.Position);
            _enemy.SetNewTarget(escapePoint, TargetType.ESCAPE);
        }

        return NodeState.SUCCESS;
    }
}
