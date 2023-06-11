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
        public List<Vector3> Findpath(List<NewNodeModel> grid, Vector3[] positions)
        {
            if (grid == null || grid.Count == 0) { throw new ArgumentNullException("grid"); }
            if (positions == null || positions.Length == 0) { throw new ArgumentNullException("grid"); }

            List<NewNodeModel> sortedListByPosition = new List<NewNodeModel>(grid);
            sortedListByPosition.Reverse();
            NewNodeModel startPos = sortedListByPosition.Find(node => node.Position == positions[0]);
            NewNodeModel endPos = sortedListByPosition.Find(node => node.Position == positions[1]);
            NewNodeModel activeNode = startPos;
            List<NewNodeModel> generatedList = new List<NewNodeModel>();
            List<Vector3> convertedGeneratedList = new List<Vector3>();

            activeNode = FindActiveNode(activeNode, endPos);
            generatedList = GeneratePath(activeNode, startPos);
            convertedGeneratedList = ConvertPathToPositions(generatedList);

            return convertedGeneratedList;
        }
        public NewNodeModel FindActiveNode(NewNodeModel activeNode, NewNodeModel endPos)
        {
            while (activeNode.Position != endPos.Position)
            {
                NewNodeModel tempNode = activeNode.Neighbors.OrderBy(node => node.fCost).First();
                tempNode.LastNode = activeNode;
                activeNode = tempNode;
            }
            if (activeNode == null) { throw new NullReferenceException(); }
            return activeNode;
        }
        public List<NewNodeModel> GeneratePath(NewNodeModel activeNode, NewNodeModel startPos)
        {
            List<NewNodeModel> generatedList = new List<NewNodeModel>();

            while (activeNode.Position != startPos.Position)
            {
                generatedList.Add(activeNode);
                activeNode = activeNode.LastNode;
            }
            generatedList.Reverse();
            return generatedList;
        }
        public List<Vector3> ConvertPathToPositions(List<NewNodeModel> generatedList)
        {
            List<Vector3> convertedGeneratedList = new List<Vector3>();

            foreach (NewNodeModel node in generatedList)
            {
                convertedGeneratedList.Add(node.Position);
            }

            return convertedGeneratedList;
        }
    }
}