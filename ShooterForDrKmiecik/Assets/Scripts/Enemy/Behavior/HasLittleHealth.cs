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
        if ((float)_enemy.GetCurrentHealth() / (float)_enemy.GetMaxHealth() <= 0.2f || _enemy.IsHealing)
        {
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }

}
