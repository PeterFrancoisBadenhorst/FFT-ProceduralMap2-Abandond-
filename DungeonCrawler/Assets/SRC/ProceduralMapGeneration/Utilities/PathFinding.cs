using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Assets.SRC.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    internal class PathFinding
    {
        private const float MOVEMENTCOST = 10;
        VectorMath vMath = new VectorMath();
        private List<PathNode> FindPath(Vector3[] grid, Vector3 startPos, Vector3 endPos, float scale)
        {
            throw new NotImplementedException();
            Vector2 infin = new Vector2(float.MaxValue, float.MaxValue);
            PathNode startNode = new PathNode();
            PathNode endNode = new PathNode();
            startNode.ThisNodePos = startPos;
            endNode.ThisNodePos = endPos;

            var openList = new List<PathNode>();
            var closedList = new List<PathNode>();
            for (int i = 0; i < grid.Length; i++)
            {
                PathNode tempNode = new PathNode();
                tempNode.ThisNodePos = grid[i];
                tempNode.SetNodeCost(infin);
                tempNode.CameFromNode = null;
                openList.Add(tempNode);
            }
            openList = GetNeighbors(openList, scale);
            startNode.SetNodeCost(new Vector2(0, vMath.CalculateDistanceBetweenTwoVectors(startPos, endPos) * MOVEMENTCOST * 2));
            while (openList.Count > 0)
            {
                PathNode currentNode = GetLowestFCostNode(openList);
                if (currentNode.ThisNodePos == endNode.ThisNodePos)
                {
                    return CalculatedPath(endNode);
                }
                closedList.Add(currentNode);
                openList.Remove(currentNode);
                currentNode.SetNodeNeighbors(RemoveClosedNeighbors(currentNode, closedList));
            }

        }
        private PathNode FindNextNode(PathNode currentNode, PathNode endNode)
        {
            throw new NotImplementedException();
            var disLeft = vMath.CalculateDistanceBetweenTwoVectors(currentNode.ThisNodePos, endNode.ThisNodePos);
            if (disLeft == 0) return endNode;

        }
        /*
         * N 1;0;0
         * E 0;0;1
         * S -1;0;0
         * w 0;0;-1
         * T 0;1;0
         * B 0;-1;0
         */
        private PathNodeStruct RemoveClosedNeighbors(PathNode currentNode, List<PathNode> closedList)
        {
            PathNodeStruct cTemp = currentNode.GetNodeNeighbors();
            for (int i = 0; i < closedList.Count; i++)
            {
                if (closedList[i].ThisNodePos == cTemp.North.ThisNodePos)
                { cTemp.North = null; cTemp.NorthCost = null; break; }
                if (closedList[i].ThisNodePos == cTemp.East.ThisNodePos)
                { cTemp.East = null; break; }
                if (closedList[i].ThisNodePos == cTemp.South.ThisNodePos)
                { cTemp.South = null; cTemp.NorthCost = null; break; }
                if (closedList[i].ThisNodePos == cTemp.West.ThisNodePos)
                { cTemp.West = null; cTemp.NorthCost = null; break; }
                if (closedList[i].ThisNodePos == cTemp.Top.ThisNodePos)
                { cTemp.Top = null; cTemp.NorthCost = null; break; }
                if (closedList[i].ThisNodePos == cTemp.Bottom.ThisNodePos)
                { cTemp.Bottom = null; cTemp.NorthCost = null; break; }
            }
            return cTemp;
        }
        private List<PathNode> GetNeighbors(List<PathNode> pathNode, float scale)
        {
            for (int o = 0; o < pathNode.Count; o++)
            {
                PathNodeStruct temp = new PathNodeStruct();
                for (int i = 0; i < pathNode.Count; i++)
                {
                    if (pathNode[o].ThisNodePos.x + scale == pathNode[i].ThisNodePos.x)//         N 1;0;0
                    { temp.North = pathNode[i]; temp.NorthCost = vMath.CalculateDistanceBetweenTwoVectors(pathNode[i].ThisNodePos, pathNode[o].ThisNodePos) + MOVEMENTCOST; break; }
                    if (pathNode[o].ThisNodePos.y + scale == pathNode[i].ThisNodePos.y)//         E 0;0;1
                    { temp.East = pathNode[i]; temp.EasthCost = vMath.CalculateDistanceBetweenTwoVectors(pathNode[i].ThisNodePos, pathNode[o].ThisNodePos) + MOVEMENTCOST; break; }
                    if (pathNode[o].ThisNodePos.x - scale == pathNode[i].ThisNodePos.x)//         S -1;0;0
                    { temp.South = pathNode[i]; temp.SouthCost = vMath.CalculateDistanceBetweenTwoVectors(pathNode[i].ThisNodePos, pathNode[o].ThisNodePos) + MOVEMENTCOST; break; }
                    if (pathNode[o].ThisNodePos.y - scale == pathNode[i].ThisNodePos.y)//         w 0;0;-1
                    { temp.West = pathNode[i]; temp.WestCost = vMath.CalculateDistanceBetweenTwoVectors(pathNode[i].ThisNodePos, pathNode[o].ThisNodePos) + MOVEMENTCOST; break; }
                    if (pathNode[o].ThisNodePos.z + scale == pathNode[i].ThisNodePos.z)//         T 0;1;0
                    { temp.Top = pathNode[i]; temp.TopCost = vMath.CalculateDistanceBetweenTwoVectors(pathNode[i].ThisNodePos, pathNode[o].ThisNodePos) + MOVEMENTCOST; break; }
                    if (pathNode[o].ThisNodePos.z - scale == pathNode[i].ThisNodePos.z)//         B 0;-1;0
                    { temp.Bottom = pathNode[i]; temp.BottomCost = vMath.CalculateDistanceBetweenTwoVectors(pathNode[i].ThisNodePos, pathNode[o].ThisNodePos) + MOVEMENTCOST; break; }
                }
                pathNode[o].SetNodeNeighbors(temp);
            }
            return pathNode;
        }
        private List<PathNode> CalculatedPath(PathNode pathNode)
        {
            throw new NotImplementedException();
        }
        private PathNode GetLowestFCostNode(List<PathNode> pathNodes)
        {
            PathNode lowestFCostNode = pathNodes[0];
            for (int i = 0; i < pathNodes.Count; i++)
            {
                if (pathNodes[i].GetNodeCost().z < lowestFCostNode.GetNodeCost().z)
                {
                    lowestFCostNode = pathNodes[i];
                }

            }
            return lowestFCostNode;
        }
    }
}
