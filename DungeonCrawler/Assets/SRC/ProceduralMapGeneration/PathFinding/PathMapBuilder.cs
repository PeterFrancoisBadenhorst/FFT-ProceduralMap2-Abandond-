using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding
{
    internal class PathMapBuilder
    {
        private List<GameObject> gridRelations = new();

        private readonly PopulateTilePositions _populateTilePositionsBehavior = new();
        private readonly GridCreate _gridCreate = new();
        private readonly ChunkHandler _chunkHandler = new();
        private readonly NewPathFinding _newPathFinding = new();

        /// <summary>
        /// Creates a pathfinding map.
        /// </summary>
        /// <param name="iterations">The number of iterations to run.</param>
        /// <param name="gridSize">The size of the grid.</param>
        /// <param name="gridScale">The scale of the grid.</param>
        /// <param name="gridParent">The parent transform for the grid.</param>
        /// <param name="scriptRef">The reference to the directional tiles scriptable object.</param>
        public void CreateMap(int iterations, int gridSize, float gridScale, Transform gridParent, DirectionalTilesScriptableObject scriptRef)
        {
            // Clear the grid relations.
            gridRelations.Clear();

            // Create a 2D grid of squares.
            Vector3[] grid = _gridCreate.SquareGrid2DHorizontal(gridSize, gridScale);

            // Create a node grid from the 2D grid.
            Vector3[] mapGrid = _newPathFinding.NodeGridCreator(grid, gridScale);

            // Create a list of all the positions in the map grid.
            List<Vector3> mapTotal = new List<Vector3>();
            for (int i = 0; i < mapGrid.Length; i++)
            {
                mapTotal.Add(mapGrid[i]);
            }

            // Log that the loop is starting.
            Debug.Log($"Starting loop. Iterations: {iterations}");

            // Iterate over the number of iterations.
            for (int h = 0; h < iterations; h++)
            {
                // Log the current iteration.
                Debug.Log($"Iteration {h + 1} of {iterations}");

                // Create a list of positions for the current iteration.
                List<Vector3> positions = new();

                // Create a node grid for the current iteration.
                var temp = _newPathFinding.NodeGridCreator(grid, mapGrid, gridScale);

                // Add the positions from the node grid to the list of positions for the current iteration.
                for (int g = 0; g < temp.Length; g++)
                {
                    positions.Add(temp[g]);
                }

                // Add the list of positions for the current iteration to the list of all the positions in the map grid.
                mapTotal.AddRange(positions);
            }

            // Log that the loop is complete.
            Debug.Log($"Loop complete. Objects count: {mapTotal.Count}");

            // Remove duplicate positions from the list of all the positions in the map grid.
            mapGrid = mapTotal.Distinct().ToArray();

            // Place game objects at the positions in the map grid.
            gridRelations = _gridCreate.PlaceGameObjectsAtGridPositions(mapGrid, gridParent);

            // Find the neighbors of each chunk.
            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);

            // Assign chunk types to each chunk.
            _chunkHandler.AssignChunkTypes(gridRelations);

            // Set the child tile for each chunk.
            _populateTilePositionsBehavior.SetChildTile(scriptRef, gridRelations);
        }
    }
}
