

public enum AnimationState
{
    IDLE,
    RUN,
    DIE,
    JUMP,
    SHOT
}

public enum Axis
{
    HORIZONTAL,
    VERTICAL
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