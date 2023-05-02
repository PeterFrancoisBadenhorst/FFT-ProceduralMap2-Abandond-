using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Assets.SRC.Shared.Utilities;
using Codice.Client.Common.TreeGrouper;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Analytics;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding
{
    internal class NewPathFinding
    {
        /// <summary>
        /// H Cost => Diff to neighbors
        /// F Cost => Diff to end point
        /// ToDo:
        ///  Get grid
        ///  create node per pos in grid -
        ///  Set Neighbors of Nodes -
        ///  end-start node chooser -
        ///  Itterate through Neighbors to get to end node -
        ///  Return Array of positions to use -
        ///  
        /// 
        /// Issue : getting Null Ref in   GetNextNode @   node.Neighbors.Count;
        /// </summary>
        private readonly VectorMath vMath = new VectorMath();
        private readonly System.Random random = new System.Random();
        public Vector3[] NodeGridCreator(Vector3[] grid, Vector3[] baseMap, float scale)
        {
            //[0] start [1]end
            Vector3[] ends ={
                    (baseMap[random.Next(0, baseMap.Length)]),
                    (grid[random.Next(0, grid.Length)])
                    }; 
            List<NewNode> nodes = new();
            for (int i = 0; i < grid.Length; i++)
            {
                NewNode node = new();
                node.Position = grid[i];
                node.fCost = vMath.CalculateDistanceBetweenTwoVectors(node.Position, ends[1]);
                nodes.Add(node);
            }
            nodes = SetNodeNeighbors(nodes, scale);              // glitch happens Here
            List<Vector3> path = Findpath(nodes, ends);         // glitch  happends Before
            return path.ToArray();
        }
            public Vector3[] NodeGridCreator(Vector3[] grid, float scale)
        {
            var ends = FindEnds(grid);   //[0] start [1]end
            List<NewNode> nodes = new();
            for (int i = 0; i < grid.Length; i++)
            {
                NewNode node = new();
                node.Position = grid[i];
                node.fCost = vMath.CalculateDistanceBetweenTwoVectors(node.Position, ends[1]);
                nodes.Add(node);
            }
            nodes = SetNodeNeighbors(nodes, scale);              // glitch happens Here
            List<Vector3> path = Findpath(nodes, ends);         // glitch  happends Before
            return path.ToArray();
        }
        private List<Vector3> Findpath(List<NewNode> grid, Vector3[] positions)
        {
            List<NewNode> SortedListByPosistion = grid;// grid.OrderBy(x => x.Position).ToList();
            SortedListByPosistion.Reverse();
            NewNode startPos = new();
            NewNode endPos = new();
            NewNode ActiveNode = null;
            bool endPosFound = false;
            bool startPosFound = false;
            List<NewNode> generatedList = new();
            List<Vector3> convertedGeneratedList = new();
            startPos.Position = positions[0];
            endPos.Position = positions[1];

            for (int i = 0; i < SortedListByPosistion.Count; i++)
            {
                if (SortedListByPosistion[i].Position == startPos.Position)
                {
                    startPos = SortedListByPosistion[i];
                    break;
                }
            }
            ActiveNode = startPos;
            while (!endPosFound)
            {
                NewNode tempNode = ActiveNode;
                for (int g = 0; g < ActiveNode.Neighbors.Count; g++)
                {
                    if (tempNode.fCost > ActiveNode.Neighbors[g].fCost)
                    {
                        tempNode= ActiveNode.Neighbors[g];
                    }
                }
                tempNode.LastNode = ActiveNode;
                ActiveNode = tempNode;
                if (ActiveNode.Position == endPos.Position)
                {
                    endPos = ActiveNode;
                    endPosFound = true;
                }
            };
            while (!startPosFound)
            {
                ActiveNode = ActiveNode.LastNode;
                generatedList.Add(ActiveNode);
                if (ActiveNode.Position == startPos.Position)
                {
                    startPosFound = true;
                }
            }

            for (int i = 0; i < generatedList.Count; i++)
            {
                convertedGeneratedList.Add(generatedList[i].Position);
            }
            
            return convertedGeneratedList;

        }

        private NewNode GetNextNode(NewNode node)
        {
            float dis = float.MaxValue;
            NewNode returnedNode = null;
            var t = node.Neighbors.Count;
            for (int i = 0; i < t; i++)
            {
                if (node.Neighbors[i].fCost <= dis)
                {
                    dis = node.Neighbors[i].fCost;
                    returnedNode = node.Neighbors[i];
                }
            }
            returnedNode.LastNode = node;
            return returnedNode;
        }
        private Vector3[] FindEnds(Vector3[] grid)
        {
            Vector3[] pos ={
                    (grid[random.Next(0, grid.Length)]),
                    (grid[random.Next(0, grid.Length)])
                    };
            return pos;
        }
        private List<NewNode> SetNodeNeighbors(List<NewNode> nodes, float scale)
        {
            /// <summary>
            ///     N 1;0;0
            ///     E 0;0;1
            ///     S -1;0;0
            ///     W 0;0;-1
            ///     T 0;1;0
            ///     B 0;-1;0
            /// </summary>
            List<NewNode> setNodes = new();
            for (int i = 0; i < nodes.Count; i++)
            {
                var currentNode = nodes[i];
                List<NewNode> neighbornodes = new();
                for (int g = 0; g < nodes.Count; g++)
                {
                    /// North
                    if (currentNode.Position.x == nodes[g].Position.x + scale &&
                        currentNode.Position.y == nodes[g].Position.y &&
                        currentNode.Position.z == nodes[g].Position.z
                        )
                    {
                        nodes[g].hCost = currentNode.fCost - nodes[g].fCost;
                        neighbornodes.Add(nodes[g]);
                        //break;
                    }
                    /// East
                    if (currentNode.Position.x == nodes[g].Position.x &&
                        currentNode.Position.y == nodes[g].Position.y &&
                        currentNode.Position.z == nodes[g].Position.z + scale
                       )
                    {
                        nodes[g].hCost = currentNode.fCost - nodes[g].fCost;
                        neighbornodes.Add(nodes[g]);
                        //break;
                    }
                    /// South 
                    if (currentNode.Position.x == nodes[g].Position.x - scale &&
                        currentNode.Position.y == nodes[g].Position.y &&
                        currentNode.Position.z == nodes[g].Position.z
                        )
                    {
                        nodes[g].hCost = currentNode.fCost - nodes[g].fCost;
                        neighbornodes.Add(nodes[g]);
                        //break;
                    }
                    /// West
                    if (currentNode.Position.x == nodes[g].Position.x &&
                        currentNode.Position.y == nodes[g].Position.y &&
                        currentNode.Position.z == nodes[g].Position.z - scale
                       )
                    {
                        nodes[g].hCost = currentNode.fCost - nodes[g].fCost;
                        neighbornodes.Add(nodes[g]);
                        //break;
                    }
                    /// Top
                    if (currentNode.Position.x == nodes[g].Position.x &&
                        currentNode.Position.y == nodes[g].Position.y + scale &&
                        currentNode.Position.z == nodes[g].Position.z
                           )
                    {
                        nodes[g].hCost = currentNode.fCost - nodes[g].fCost;
                        neighbornodes.Add(nodes[g]);
                        //break;
                    }
                    /// Bottom
                    if (currentNode.Position.x == nodes[g].Position.x &&
                        currentNode.Position.y == nodes[g].Position.y - scale &&
                        currentNode.Position.z == nodes[g].Position.z
                           )
                    {
                        nodes[g].hCost = currentNode.fCost - nodes[g].fCost;
                        neighbornodes.Add(nodes[g]);
                        //break;
                    }
                }
                currentNode.Neighbors = neighbornodes;
                setNodes.Add(currentNode);
            }
            return setNodes.Distinct().ToList();
        }
    }
}
