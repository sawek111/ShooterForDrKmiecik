using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemSequnceNode : Node
{

    public MemSequnceNode(params Node[] children) :base(children){}

    public override void ParticularOpen(Tick tick)
    {
        tick.Board.SetValue("runningChild", _id, 0);
    }

    public override NodeState ParticularTick(Tick tick)
    {
        int startChildNr = (tick.Board.GetValue("runningChild", _id) == null) ? 0 : (int)tick.Board.GetValue("runningChild", _id);
        for (int i = startChildNr; i < _children.Length; i++)
        {
            NodeState status = _children[i].Execute(tick);
            if(status != NodeState.SUCCESS)
            {
                if(status == NodeState.RUNNING)
                {
                    tick.Board.SetValue("runningChild", _id, i);
                }
                return status;
            }
        }

        return NodeState.SUCCESS;
    }
}
