

public enum AnimationState
{
    IDLE,
    RUN,
    DIE,
    JUMP,
    SHOT
}

public enum TargetType
{
    ESCAPE,
    HEAL,
    FOLLOW_PLAYER,
    PATROL,
    NONE
}

public enum Axis
{
    HORIZONTAL,
    VERTICAL
}

public enum ShooterType
{
    Player,
    Enemy
}

#region BehaviorTree

public enum NodeState
{
    SUCCESS,
    FAILURE,
    RUNNING,
    ERROR
}

public enum NodeType
{
    COMPOSITE,
    DECORATOR,
    LEAF,
    ROOT
}

public enum LeafType
{
    CONDITION,
    ACTION
}

public enum MemoryKeys
{
    OPEN_NODES,
    NODES_COUNT
}

#endregion