﻿public abstract class Node
{
    protected int _id;
    protected Node[] _children = null;

    protected Node(params Node[] newChildren) : base()
    {
        Utils.CreateArrayCopy<Node>(newChildren, out _children);
    }

    protected Node()
    {
        _id = Utils.GetNodeId();
    }

    public virtual void ParticularOpen(Tick tick) { return; }
    public virtual void ParticualEnter(Tick tick) { return; }
    public virtual void ParticularClose(Tick tick) { return; }
    public virtual void ParticularExit(Tick tick) { return; }
    public virtual NodeState ParticularTick(Tick tick) { return NodeState.ERROR; }

    public NodeState Execute(Tick tick)
    {
        Enter(tick);
        if ( tick.Board.GetValue("isOpen", _id) != null &&  !((bool)tick.Board.GetValue("isOpen", _id)))
        {
            Open(tick);
        }
        NodeState status = Tick(tick);
        if(status != NodeState.RUNNING)
        {
            Close(tick);
        }
        Exit(tick);

        return status;
    }

    public void Close(Tick tick)
    {
        tick.CloseNode(this);
        tick.Board.SetValue("isOpen", _id, false);
        ParticularClose(tick);
    }

    protected void Enter(Tick tick)
    {
        tick.EnterNode(this);
        ParticualEnter(tick);
    }

    protected void Open(Tick tick)
    {
        tick.OpenNode(this);
        tick.Board.SetValue("isOpen", _id, true);
        ParticularOpen(tick);
    }

    protected void Exit(Tick tick)
    {
        tick.ExitNode(this);
        ParticularExit(tick);
    }

    protected NodeState Tick(Tick tick)
    {
        tick.TickNode(this);
        return ParticularTick(tick);
    }

}
