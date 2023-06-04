using System.Collections.Generic;
using UnityEngine;
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
        /// This method creates a grid of nodes and finds the shortest path between two points in the grid.
        /// </summary>
        /// <param name="grid">The grid of points.</param>
        /// <param name="baseMap">The base map.</param>
        /// <param name="scale">The scale of the nodes.</param>
        /// <returns>An array of Vector3 objects representing the shortest path between the start and end points.</returns>
        public Vector3[] NodeGridCreator(Vector3[] grid, Vector3[] baseMap, float scale)
        {
            Vector3[] ends =
                {
                     (baseMap[random.Next(0, baseMap.Length)]),
                     (grid[random.Next(0, grid.Length)])
                 };
            return ReturnPath(grid, scale, ends);
        }
        /// <summary>
        /// This method creates a grid of nodes and finds the shortest path between two points in the grid.
        /// </summary>
        /// <param name="grid">The grid of points.</param>
        /// <param name="scale">The scale of the nodes.</param>
        /// <returns>An array of Vector3 objects representing the shortest path between the start and end points.</returns>
        public Vector3[] NodeGridCreator(Vector3[] grid, float scale)
        {
            var ends = FindEnds(grid);   //[0] start [1]end
            return ReturnPath(grid, scale, ends);
        }

        public List<NewNodeModel> CreateNodes(Vector3[] grid, Vector3 endPos)
        {
            List<NewNodeModel> nodes = new List<NewNodeModel>();

            for (int i = 0; i < grid.Length; i++)
            {
                NewNodeModel node = new NewNodeModel();
                node.Position = grid[i];
                node.fCost = vMath.CalculateDistanceBetweenTwoVectors(node.Position, endPos);
                nodes.Add(node);
            }

            return nodes;
        }

        public Vector3[] ReturnPath(Vector3[] grid, float scale, Vector3[] ends)
        {

            List<NewNodeModel> nodes = new();
            nodes = CreateNodes(grid, ends[1]);

            nodes = SetNodeNeighbors(nodes, scale);
            List<Vector3> path = Findpath(nodes, ends);

            return path.ToArray();
        }
    }
}