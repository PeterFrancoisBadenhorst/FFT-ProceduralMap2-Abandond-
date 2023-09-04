using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Global;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Modles;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.TestTools;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding
{
    public class PathMapBuilder
    {

        /**
        * Creates a map with the specified size, scale, and grid type. The map is then populated with objects, and the neighboring chunks are found. Finally, the chunk types are assigned.
        *
        * @param GridSize The size of the map grid.
        * @param GridScale The scale of the map grid.
        * @param GridParent The parent transform for the map.
        * @param scriptRef The scriptable object that contains the directional tiles data.
        * @param MapTotalFillPercentage The percentage of the map that should be filled with objects.
        * @param gridType The type of grid to create.
        */
        public void CreateMap(ProcedualMapGenCreationModel CreationModel)
        {
            if (CreationModel == null) throw new System.ArgumentNullException(nameof(CreationModel));

            // Clear the grid relations list
            GlobalVariables.CreationModel.GridRelations.Clear();
            // Create a grid.
            GlobalVariables.CreationModel.Grid = GlobalVariables.CreationModel._gridCreate.CreateGrid();
            // Create a node grid.
            GlobalVariables.CreationModel.MapGrid = GlobalVariables.CreationModel._newPathFinding.NodeGridCreator();
            // Create a list of all the points in the map grid.
            GlobalVariables.CreationModel.MapTotal = MapTotal();
            // Set the MapTotalFillPercentage variable to the number of points in the grid divided by the MapTotalFillPercentage parameter.
            GlobalVariables.CreationModel.MapTotalFillPercentage = GlobalVariables.CreationModel.Grid.Length / GlobalVariables.CreationModel.MapTotalFillPercentage;
            // Populate the map with objects.
            FillMap();

            // Populate the gridRelations list with the GameObjects that were placed in the map.
            GlobalVariables.CreationModel._gridCreate.PlaceGameObjectsAtGridPositions();
            // Find the neighboring chunks
            GlobalVariables.CreationModel._chunkHandler.FindChunkNeigbors();

            // Assign the chunk types
            GlobalVariables.CreationModel.GridRelations = GlobalVariables.CreationModel._chunkHandler.AssignChunkTypes(GlobalVariables.CreationModel.GridRelations);
            // Set the child tiles
            GlobalVariables.CreationModel._populateTilePositionsBehavior.SetChildTile();

        }

        /**
         * Creates a list of all the points in the map grid.
         *
         * @param mapGrid The map grid.
         *
         * @return A list of all the points in the map grid.
         */
        public List<Vector3> MapTotal()
        {
            // Create a new list to store the map total.
            GlobalVariables.CreationModel.MapTotal = new();

            // Iterate through the map grid and add each point to the map total list.
            for (int i = 0; i < GlobalVariables.CreationModel.MapGrid.Length; i++)
            {
                GlobalVariables.CreationModel.MapTotal.Add(GlobalVariables.CreationModel.MapGrid[i]);
            }

            // Return the map total list.
            return GlobalVariables.CreationModel.MapTotal;
        }

        /**
         * Populates the map with objects.
         *
         * @param mapTotal The list of all the points in the map grid.
         * @param MapTotalFillPercentage The percentage of the map that should be filled with objects.
         * @param grid The original grid.
         * @param GridScale The scale of the map grid.
         * @param mapGrid The current map grid.
         */
        public void FillMap()
        {
            // While the map total is less than the desired fill percentage, do the following:
            while (GlobalVariables.CreationModel.MapTotal.Count < GlobalVariables.CreationModel.MapTotalFillPercentage)
            {
                // Create a temporary grid from the current map total.
                var tempGrid = GlobalVariables.CreationModel.MapTotal.Count == 0 ? GlobalVariables.CreationModel.MapGrid : GlobalVariables.CreationModel.MapTotal.ToArray();

                // Create a new node grid from the original grid and the temporary grid.
                var temp = GlobalVariables.CreationModel._newPathFinding.NodeGridCreator(GlobalVariables.CreationModel.Grid, tempGrid, GlobalVariables.CreationModel.GridScale);

                // Add all the points in the new node grid to the map total list, but only if they are not already in the list.
                GlobalVariables.CreationModel.MapTotal.AddRange(temp.Where(p => !GlobalVariables.CreationModel.MapTotal.Any(q => p.x == q.x && p.y == q.y && p.z == q.z)));
            }
        }
    }
}