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
    internal partial class NewPathFinding
    {
        /// <summary>
        /// This method finds the start and end points of the path.
        /// </summary>
        /// <param name="grid">The grid of points.</param>
        /// <returns>An array of Vector3 objects representing the start and end points.</returns>
        private Vector3[] FindEnds(Vector3[] grid)
        {
            Vector3[] pos =
            {
            (grid[random.Next(0, grid.Length)]),
            (grid[random.Next(0, grid.Length)])
            };
            return pos;
        }
    }
}