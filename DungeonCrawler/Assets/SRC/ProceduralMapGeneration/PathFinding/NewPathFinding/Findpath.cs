using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        /// This method finds the shortest path between two points in a grid.
        /// </summary>
        /// <param name="grid">The grid of points.</param>
        /// <param name="positions">The start and end positions.</param>
        /// <returns>A list of Vector3 objects representing the shortest path between the start and end points.</returns>
        public List<Vector3> Findpath(List<NewNode> grid, Vector3[] positions)
        {
            if (grid == null || grid.Count == 0) { throw new ArgumentNullException("grid"); }
            if (positions == null || positions.Length == 0) { throw new ArgumentNullException("grid"); }

            List<NewNode> sortedListByPosition = new List<NewNode>(grid);
            sortedListByPosition.Reverse();

            NewNode startPos = sortedListByPosition.Find(node => node.Position == positions[0]);
            NewNode endPos = sortedListByPosition.Find(node => node.Position == positions[1]);
            NewNode activeNode = startPos;

            List<NewNode> generatedList = new List<NewNode>();
            List<Vector3> convertedGeneratedList = new List<Vector3>();

            while (activeNode.Position != endPos.Position)
            {
                NewNode tempNode = activeNode.Neighbors.OrderBy(node => node.fCost).First();
                tempNode.LastNode = activeNode;
                activeNode = tempNode;
            }

            while (activeNode.Position != startPos.Position)
            {
                generatedList.Add(activeNode);
                activeNode = activeNode.LastNode;
            }

            generatedList.Reverse();

            foreach (NewNode node in generatedList)
            {
                convertedGeneratedList.Add(node.Position);
            }

            return convertedGeneratedList;
        }
    }
}