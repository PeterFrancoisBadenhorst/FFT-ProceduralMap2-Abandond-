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
        [assembly: InternalsVisibleTo("__Tests__")]
        List<GameObject> gridRelations = new();
        [assembly: InternalsVisibleTo("__Tests__")]
        readonly PopulateTilePositions _populateTilePositionsBehavior = new();
        readonly GridCreate _gridCreate = new();
        readonly ChunkHandler _chunkHandler = new();
        readonly NewPathFinding _newPathFinding = new();

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
        public void CreateMap(int GridSize, float GridScale, Transform GridParent, DirectionalTilesScriptableObject scriptRef, int MapTotalFillPercentage, GridTypeEnum gridType)
        {
            // Clear the grid relations list
            gridRelations.Clear();
            // Create a grid.
            Vector3[] grid = _gridCreate.CreateGrid(GridSize, GridScale, gridType);
            // Create a node grid.
            Vector3[] mapGrid = _newPathFinding.NodeGridCreator(grid, GridScale);
            // Create a list of all the points in the map grid.
            List<Vector3> mapTotal = MapTotal(mapGrid);
            // Set the MapTotalFillPercentage variable to the number of points in the grid divided by the MapTotalFillPercentage parameter.
            MapTotalFillPercentage = grid.Length / MapTotalFillPercentage;
            // Populate the map with objects.
            FillMap(mapTotal, MapTotalFillPercentage, grid, GridScale, mapGrid);

            // Populate the gridRelations list with the GameObjects that were placed in the map.
            gridRelations = _gridCreate.PlaceGameObjectsAtGridPositions(mapGrid, GridParent);
            // Find the neighboring chunks
            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);
            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);
            // Assign the chunk types
            gridRelations = _chunkHandler.AssignChunkTypes(gridRelations);
            // Set the child tiles
            _populateTilePositionsBehavior.SetChildTile(scriptRef, gridRelations);

        }

        /**
         * Creates a list of all the points in the map grid.
         *
         * @param mapGrid The map grid.
         *
         * @return A list of all the points in the map grid.
         */
        public List<Vector3> MapTotal(Vector3[] mapGrid)
        {
            // Create a new list to store the map total.
            List<Vector3> MapTotal = new();

            // Iterate through the map grid and add each point to the map total list.
            for (int i = 0; i < mapGrid.Length; i++)
            {
                MapTotal.Add(mapGrid[i]);
            }

            // Return the map total list.
            return MapTotal;
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
        public void FillMap(List<Vector3> mapTotal, float MapTotalFillPercentage, Vector3[] grid, float GridScale, Vector3[] mapGrid)
        {
            // While the map total is less than the desired fill percentage, do the following:
            while (mapTotal.Count < MapTotalFillPercentage)
            {
                // Create a temporary grid from the current map total.
                var tempGrid = mapTotal.Count == 0 ? mapGrid : mapTotal.ToArray();

                // Create a new node grid from the original grid and the temporary grid.
                var temp = _newPathFinding.NodeGridCreator(grid, tempGrid, GridScale);

                // Add all the points in the new node grid to the map total list, but only if they are not already in the list.
                mapTotal.AddRange(temp.Where(p => !mapTotal.Any(q => p.x == q.x && p.y == q.y && p.z == q.z)));
            }
        }
    }
}