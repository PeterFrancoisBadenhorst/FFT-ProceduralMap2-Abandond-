using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding
{
    internal class PathMapBuilder
    {
        private List<GameObject> gridRelations = new();

        private readonly PopulateTilePositions _populateTilePositionsBehavior = new();
        private readonly GridCreate _gridCreate = new();
        private readonly ChunkHandler _chunkHandler = new();
        private readonly NewPathFinding _newPathFinding = new();

        /// <summary>
        /// This method creates a map.
        /// </summary>
        /// <param name="GridSize">The size of the grid.</param>
        /// <param name="GridScale">The scale of the grid.</param>
        /// <param name="GridParent">The parent transform of the grid.</param>
        /// <param name="scriptRef">The reference to the directional tiles scriptable object.</param>
        /// <param name="MapTotalFillPercentage">The percentage of the map that should be filled.</param>
        public void CreateMap(int GridSize, float GridScale, Transform GridParent, DirectionalTilesScriptableObject scriptRef, int MapTotalFillPercentage)
        {
            gridRelations.Clear();
            Vector3[] grid = _gridCreate.SquareGrid3D(GridSize, GridScale);
            Vector3[] mapGrid = _newPathFinding.NodeGridCreator(grid, GridScale);
            List<object> objects = new();
            List<Vector3> MapTotal = new List<Vector3>();
            for (int i = 0; i < mapGrid.Length; i++)
            {
                MapTotal.Add(mapGrid[i]);
            }
            Debug.Log($"Starting loop.");
            MapTotalFillPercentage = grid.Length / MapTotalFillPercentage;
            int loopCount = 0;
            while (MapTotal.Count < MapTotalFillPercentage)
            {
                loopCount++;
                Debug.Log($"Iteration {loopCount} as {MapTotal.Count} is less than {MapTotalFillPercentage}");
                var tempGrid = (MapTotal.Count == 0) ? mapGrid : MapTotal.ToArray();
                var temp = _newPathFinding.NodeGridCreator(grid, tempGrid, GridScale);
                for (int g = 0; g < temp.Length; g++)
                {
                    if (!MapTotal.Any(p => p.x == temp[g].x &&
                                        p.y == temp[g].y &&
                                        p.z == temp[g].z))
                    {
                        MapTotal.Add(temp[g]);
                    }
                }
            }

            gridRelations = _gridCreate.PlaceGameObjectsAtGridPositions(mapGrid, GridParent);
            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);
            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);
            gridRelations = _chunkHandler.AssignChunkTypes(gridRelations);
            _populateTilePositionsBehavior.SetChildTile(scriptRef, gridRelations);
        }
    }
}