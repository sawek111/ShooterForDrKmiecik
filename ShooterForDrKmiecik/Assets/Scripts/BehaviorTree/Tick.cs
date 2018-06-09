using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tick 
{
    private BehaviorTree _tree;
    private BlackBoard _board;
    private object _target;
    private int _nodesCount;
    private List<Node> _openNodes;

    public List<Node> OpenNodes
    {
        get { return _openNodes; }
    }

    public int NodesCount
    {
        get { return _nodesCount; }
    }

    public object Target
    {
        get { return _target; }
        set { _target = value; }
    }

    public object Tree
    {
        get { return _tree; }
    }

    public BlackBoard Board
    {
        get { return _board; }
    }

    public Tick(BehaviorTree tree, BlackBoard board, object target)
    {
        _target = target;
        _board = board;
        _tree = tree;
        _nodesCount = 0;
        _openNodes = new List<Node>();

        return;
    }

    public void EnterNode(Node node)
    {
        _nodesCount++;
        _openNodes.Add(node);

        return;
    }

    public void OpenNode(Node node)
    {
        return;
    }


    public NodeState TickNode(Node node)
    {
        //TODO
        return NodeState.ERROR;
    }

    public void CloseNode(Node node)
    {
        if (_openNodes.Contains(node))
        {
            _nodesCount--;
            _openNodes.Remove(node);
        }

        return;
    }

    public void ExitNode(Node node)
    {
        return;
    }

}
