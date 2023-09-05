using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Assets.SRC.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding
{
    public class NewPathFinding
    {
        private readonly VectorMath vMath = new();
        private readonly System.Random random = new();

        /**
         * Sets the neighbors for each node in the list of nodes.
         *
         * @param nodes The list of nodes.
         * @param scale The scale of the grid.
         *
         * @return The list of nodes with their neighbors set.
         */
        public List<NewNodeModel> SetNodeNeighbors(List<NewNodeModel> nodes, float scale)
        {
            // Create a list to store the nodes with their neighbors set.
            List<NewNodeModel> setNodes = new();

            // Iterate over each node in the list of nodes.
            for (int i = 0; i < nodes.Count; i++)
            {
                // Get the current node.
                var currentNode = nodes[i];

                // Set the neighbors for the current node.
                currentNode.Neighbors = FindNeighbors(currentNode, nodes, scale);

                // Add the current node to the list of nodes with their neighbors set.
                setNodes.Add(currentNode);
            }

            // Return the list of nodes with their neighbors set.
            return setNodes;
        }

        /**
         * Finds the neighbors for the specified node.
         *
         * @param node The node to find the neighbors for.
         * @param nodes The list of nodes.
         * @param scale The scale of the grid.
         *
         * @return The list of neighbors for the specified node.
         */
        public static List<NewNodeModel> FindNeighbors(NewNodeModel node, List<NewNodeModel> nodes, float scale)
        {
            // Create a list to store the neighbors for the specified node.
            List<NewNodeModel> neighbors = new();

            // Iterate over each node in the list of nodes.
            for (int i = 0; i < nodes.Count; i++)
            {
                // Check if the specified node is a neighbor of the current node.
                if (ComparePositions(node.Position, nodes[i].Position, scale))
                {
                    // Add the current node to the list of neighbors for the specified node.
                    neighbors.Add(nodes[i]);
                }
            }

            // Return the list of neighbors for the specified node.
            return neighbors;
        }
        /**
        * Compares the positions of two nodes.
        *
        * @param poasA The position of the first node.
        * @param posB The position of the second node.
        * @param multiplier The scale of the grid.
        *
        * @return True if the two nodes are neighbors, false otherwise.
        *
        * This function compares the positions of two nodes to see if they are neighbors. It does this by creating a list of directions that a node can move in, and then iterating over the list to see if the specified position is equal to any of the directions. If the positions are equal, then the function returns true. Otherwise, the function returns false.
        */
        public static bool ComparePositions(Vector3 poasA, Vector3 posB, float multiplier)
        {
            // Create a list of directions to check.
            Vector3[] directions = new Vector3[]
            {
                new Vector3(0, 1, 0) * multiplier + posB,
                new Vector3(0, 0, 1) * multiplier + posB,
                new Vector3(0, 0, -1) * multiplier + posB,
                new Vector3(0, -1, 0) * multiplier + posB,
                new Vector3(1, 0, 0) * multiplier + posB,
                new Vector3(-1, 0, 0) * multiplier + posB
            };

            // Iterate over the directions.
            for (int i = 0; i < directions.Length; i++)
            {
                // Check if the specified position is equal to any of the directions.
                if (poasA.x == directions[i].x &&
                    poasA.y == directions[i].y &&
                    poasA.z == directions[i].z)
                {
                    // The positions are equal, so return true.
                    return true;
                }
            }

            // The positions are not equal, so return false.
            return false;
        }
        /**
        * Creates a node grid from the specified grid and base map.
        *
        * @param grid The grid to create the node grid from.
        * @param baseMap The base map to use for the node grid.
        * @param scale The scale of the node grid.
        *
        * @return The node grid.
        *
        * This function creates a node grid by first randomly choosing two end points in the `baseMap` and `grid` arrays. It then calls the `ReturnPath()` function to create a path between the end points. The `ReturnPath()` function takes the `grid`, `scale`, and `ends` arrays as input and returns a list of vectors that represent the path. The function then returns the path as the output of the function.
        */
        public Vector3[] NodeGridCreator(Vector3[] grid, Vector3[] baseMap, float scale)
        {
            // Create a list of end points.
            Vector3[] ends = new Vector3[]
            {
                baseMap[random.Next(0, baseMap.Length)],
                grid[random.Next(0, grid.Length)]
            };

            // Create a path between the end points.
            Vector3[] path = ReturnPath(grid, scale, ends);

            // Return the path.
            return path;
        }

        /**
         * Creates a grid of the specified size, scale, and grid type.
         *
         * @param gridSize The size of the grid.
         * @param scale The scale of the grid.
         * @param gridType The type of grid to create.
         *
         * @return The grid points.
         */
        public Vector3[] NodeGridCreator(Vector3[] grid, float scale)
        {
            // Find the start and end points of the grid.
            var ends = FindEnds(grid);   //[0] start [1]end

            // Return the path between the start and end points.
            return ReturnPath(grid, scale, ends);
        }
        /**
        * Creates a list of nodes in a grid, where each node represents the distance to the end point.
        *
        * @param grid The array of points in the grid.
        * @param endPos The end point of the grid.
        *
        * @return The list of nodes.
        */
        public List<NewNodeModel> CreateNodes(Vector3[] grid, Vector3 endPos)
        {
            // Create an empty list of nodes.
            List<NewNodeModel> nodes = new();

            // Iterate through the grid and create a new node for each point.
            for (int i = 0; i < grid.Length; i++)
            {
                // Create a new node.
                NewNodeModel node = new()
                {
                    // Set the node's position to the current point in the grid.
                    Position = grid[i]
                };

                // Set the node's fCost to the distance between the point and the endPos object.
                node.fCost = vMath.CalculateDistanceBetweenTwoVectors(node.Position, endPos);

                // Add the node to the list of nodes.
                nodes.Add(node);
            }

            // Return the list of nodes.
            return nodes;
        }
        /**
        * Returns the path between the start and end points of a grid.
        *
        * @param grid The array of points in the grid.
        * @param scale The scale of the grid.
        * @param ends The start and end points of the grid.
        *
        * @return The path between the start and end points.
        */
        public Vector3[] ReturnPath(Vector3[] grid, float scale, Vector3[] ends)
        {
            // Create an empty list of nodes.
            List<NewNodeModel> nodes = new();

            // Create a list of nodes in the grid.
            nodes = CreateNodes(grid, ends[1]);

            // Set the neighbors of each node.
            nodes = SetNodeNeighbors(nodes, scale);

            // Find the path between the start and end points.
            List<Vector3> path = Findpath(nodes, ends);

            // Return the path.
            return path.ToArray();
        }
        /**
        * Finds the path between the start and end points of a grid using the A* algorithm.
        *
        * @param grid The list of nodes in the grid.
        * @param positions The start and end points of the grid.
        *
        * @return The path between the start and end points.
        */
        public List<Vector3> Findpath(List<NewNodeModel> grid, Vector3[] positions)
        {
            // Check if the grid or positions parameters are null or have zero elements.
            if (grid == null || grid.Count == 0) { throw new ArgumentNullException("grid"); }
            if (positions == null || positions.Length == 0) { throw new ArgumentNullException("grid"); }

            // Sort the grid list by the Position property.
            List<NewNodeModel> sortedListByPosition = new(grid);
            sortedListByPosition.Reverse();

            // Find the start and end points of the grid.
            NewNodeModel startPos = sortedListByPosition.Find(node => node.Position == positions[0]);
            NewNodeModel endPos = sortedListByPosition.Find(node => node.Position == positions[1]);

            // Create a new node called activeNode and set it to the start point.
            NewNodeModel activeNode = startPos;

            // Create two empty lists: generatedList and convertedGeneratedList.
            List<NewNodeModel> generatedList = new();
            List<Vector3> convertedGeneratedList = new();

            // Find the next node on the path using the FindActiveNode() function.
            activeNode = FindActiveNode(activeNode, endPos);

            // Generate the path from the start point to the end point using the GeneratePath() function.
            generatedList = GeneratePath(activeNode, startPos);

            // Convert the generatedList list to a list of Vector3 objects using the ConvertPathToPositions() function.
            convertedGeneratedList = ConvertPathToPositions(generatedList);

            // Return the convertedGeneratedList list.
            return convertedGeneratedList;
        }
        /**
         * Finds the next node on the path from the start node to the end node using the A* algorithm.
         *
         * @param activeNode The current node on the path.
         * @param endPos The end node of the path.
         *
         * @return The next node on the path.
         *
         * @throws NullReferenceException If the activeNode variable is null.
         */
        public NewNodeModel FindActiveNode(NewNodeModel activeNode, NewNodeModel endPos)
        {
            // Enter a while loop.
            while (activeNode.Position != endPos.Position)
            {
                // Get the first node in the activeNode's Neighbors list, sorted by the fCost property.
                NewNodeModel tempNode = activeNode.Neighbors.OrderBy(node => node.fCost).First();

                // Set the tempNode variable to the first node.
                tempNode.LastNode = activeNode;

                // Set the activeNode variable to the tempNode variable.
                activeNode = tempNode;
            }

            // If the activeNode variable is null, then throw a NullReferenceException exception.
            if (activeNode == null) { throw new NullReferenceException(); }

            // Return the activeNode variable.
            return activeNode;
        }
        /**
        * Generates the path from the start node to the end node using the A* algorithm.
        *
        * @param activeNode The current node on the path.
        * @param startPos The start node of the path.
        *
        * @return The path from the start node to the end node.
        */
        public List<NewNodeModel> GeneratePath(NewNodeModel activeNode, NewNodeModel startPos)
        {
            // Create a new list called generatedList.
            List<NewNodeModel> generatedList = new();

            // Loop as long as the activeNode's Position property is not equal to the startPos's Position property.
            while (activeNode.Position != startPos.Position)
            {
                // Add the activeNode to the generatedList list.
                generatedList.Add(activeNode);

                // Set the activeNode to the activeNode's LastNode property.
                activeNode = activeNode.LastNode;
            }

            // Reverse the generatedList list.
            generatedList.Reverse();

            // Return the generatedList list.
            return generatedList;
        }
        /**
        * Converts a list of NewNodeModel objects to a list of Vector3 objects by getting the Position property of each node.
        *
        * @param generatedList The list of NewNodeModel objects to convert.
        *
        * @return The list of Vector3 objects.
        */
        public List<Vector3> ConvertPathToPositions(List<NewNodeModel> generatedList)
        {
            // Create a new list called convertedGeneratedList.
            List<Vector3> convertedGeneratedList = new();

            // Loop through the generatedList parameter and add the Position property of each node to the convertedGeneratedList list.
            foreach (NewNodeModel node in generatedList)
            {
                convertedGeneratedList.Add(node.Position);
            }

            // Return the convertedGeneratedList list.
            return convertedGeneratedList;
        }
        /**
        * Finds two random points in a grid that are not the same point.
        *
        * @param grid The array of points in the grid.
        *
        * @return An array of two Vector3 objects that represent the start and end points.
        */
        public Vector3[] FindEnds(Vector3[] grid)
        {
            // Create a local variable called pos and initialize it to a new array of Vector3 objects with two elements.
            Vector3[] pos = new Vector3[]
            {
        (grid[random.Next(0, grid.Length)]),
        (grid[random.Next(0, grid.Length)])
            };

            // Enter a do-while loop.
            do
            {
                // Generate two random numbers between 0 and the length of the grid array.
                pos[0] = grid[random.Next(0, grid.Length)];
                pos[1] = grid[random.Next(0, grid.Length)];

                // Check if the first and second elements of the pos array are equal.
                if (pos[0] == pos[1])
                {
                    // Go back to the beginning of the loop.
                    continue;
                }

                // Break out of the loop.
                break;
            } while (true);

            // Return the pos array.
            return pos;
        }
    }
}