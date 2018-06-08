using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PathFinder
{
    private const int DIAGONAL_DIST = 14;
    private const int LINE_DIST = 10;

    private Grid _grid = null;

    #region Constructor

    [Inject]
    public void Construct(Grid grid)
    {
        _grid = grid;
    }

    #endregion Constructor

    #region Interface

    public List<Node> FindPath(Vector3 startPos, Vector3 endPos)
    {
        Node startNode = _grid.GetNodeFromWorldPos(startPos);
        Node endNode = _grid.GetNodeFromWorldPos(endPos);

        Heap<Node> openSet = new Heap<Node>(_grid.MaxSize);
        HashSet<Node> closeSet = new HashSet<Node>();
        openSet.Add(startNode);

        while(openSet.Count > 0)
        {
            Node currNode = openSet.RemoveFirst();
            closeSet.Add(currNode);
            if(currNode == endNode)
            {
                return RetracePath(startNode,endNode);
            }

            List<Node> neighbors = _grid.GetNeighbors(currNode);
            foreach(Node neighbor in neighbors)
            {
                if(!neighbor.Walkable || closeSet.Contains(neighbor))
                {
                    continue;
                }

                int newGCost = currNode.GCost + GetDistance(currNode, neighbor);
                if(newGCost < neighbor.GCost || !openSet.Contains(neighbor))
                {
                    neighbor.GCost = newGCost;
                    neighbor.HCost = GetDistance(neighbor, endNode);
                    neighbor.Parent = currNode;

                    if(!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                        openSet.UpdateItem(neighbor);
                    }
                }
            }
        }

        return new List<Node>();
    }

    #endregion Interface

    #region Logic

    private List<Node> RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currNode = endNode;

        while(currNode != startNode)
        {
            path.Add(currNode);
            currNode = currNode.Parent;
        }
        path.Reverse();

        return path;
    }

    private int GetDistance(Node a, Node b)
    {
        int distX = Mathf.Abs(a.GridX - b.GridX);
        int distY = Mathf.Abs(a.GridY - b.GridY);

        if (distX > distY)
        {
            return DIAGONAL_DIST * distY + LINE_DIST * (distX - distY);
        }

        return DIAGONAL_DIST * distX + LINE_DIST * (distY - distX);
    }

    #endregion Logic

}
