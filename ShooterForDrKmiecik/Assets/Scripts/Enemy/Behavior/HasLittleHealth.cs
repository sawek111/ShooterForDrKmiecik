using Zenject;

public class HasLittleHealth : Node
{
    private Enemy _enemy = null;
    
    public override void ParticualEnter(Tick tick)
    {
        _enemy = tick.Target as Enemy;
    }

    public override NodeState ParticularTick(Tick tick)
    {
        return ((float)_enemy.GetCurrentHealth() / (float)_enemy.GetMaxHealth() <= 0.2f) ? NodeState.SUCCESS : NodeState.FAILURE;
    }
    
}
