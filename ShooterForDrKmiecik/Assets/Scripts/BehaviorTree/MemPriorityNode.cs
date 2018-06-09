using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemPriorityNode : Node
{

    public MemPriorityNode(params Node[] children) :base(children){ }

    public override void ParticularOpen(Tick tick)
    {
        tick.Board.SetValue("runningChild", _id, 0);
    }

    public override NodeState ParticularTick(Tick tick)
    {
        int startChildNr = (int)tick.Board.GetValue("runningChild", _id);
        for (int i = startChildNr; i < _children.Length; i++)
        {
            NodeState status = _children[i].Execute(tick);
            if (status != NodeState.FAILURE)
            {
                if (status == NodeState.RUNNING)
                {
                    tick.Board.SetValue("runningChild", _id, i);
                }
                return status;
            }
        }

        return NodeState.FAILURE;
    }

}
