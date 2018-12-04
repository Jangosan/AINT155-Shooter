using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    //Grid position x
    public int gridX;
    //Grid position y
    public int gridY;
    //Is the node obstructed
    public bool nodeObstructed;
    //World position of the node
    public Vector2 position;
    //The previous node
    public Node parent;
    //Cost of moving to the next square, distance from the goal to the current node
    public int gCost, hCost;

    public int fcost {
        get { return gCost + hCost; }
    }
        
    public Node(bool IsObstructed, Vector2 Position, int GridX, int GridY)
    {
        nodeObstructed = IsObstructed;
        position = Position;
        gridX = GridX;
        gridY = GridY;
    }
}
    