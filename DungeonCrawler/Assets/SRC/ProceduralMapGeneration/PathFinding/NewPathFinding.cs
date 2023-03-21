using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Assets.SRC.Shared.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding
{
    internal class NewPathFinding
    {
        /// <summary>
        /// H Cost => Diff to neighbors
        /// F Cost => Diff to end point
        /// ToDo:
        ///  Get grid
        ///  create node per pos in grid   -
        ///  end-start node chooser
        ///  Set Neighbors of Nodes -
        ///  Itterate through Neighbors to get to end node
        /// </summary>
        VectorMath vMath = new VectorMath();
        private List<NewNode> NodeGridCreator(Vector3[] grid, Vector3 endPos)
        {
            List<NewNode> nodes = new();
            for (int i = 0; i < grid.Length; i++)
            {

                NewNode node = new();
                node.Position = grid[i];
                node.fCost = vMath.CalculateDistanceBetweenTwoVectors(node.Position, endPos);
                nodes.Add(node);
            }
            return nodes;
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
                for (int g = 0; g < nodes.Count; g++)
                {
                    List<NewNode> neighbornodes = new();
                    var currentNode = nodes[i];
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
                    currentNode.Neighbors = neighbornodes;
                    setNodes.Add(currentNode);
                }
            }
            return setNodes;
        }
    }
}
