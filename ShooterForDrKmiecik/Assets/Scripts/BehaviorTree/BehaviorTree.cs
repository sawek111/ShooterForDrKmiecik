using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree
{
    private int _id;
    private Node _root;

   public BehaviorTree(Node root)
    {
        _id = Utils.GetTreeId();
        _root = root;

        return;
    }

    public void Tick(BlackBoard board, object target)
    {
        Tick tick = new Tick(this, board, target);
        _root.Execute(tick);
        List<Node> lastOpenNodes = board.GetValue(MemoryKeys.OPEN_NODES.ToString(), _id) as List<Node>;
        List<Node> currentOpenNodes = new List<Node>(tick.OpenNodes);
        if(lastOpenNodes != null)
        {
            int activeNodesCount = GetOpenNodesCount(lastOpenNodes, currentOpenNodes);
            for (int i = lastOpenNodes.Count - 1; i >= activeNodesCount; i--)
            {
                lastOpenNodes[i].Close(tick);
            }
        }
        board.SetValue(MemoryKeys.OPEN_NODES.ToString(), _id, currentOpenNodes);
        board.SetValue(MemoryKeys.NODES_COUNT.ToString(), _id, tick.NodesCount);

        return;
    }

    private int GetOpenNodesCount(List<Node> lastOpenNodes, List<Node> currentOpenNodes)
    {
        int start = 0;
        if(lastOpenNodes == null)
        {
            return start;
        }

        for (int i = 0; i < Mathf.Min(lastOpenNodes.Count, currentOpenNodes.Count); i++)
        {
            start = i + 1;
            if (lastOpenNodes[i] != currentOpenNodes[i])
            {
                break;
            }
        }

        return start;
    }
}
