using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding
{
    // Define a class representing a node in a pathfinding graph
    internal class NewNode
    {
        public Vector3 Position;                // Position of the node
        public List<NewNode> Neighbors;         // List of neighboring nodes
        public bool Closed;                     // Whether the node has been visited
        public float fCost, hCost;              // Cost variables used in A* algorithm
        public NewNode LastNode;                // The last node visited in the path

    }
}