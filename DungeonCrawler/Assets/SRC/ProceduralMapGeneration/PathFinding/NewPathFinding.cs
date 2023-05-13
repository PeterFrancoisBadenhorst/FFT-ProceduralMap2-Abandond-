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
        // This method creates a node grid using the provided parameters and returns a path as an array of Vector3 objects.
        public Vector3[] NodeGridCreator(Vector3[] grid, Vector3[] baseMap, float scale)
        {
            // Define the start and end points of the path.
            Vector3[] ends ={
        (baseMap[random.Next(0, baseMap.Length)]),
        (grid[random.Next(0, grid.Length)])
    };

            // Create a list to hold the NewNode objects that represent each point in the grid.
            List<NewNode> nodes = new();

            // Iterate through each point in the grid.
            for (int i = 0; i < grid.Length; i++)
            {
                // Create a new NewNode object for this point in the grid.
                NewNode node = new();

                // Set the position of the NewNode object to the current point in the grid.
                node.Position = grid[i];

                // Calculate the fCost of the NewNode object based on its distance from the end point.
                node.fCost = vMath.CalculateDistanceBetweenTwoVectors(node.Position, ends[1]);

                // Add the NewNode object to the list of nodes.
                nodes.Add(node);
            }

            // Set the neighbors of each node in the list using the specified scale.
            nodes = SetNodeNeighbors(nodes, scale); // glitch happens here

            // Find the shortest path between the start and end points using the A* algorithm.
            List<Vector3> path = Findpath(nodes, ends); // glitch happens before

            // Return the path as an array of Vector3 objects.
            return path.ToArray();
        }

        public Vector3[] NodeGridCreator(Vector3[] grid, float scale)
        {
            // Find start and end points
            var ends = FindEnds(grid);   //[0] start [1]end

            // Create an empty list to store NewNodes
            List<NewNode> nodes = new();

            // Loop through the grid points and create a NewNode for each point
            for (int i = 0; i < grid.Length; i++)
            {
                // Create a new instance of the NewNode class and set its position and fCost properties
                NewNode node = new();
                node.Position = grid[i];
                node.fCost = vMath.CalculateDistanceBetweenTwoVectors(node.Position, ends[1]);

                // Add the node to the list of nodes
                nodes.Add(node);
            }

            // Set the neighbors for each node
            nodes = SetNodeNeighbors(nodes, scale);              

            // Find the path between the start and end points
            List<Vector3> path = Findpath(nodes, ends);        

            // Convert the list of Vector3s to an array and return it
            return path.ToArray();
        }
        private List<Vector3> Findpath(List<NewNode> grid, Vector3[] positions)
        {
            // Sorts the grid nodes by their position and reverses the list
            List<NewNode> SortedListByPosistion = grid;
            SortedListByPosistion.Reverse();

            // Creates new nodes for the start and end positions
            NewNode startPos = new();
            NewNode endPos = new();
            NewNode ActiveNode = null;

            // Flags to check if the start and end positions have been found
            bool endPosFound = false;
            bool startPosFound = false;

            // Lists to store the generated and converted paths
            List<NewNode> generatedList = new();
            List<Vector3> convertedGeneratedList = new();

            // Assigns the start and end positions to their respective nodes
            startPos.Position = positions[0];
            endPos.Position = positions[1];

            // Finds the node in the sorted list with the same position as the start position
            for (int i = 0; i < SortedListByPosistion.Count; i++)
            {
                if (SortedListByPosistion[i].Position == startPos.Position)
                {
                    startPos = SortedListByPosistion[i];
                    break;
                }
            }

            ActiveNode = startPos;

            // Finds the shortest path to the end position
            while (!endPosFound)
            {
                NewNode tempNode = ActiveNode;

                // Looks through the neighbors of the active node to find the node with the lowest fCost
                for (int g = 0; g < ActiveNode.Neighbors.Count; g++)
                {
                    if (tempNode.fCost > ActiveNode.Neighbors[g].fCost)
                    {
                        tempNode = ActiveNode.Neighbors[g];
                    }
                }

                // Sets the last node of the tempNode to the active node and sets the active node to the tempNode
                tempNode.LastNode = ActiveNode;
                ActiveNode = tempNode;

                // If the active node has the same position as the end position, set endPos to the active node and end the loop
                if (ActiveNode.Position == endPos.Position)
                {
                    endPos = ActiveNode;
                    endPosFound = true;
                }
            };

            // Generates the path from the end position to the start position
            while (!startPosFound)
            {
                ActiveNode = ActiveNode.LastNode;
                generatedList.Add(ActiveNode);

                // If the active node has the same position as the start position, end the loop
                if (ActiveNode.Position == startPos.Position)
                {
                    startPosFound = true;
                }
            }

            // Converts the generated path from a list of NewNodes to a list of Vector3s
            for (int i = 0; i < generatedList.Count; i++)
            {
                convertedGeneratedList.Add(generatedList[i].Position);
            }

            // Returns the converted path
            return convertedGeneratedList;
        }

        private NewNode GetNextNode(NewNode node)
        {
            // Initialize variables
            float dis = float.MaxValue;
            NewNode returnedNode = null;
            var t = node.Neighbors.Count;

            // Iterate over the neighbors of the given node
            for (int i = 0; i < t; i++)
            {
                // If the fCost of the neighbor is smaller than the current smallest distance
                if (node.Neighbors[i].fCost <= dis)
                {
                    // Set the smallest distance to the neighbor's fCost
                    dis = node.Neighbors[i].fCost;
                    // Set the returned node to the current neighbor
                    returnedNode = node.Neighbors[i];
                }
            }

            // Set the last node of the returned node to the given node
            returnedNode.LastNode = node;

            // Return the neighbor with the smallest fCost
            return returnedNode;
        }
        // Finds two random Vector3 positions from the given grid array to serve as start and end points
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
