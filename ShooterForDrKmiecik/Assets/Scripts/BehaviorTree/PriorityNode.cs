using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityNode : Node
{

    public PriorityNode(params Node[] children) : base(children) { }

    public override NodeState ParticularTick(Tick tick)
    {
        for (int i = 0; i < _children.Length; i++)
        {
            NodeState status = _children[i].Execute(tick);
            if (status != NodeState.FAILURE)
            {
                return status;
            }
        }

        return NodeState.FAILURE;
    }
}
