using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        public void CreateMap(int GridSize, float GridScale, Transform GridParent, DirectionalTilesScriptableObject scriptRef, int MapTotalFillPercentage, GridTypeEnum gridType, GameObject playerPrefab)
        {
            // Clear the grid relations list
            gridRelations.Clear();
            // Create a grid.
            Vector3[] grid = _gridCreate.CreateGrid(GridSize, GridScale, gridType);
            // Create a node grid.
            Vector3[] mapGrid = _newPathFinding.NodeGridCreator(grid, GridScale);
            // Create a list of all the points in the map grid.
            List<Vector3> mapTotal = MapTotal(mapGrid);
            // Add branches to the map path.
            MapTotalFillPercentage = grid.Length / MapTotalFillPercentage;
            if (MapTotalFillPercentage < 75) MapTotalFillPercentage = 75;
            int itt = 0;
            while ( itt <= 4)
            {
                if (mapTotal.Count > MapTotalFillPercentage) break;

                Debug.Log(itt+"|"+MapTotalFillPercentage+"|"+mapTotal.Count());
                itt++;
                var t = _newPathFinding.NodeGridCreator(grid, GridScale, mapTotal.ToArray());
                for (int i = 0; i < t.Length; i++)
                {
                    mapTotal.Add(t[i]);
                }
            }
            mapTotal = mapTotal.Distinct().ToList();

            // Populate the gridRelations list with the GameObjects that were placed in the map.
            gridRelations = _gridCreate.PlaceGameObjectsAtGridPositions(mapTotal.ToArray(), GridParent);
            // Find the neighboring chunks
            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);
            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);
            // Assign the chunk types
            gridRelations = _chunkHandler.AssignChunkTypes(gridRelations);
            // Set the child tiles
            _populateTilePositionsBehavior.SetChildTile(scriptRef, gridRelations);
            // Instantiate the player prefab

            PlacePlayer(playerPrefab, gridRelations[0].transform.position);


        }

        public void PlacePlayer(GameObject playerPrefab, Vector3 pos)
        {
            var t = UtilitiesBehaviour.InstantiateObject(playerPrefab, Vector3.zero, Quaternion.identity);
            t.transform.position = pos;
            //t.SetActive(true);
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

    }
}