using System.Collections.Generic;
using System.Linq;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding
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
    public partial class NewPathFinding
    {
        /// <summary>
        /// This method sets the neighbors of each node in the list.
        /// </summary>
        /// <param name="nodes">The list of nodes.</param>
        /// <param name="scale">The scale of the nodes.</param>
        /// <returns>A list of nodes with their neighbors set.</returns>
        private List<NewNode> SetNodeNeighbors(List<NewNode> nodes, float scale)
        {
            /// <summary>
            /// This comment block defines the directions of the neighbors.
            /// </summary>
            /// <remarks>
            /// N = North
            /// E = East
            /// S = South
            /// W = West
            /// T = Top
            /// B = Bottom
            /// </remarks>

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
                    }
                    /// East
                    if (currentNode.Position.x == nodes[g].Position.x &&
                        currentNode.Position.y == nodes[g].Position.y &&
                        currentNode.Position.z == nodes[g].Position.z + scale
                       )
                    {
                        nodes[g].hCost = currentNode.fCost - nodes[g].fCost;
                        neighbornodes.Add(nodes[g]);
                    }
                    /// South
                    if (currentNode.Position.x == nodes[g].Position.x - scale &&
                        currentNode.Position.y == nodes[g].Position.y &&
                        currentNode.Position.z == nodes[g].Position.z
                        )
                    {
                        nodes[g].hCost = currentNode.fCost - nodes[g].fCost;
                        neighbornodes.Add(nodes[g]);
                    }
                    /// West
                    if (currentNode.Position.x == nodes[g].Position.x &&
                        currentNode.Position.y == nodes[g].Position.y &&
                        currentNode.Position.z == nodes[g].Position.z - scale
                       )
                    {
                        nodes[g].hCost = currentNode.fCost - nodes[g].fCost;
                        neighbornodes.Add(nodes[g]);
                    }
                    /// Top
                    if (currentNode.Position.x == nodes[g].Position.x &&
                        currentNode.Position.y == nodes[g].Position.y + scale &&
                        currentNode.Position.z == nodes[g].Position.z
                                   )
                    {
                        nodes[g].hCost = currentNode.fCost - nodes[g].fCost;
                        neighbornodes.Add(nodes[g]);
                    }
                    /// Bottom
                    if (currentNode.Position.x == nodes[g].Position.x &&
                        currentNode.Position.y == nodes[g].Position.y - scale &&
                        currentNode.Position.z == nodes[g].Position.z
                                   )
                    {
                        nodes[g].hCost = currentNode.fCost - nodes[g].fCost;
                        neighbornodes.Add(nodes[g]);
                    }
                }
                currentNode.Neighbors = neighbornodes;
                setNodes.Add(currentNode);
            }
            return setNodes.Distinct().ToList();
        }
    }
}