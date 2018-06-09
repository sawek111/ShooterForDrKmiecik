using UnityEngine;

public class GridNode : IHeapItem<GridNode>
{
    #region public vars

    public bool Walkable { get; set; }

    public Vector3 WorldPos { get; set; }

    public int GridX { get; }
    public int GridY { get; }

    public int HCost { get; set; }
    public int GCost { get; set; }

    public int HeapIndex {get; set;}

    public GridNode Parent { get; set; }

    #endregion public vars

    #region Constructor

    public GridNode(bool walkable, Vector3 worldPos, int gridX , int gridY )
    {
        Walkable = walkable;
        WorldPos = worldPos;
        GridX = gridX;
        GridY = gridY;
    }

    #endregion Constructor

    #region IComparable

    public override bool Equals(object obj)
    {
        GridNode n = obj as GridNode;
        if(n == null)
        {
            return false;
        }

        return ((GridNode)obj).WorldPos == WorldPos;
    }

    public int CompareTo(GridNode other)
    {
        int compare = FCost.CompareTo(other.FCost);
        if (compare == 0)
        {
            compare = HCost.CompareTo(other.HCost);
        }

        return -compare;
    }

    #endregion IComparable

    #region Interface

    public int FCost
    {
        get { return HCost + GCost; } 
    }

    #endregion Interface
}
