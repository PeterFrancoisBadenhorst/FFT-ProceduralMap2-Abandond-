using System.Collections.Generic;
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
        private List<Vector3> Findpath(List<NewNode> grid, Vector3[] positions)
        {
            List<NewNode> SortedListByPosistion = grid;
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
                        tempNode = ActiveNode.Neighbors[g];
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
    }
}