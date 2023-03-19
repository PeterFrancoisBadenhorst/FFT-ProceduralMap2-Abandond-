using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    public class PathNode
    {
        private float g_cost = 0;
        private float h_cost = 0;
        private float f_cost = 0;

        private PathNodeStruct neighborNodes = new PathNodeStruct();

        public Vector3 ThisNodePos { get; set; }
        public PathNode CameFromNode { get; set; }
        public void SetNodeCost(Vector2 cost)
        {
            g_cost = cost.x;
            h_cost = cost.y;
        }
        public void SetFCost(float f) =>f_cost= f;

        public void SetHcost(float cost) => h_cost = cost;

        public Vector3 GetNodeCost() => new Vector3(g_cost, h_cost, f_cost);

        public PathNodeStruct GetNodeNeighbors() => neighborNodes;
        public void SetNodeNeighbors(PathNodeStruct neighbors)
        {
            neighborNodes.North = neighbors.North;
            neighborNodes.East = neighbors.East;
            neighborNodes.South = neighbors.South;
            neighborNodes.West = neighbors.West;
            neighborNodes.Top = neighbors.Top;
            neighborNodes.Bottom = neighbors.Bottom;

            neighborNodes.NorthCost = neighbors.NorthCost;
            neighborNodes.EasthCost = neighbors.EasthCost;
            neighborNodes.WestCost = neighbors.WestCost;
            neighborNodes.SouthCost = neighbors.SouthCost;
            neighborNodes.TopCost = neighbors.TopCost;
            neighborNodes.BottomCost = neighbors.BottomCost;
        }


    }
}
