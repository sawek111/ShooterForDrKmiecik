using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PathFinder
{
    private const int DIAGONAL_DIST = 14;
    private const int LINE_DIST = 10;

    private MapGrid _grid = null;

    #region Constructor

    [Inject]
    public PathFinder(MapGrid grid)
    {
        _grid = grid;
    }

    #endregion Constructor

    #region Interface

    public List<GridNode> FindPath(Vector3 startPos, Vector3 endPos)
    {
        GridNode startNode = _grid.GetNodeFromWorldPos(startPos);
        GridNode endNode = _grid.GetWalkableNeighbor(_grid.GetNodeFromWorldPos(endPos));

        Heap<GridNode> openSet = new Heap<GridNode>(_grid.MaxSize);
        HashSet<GridNode> closeSet = new HashSet<GridNode>();
        openSet.Add(startNode);

        while(openSet.Count > 0)
        {
            GridNode currNode = openSet.RemoveFirst();
            closeSet.Add(currNode);
            if(currNode == endNode)
            {
                return RetracePath(startNode,endNode);
            }

            List<GridNode> neighbors = _grid.GetNeighbors(currNode);
            foreach(GridNode neighbor in neighbors)
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

        return new List<GridNode>();
    }

    public Vector3 GetRandomPosition()
    {
        int x = Random.Range(0, _grid.XSize);
        int y= Random.Range(0, _grid.YSize);

        GridNode endNode = _grid.GetWalkableNeighbor(_grid[x,y]);
        return endNode.WorldPos;
    }

    #endregion Interface

    #region Logic

    private List<GridNode> RetracePath(GridNode startNode, GridNode endNode)
    {
        List<GridNode> path = new List<GridNode>();
        GridNode currNode = endNode;

        while(currNode != startNode)
        {
            path.Add(currNode);
            currNode = currNode.Parent;
        }
        path.Reverse();

        return path;
    }

    private int GetDistance(GridNode a, GridNode b)
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
