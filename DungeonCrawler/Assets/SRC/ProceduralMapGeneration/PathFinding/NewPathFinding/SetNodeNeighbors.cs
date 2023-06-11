using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine.UIElements;

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
        private List<NewNodeModel> SetNodeNeighbors(List<NewNodeModel> nodes, float scale)
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

            List<NewNodeModel> setNodes = new();
            for (int i = 0; i < nodes.Count; i++)
            {
                var currentNode = nodes[i];
                List<NewNodeModel> neighbornodes = new();
                currentNode.Neighbors = FindNeighbors(currentNode, nodes, scale);
                setNodes.Add(currentNode);
            }
            return setNodes.Distinct().ToList();
        }
        public static List<NewNodeModel> FindNeighbors(NewNodeModel node, List<NewNodeModel> nodes, float scale)
        {
            List<NewNodeModel> neighbors = new List<NewNodeModel>();

            for (int i = 0; i < nodes.Count; i++)
            {
                //IsNeighbor(node,)



                /// North
                if (node.Position.x == nodes[i].Position.x + scale &&
                    node.Position.y == nodes[i].Position.y &&
                    node.Position.z == nodes[i].Position.z
                    )
                {
                    neighbors.Add(nodes[i]);
                }

                /// East
                if (node.Position.x == nodes[i].Position.x &&
                    node.Position.y == nodes[i].Position.y &&
                    node.Position.z == nodes[i].Position.z + scale
                    )
                {
                    neighbors.Add(nodes[i]);
                }

                /// South
                if (node.Position.x == nodes[i].Position.x - scale &&
                    node.Position.y == nodes[i].Position.y &&
                    node.Position.z == nodes[i].Position.z
                    )
                {
                    neighbors.Add(nodes[i]);
                }

                /// West
                if (node.Position.x == nodes[i].Position.x &&
                    node.Position.y == nodes[i].Position.y &&
                    node.Position.z == nodes[i].Position.z - scale
                    )
                {
                    neighbors.Add(nodes[i]);
                }

                /// Top
                if (node.Position.x == nodes[i].Position.x &&
                    node.Position.y == nodes[i].Position.y + scale &&
                    node.Position.z == nodes[i].Position.z
                            )
                {
                    neighbors.Add(nodes[i]);
                }

                /// Bottom
                if (node.Position.x == nodes[i].Position.x &&
                    node.Position.y == nodes[i].Position.y - scale &&
                    node.Position.z == nodes[i].Position.z
                            )
                {
                    neighbors.Add(nodes[i]);
                }
            }

            return neighbors;
        }
        //public bool IsNeighbor(NewNodeModel node, Vector3 multiplier, NewNodeModel nodeCompared)
        //{
        //    Vector3 north = new Vector3(0, 1, 0);
        //    Vector3 east = new Vector3(0, 0, 1);
        //    Vector3 west = new Vector3(0, 0, -1);
        //    Vector3 south = new Vector3(0, -1, 0);
        //    Vector3 top = new Vector3(1, 0, 0);
        //    Vector3 bottom = new Vector3(-1, 0, 0);
        //    int count;
        //        node.Position.x == nodeCompared.Position.x + multiplier.X &&
        //        node.Position.y == nodeCompared.Position.y + multiplier.Y &&
        //        node.Position.z == nodeCompared.Position.z + multiplier.Z

        //}

    }
}