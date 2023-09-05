using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding
{
    // Define a class representing a node in a pathfinding graph
    public class NewNodeModel
    {
        public Vector3 Position;                     // Position of the node
        public List<NewNodeModel> Neighbors;         // List of neighboring nodes
        public bool Closed;                          // Whether the node has been visited
        public float fCost, hCost;                   // Cost variables used in A* algorithm
        public NewNodeModel LastNode;                // The last node visited in the path
    }
}