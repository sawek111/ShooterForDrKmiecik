using Zenject;

public class EnemyBehavior : IInitializable, IFixedTickable
{
    private readonly DiContainer _container = null;
    private readonly Enemy _enemy = null;

    private BehaviorTree _behaviorTree = null;
    private BlackBoard _board = new BlackBoard();

    public PatrolState PatrolState { get; set; }

    public EnemyBehavior(Enemy enemy, DiContainer container)
    {
        _container = container;
        _enemy = enemy;
    }

    public void Initialize()
    {
        PatrolState = PatrolState.PATROL;

        _behaviorTree = CreateTree();
    }


    public void FixedTick()
    {
        _behaviorTree.Tick(_board, _enemy);
    }

    private BehaviorTree CreateTree()
    {
        Node mainNode =
            new PriorityNode(
                new SequenceNode(
                    new HasLittleHealth(),
                    new PriorityNode(
                        new SequenceNode(
                            new HasNoHealth(),
                            new Die()
                       ),
                        new PriorityNode(
                            new SequenceNode(
                                new CanSeePlayer(),
                                new SequenceNode(
                                    new IndicateEscapePoint(_container),
                                    new MoveToTarget()
                                )
                            ),
                            new SequenceNode(
                                new IndicateHealingPoint(_container),
                                new MoveToTarget(),
                                new Heal()
                            )
                      )
                )
           ),
                new SequenceNode(
                    new CanSeePlayer(),
                    new PriorityNode(
                        new SequenceNode(
                            new CanShootPlayer(),
                            new Shoot()
                        ),
                        new SequenceNode(
                            new IndicatePlayerPoint(_container),
                            new MoveToTarget()
                        )
                    )
            ),
                new PriorityNode(
                    new SequenceNode(
                        new IndicatePatrolPoint(_container),
                        new MoveToTarget(),
                        new ChangeToIdle()
                    ),
                    new Idle()
                )
        );

        BehaviorTree tree = new BehaviorTree(mainNode);

        return tree;
    }
}
