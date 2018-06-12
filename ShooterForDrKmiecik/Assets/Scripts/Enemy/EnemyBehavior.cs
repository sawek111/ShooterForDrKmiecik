using Zenject;

public class EnemyBehavior : IInitializable, IFixedTickable
{
    private readonly DiContainer _container = null;
    private readonly Enemy _enemy = null;

    private BehaviorTree _behaviorTree = null;
    private BlackBoard _board = new BlackBoard();

    public EnemyBehavior(Enemy enemy, DiContainer container)
    {
        _container = container;
        _enemy = enemy;
    }

    public void Initialize()
    {
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
                                new Escape()
                            ),
                            new GoToHealPoint()
                      )
                )
           ),
                new SequenceNode(
                    new CanSeePlayer(),
                    new PriorityNode(
                        new SequenceNode(
                            new CanShootPlayer(),
                            new Shot()
                        ),
                        new FollowPlayer()
                    )
            ),
                new MemSequnceNode(
                    new Patrol(),
                    new Idle()
                )
        );

        BehaviorTree tree = new BehaviorTree(mainNode);

        return tree;
    }
}
