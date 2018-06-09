using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceNode : Node
{

    public SequenceNode(params Node[] children) : base(children) { }

    public override NodeState ParticularTick(Tick tick)
    {
        for (int i = 0; i < _children.Length; i++)
        {
            NodeState status = _children[i].Execute(tick);
            if (status != NodeState.SUCCESS)
            {
                return status;
            }
        }

        return NodeState.SUCCESS;
    }

}
