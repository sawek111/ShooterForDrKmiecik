using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MapGrid : MonoBehaviour
{
    [SerializeField] private LayerMask _unwalkableLayer;
    [SerializeField] private Vector2 _gridWorldSize;
    [SerializeField] private float _noderadius;

    private GridNode[,] _grid = null;

    #region Constructor

    public void Start()
    {
        int xSize = Mathf.RoundToInt(_gridWorldSize.x / (_noderadius * 2));
        int ySize = Mathf.RoundToInt(_gridWorldSize.y / (_noderadius * 2));

        CreateGrid(xSize,ySize);
    }

    #endregion Constructor

    #region Interface

    public int MaxSize
    {
        get { return _grid.GetLength(0) * _grid.GetLength(1); }
    }

    public GridNode GetNodeFromWorldPos(Vector3 worldPos)
    {
        float percentX = Mathf.Clamp01((worldPos.x + _gridWorldSize.x/2) / _gridWorldSize.x);
        float percentY = Mathf.Clamp01((worldPos.z + _gridWorldSize.y/2) / _gridWorldSize.y);

        int xCoord = Mathf.RoundToInt(percentX * (_grid.GetLength(0) - 1));
        int yCoord = Mathf.RoundToInt(percentY * (_grid.GetLength(1) - 1));

        return _grid[xCoord, yCoord];
    }

    public List<GridNode> GetNeighbors(GridNode node)
    {
        List<GridNode> neighbors = new List<GridNode>();

        for(int x = -1; x <= 1; x++)
        {
            for(int y = -1; y <= 1; y++)
            {
                if(x == 0 && y ==0)
                {
                    continue;
                }

                int gridX = node.GridX + x;
                int gridY = node.GridY + y;
                if (IsInGrid(gridX, gridY))
                {
                    neighbors.Add(_grid[gridX, gridY]);
                }
            }
        }

        return neighbors;
    }

    #endregion Interface

    #region Logic

    private void CreateGrid(int xSize, int ySize)
    {
        _grid = new GridNode[xSize, ySize];

        float nodeDiameter = 2f * _noderadius;
        Vector3 startPos = transform.position + Vector3.left * _gridWorldSize.x / 2f + Vector3.back * _gridWorldSize.y / 2f;

        for(int y = 0;  y < ySize; y++ )
        {
            for(int x = 0; x< xSize; x++)
            {
                Vector3 worldPos = startPos + Vector3.right * (x * nodeDiameter + _noderadius) + Vector3.forward * (y * nodeDiameter + _noderadius);
                bool walkable = !Physics.CheckSphere(worldPos, _noderadius, _unwalkableLayer);
                _grid[x, y] = new GridNode(walkable, worldPos, x, y);
            }
        }
    }

    private bool IsInGrid(int x, int  y)
    {
        return x >= 0 && x < _grid.GetLength(0) && y >= 0 && y < _grid.GetLength(1);
    }

    #endregion Logic
}
