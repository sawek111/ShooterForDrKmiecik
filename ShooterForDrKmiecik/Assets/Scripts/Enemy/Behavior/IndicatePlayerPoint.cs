using UnityEngine;
using Zenject;

public class IndicatePlayerPoint : Node
{
    private readonly Player _player = null;
    private Enemy _enemy = null;

    private Vector3 _lastPlayerSavedPos = Vector3.zero;

    public IndicatePlayerPoint(DiContainer Container)
    {
        _player = Container.Resolve<Player>();
    }


    public override void ParticualEnter(Tick tick)
    {
        _enemy = tick.Target as Enemy;
    }

    public override NodeState ParticularTick(Tick tick)
    {
        if ((_player.Position - _lastPlayerSavedPos).sqrMagnitude > 0.5f)
        {
            _lastPlayerSavedPos = _player.Position;
            _enemy.SetNewTarget(_player.Position, TargetType.FOLLOW_PLAYER);
        }

        return NodeState.SUCCESS;
    }
}

