using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public Transform startPos;
    public LayerMask wallMask;
    public Vector2 gridSize;
    public float nodeRadius;
    public float distance;

    public Node[,] grid;

    public List<Node> finalPath;

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    private void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridSize.y / nodeDiameter);
        createGrid();
    }

    private void createGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector2 bottomLeft = (Vector2)transform.position - Vector2.right * gridSize.x / 2 - Vector2.up * gridSize.y / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for(int y = 0; y < gridSizeY; y++)
            {
                Vector2 worldPoint = bottomLeft + Vector2.right * (x * nodeDiameter + nodeRadius) + Vector2.up * (y * nodeDiameter + nodeRadius);
                bool isWall = true;

                if (Physics2D.OverlapCircle(worldPoint, nodeRadius, wallMask))
                {
                    isWall = false;
                }

                grid[x, y] = new Node(isWall, worldPoint, x, y);
          
            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireCube(transform.position, new Vector2(gridSize.x, gridSize.y));

    //    if (grid != null)
    //    {
    //        foreach () ;
    //    }
    //}

}
