using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Assets.SRC.Shared.Utilities;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Exceptions;
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

        public Vector3[] PathPositions(Vector3[] grid, Vector3 startPos, Vector3 endPos, float scale) => ConvertPathNodesToPositions(FindPath(grid, startPos, endPos, scale));


        private Vector3[] ConvertPathNodesToPositions(List<PathNode> nodePath)
        {
            List<Vector3> vList = new List<Vector3>();
            for (int i = 0; i < nodePath.Count; i++)
            {
                vList.Add(nodePath[i].ThisNodePos);
            }
            return vList.ToArray();
        }
        private List<PathNode> FindPath(Vector3[] grid, Vector3 startPos, Vector3 endPos, float scale)
        {
            Vector2 infin = new Vector2(float.MaxValue, float.MaxValue);
            PathNode startNode = new PathNode();
            PathNode endNode = new PathNode();
            startNode.ThisNodePos = startPos;
            endNode.ThisNodePos = endPos;
            List<PathNode> returnedPath = new List<PathNode>();
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
            openList = GetNeighbors(openList, endNode, scale);
            startNode.SetNodeCost(new Vector2(0, vMath.CalculateDistanceBetweenTwoVectors(startPos, endPos) * MOVEMENTCOST * 2));
            while (openList.Count > 0)
            {
                PathNode currentNode = GetLowestFCostNode(openList);
                if (currentNode.ThisNodePos == endNode.ThisNodePos)
                {
                    returnedPath = CalculatedPath(endNode);
                    break;
                }
                closedList.Add(currentNode);
                openList.Remove(currentNode);
                currentNode.SetNodeNeighbors(RemoveClosedNeighbors(currentNode, closedList));
                currentNode = FindNextNode(currentNode, endNode);
            }
            return returnedPath;
        }
        private PathNode FindNextNode(PathNode currentNode, PathNode endNode)
        {
            if (vMath.CalculateDistanceBetweenTwoVectors(currentNode.ThisNodePos, endNode.ThisNodePos) == 0) return endNode;
            PathNode returnedNodePath=new PathNode();
            float? evaluatedDistance = vMath.CalculateDistanceBetweenTwoVectors(currentNode.ThisNodePos,endNode.ThisNodePos)*MOVEMENTCOST;
            var neighbors = currentNode.GetNodeNeighbors();
            if (neighbors.NorthCost < evaluatedDistance)
            {
                evaluatedDistance = neighbors.NorthCost;
                returnedNodePath = neighbors.North;
            }
            if (neighbors.EasthCost < evaluatedDistance)
            {
                evaluatedDistance = neighbors.EasthCost;
                returnedNodePath = neighbors.East;
            }
            if (neighbors.SouthCost < evaluatedDistance)
            {
                evaluatedDistance = neighbors.SouthCost;
                returnedNodePath = neighbors.South;
            }
            if (neighbors.WestCost < evaluatedDistance)
            {
                evaluatedDistance = neighbors.WestCost;
                returnedNodePath = neighbors.West;
            }
            if (neighbors.TopCost < evaluatedDistance)
            {
                evaluatedDistance = neighbors.TopCost;
                returnedNodePath = neighbors.Top;
            }
            if (neighbors.BottomCost < evaluatedDistance)
            {
                evaluatedDistance = neighbors.BottomCost;
                returnedNodePath = neighbors.Bottom;
            }

            returnedNodePath.CameFromNode = currentNode;
            return returnedNodePath;
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
            if (closedList.Count > 0 && currentNode != null)
                for (int i = 0; i < closedList.Count; i++)
                {
                    if (closedList[i] == cTemp.North && cTemp.North != null)
                    {
                        cTemp.North = null;
                        cTemp.NorthCost = null;
                        break;
                    }
                    if (closedList[i] == cTemp.East && cTemp.East != null)
                    {
                        cTemp.East = null;
                        cTemp.EasthCost = null;
                        break;
                    }
                    if (closedList[i] == cTemp.South && cTemp.South != null)
                    {
                        cTemp.South = null;
                        cTemp.SouthCost = null;
                        break;
                    }
                    if (closedList[i] == cTemp.West && cTemp.West != null)
                    {
                        cTemp.West = null;
                        cTemp.WestCost = null;
                        break;
                    }
                    if (closedList[i] == cTemp.Top && cTemp.Top != null)
                    {
                        cTemp.Top = null;
                        cTemp.TopCost = null;
                        break;
                    }
                    if (closedList[i] == cTemp.Bottom && cTemp.Bottom != null)
                    {
                        cTemp.Bottom = null;
                        cTemp.BottomCost = null;
                        break;
                    }
                }
            return cTemp;
        }
        private List<PathNode> GetNeighbors(List<PathNode> pathNode, PathNode endNode, float scale)
        {
            for (int o = 0; o < pathNode.Count; o++)
            {
                PathNodeStruct temp = new PathNodeStruct();
                for (int i = 0; i < pathNode.Count; i++)
                {
                    if (vMath.CalculateDistanceBetweenTwoVectors(
                        new Vector3(
                            pathNode[o].ThisNodePos.x + scale,
                            pathNode[o].ThisNodePos.y,
                            pathNode[o].ThisNodePos.z), 
                        pathNode[i].ThisNodePos) == 0)//         N 1;0;0
                    {
                        temp.North = pathNode[i];
                        temp.NorthCost = vMath.CalculateDistanceBetweenTwoVectors(pathNode[i].ThisNodePos, endNode.ThisNodePos) * MOVEMENTCOST;
                        break;
                    }
                    if (vMath.CalculateDistanceBetweenTwoVectors(
                        new Vector3(
                            pathNode[o].ThisNodePos.x ,
                            pathNode[o].ThisNodePos.y,
                            pathNode[o].ThisNodePos.z + scale),
                        pathNode[i].ThisNodePos) == 0)//         E 0;0;1
                    {
                        temp.East = pathNode[i];
                        temp.EasthCost = vMath.CalculateDistanceBetweenTwoVectors(pathNode[i].ThisNodePos, endNode.ThisNodePos) * MOVEMENTCOST;
                        break;
                    }
                    if (vMath.CalculateDistanceBetweenTwoVectors(
                        new Vector3(
                            pathNode[o].ThisNodePos.x - scale,
                            pathNode[o].ThisNodePos.y,
                            pathNode[o].ThisNodePos.z),
                        pathNode[i].ThisNodePos) == 0)//         S -1;0;0
                    {
                        temp.South = pathNode[i];
                        temp.SouthCost = vMath.CalculateDistanceBetweenTwoVectors(pathNode[i].ThisNodePos, endNode.ThisNodePos) * MOVEMENTCOST;
                        break;
                    }
                    if (vMath.CalculateDistanceBetweenTwoVectors(
                        new Vector3(
                            pathNode[o].ThisNodePos.x,
                            pathNode[o].ThisNodePos.y,
                            pathNode[o].ThisNodePos.z - scale),
                        pathNode[i].ThisNodePos) == 0)//         w 0;0;-1
                    {
                        temp.West = pathNode[i];
                        temp.WestCost = vMath.CalculateDistanceBetweenTwoVectors(pathNode[i].ThisNodePos, endNode.ThisNodePos) * MOVEMENTCOST;
                        break;
                    }
                    if (vMath.CalculateDistanceBetweenTwoVectors(
                        new Vector3(
                            pathNode[o].ThisNodePos.x ,
                            pathNode[o].ThisNodePos.y + scale,
                            pathNode[o].ThisNodePos.z),
                        pathNode[i].ThisNodePos) == 0)//         T 0;1;0
                    {
                        temp.Top = pathNode[i];
                        temp.TopCost = vMath.CalculateDistanceBetweenTwoVectors(pathNode[i].ThisNodePos, endNode.ThisNodePos) * MOVEMENTCOST;
                        break;
                    }
                    if (vMath.CalculateDistanceBetweenTwoVectors(
                        new Vector3(
                            pathNode[o].ThisNodePos.x ,
                            pathNode[o].ThisNodePos.y + scale,
                            pathNode[o].ThisNodePos.z),
                        pathNode[i].ThisNodePos) == 0)//         B 0;-1;0
                    {
                        temp.Bottom = pathNode[i];
                        temp.BottomCost = vMath.CalculateDistanceBetweenTwoVectors(pathNode[i].ThisNodePos, endNode.ThisNodePos) * MOVEMENTCOST;
                        break;
                    }
                }
                pathNode[o].SetNodeNeighbors(temp);
            }
            return pathNode;
        }
        private List<PathNode> CalculatedPath(PathNode endNode)
        {
            PathNode workingNode = endNode;
            List<PathNode> path = new List<PathNode>();
            while (workingNode.CameFromNode != null)
            {
                path.Add(workingNode.CameFromNode);
                workingNode = workingNode.CameFromNode;
            }
            return path;
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
