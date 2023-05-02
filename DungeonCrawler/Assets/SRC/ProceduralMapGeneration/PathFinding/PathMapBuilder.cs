using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding
{
    internal class PathMapBuilder
    {
        private List<GameObject> gridRelations = new();

        private readonly PopulateTilePositions _populateTilePositionsBehavior = new();
        private readonly GridCreate _gridCreate = new();
        private readonly ChunkHandler _chunkHandler = new();
        private readonly NewPathFinding _newPathFinding = new();
        public void CreateMap(int iterations, int GridSize, float GridScale, Transform GridParent, DirectionalTilesScriptableObject scriptRef)
        {
            gridRelations.Clear();
            Vector3[] grid = _gridCreate.SquareGrid2DHorizontal(GridSize, GridScale);//
            Vector3[] mapGrid = _newPathFinding.NodeGridCreator(grid, GridScale);  // Map created here
            List<object> objects = new();
            List<Vector3> MapTotal = new List<Vector3>();
            for (int i = 0; i < mapGrid.Length; i++)
            {
                MapTotal.Add(mapGrid[i]);
            }
            Debug.Log($"Starting loop. Iterations: {iterations}");
            for (int h = 0; iterations > h; h++)
            {
                Debug.Log($"Iteration {h + 1} of {iterations}");
                List<Vector3> positions = new();
                var temp = _newPathFinding.NodeGridCreator(grid, mapGrid, GridScale);
                for (int g = 0; g < temp.Length; g++)
                {
                    positions.Add(temp[g]);
                }
                objects.Add(positions);
            }
            Debug.Log($"Loop complete. Objects count: {objects.Count}");
            mapGrid = MapTotal.Distinct().ToArray();


            gridRelations = _gridCreate.PlaceGameObjectsAtGridPositions(mapGrid, GridParent);
            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);

            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);

            gridRelations = _chunkHandler.AssignChunkTypes(gridRelations);

            _populateTilePositionsBehavior.SetChildTile(scriptRef, gridRelations);
        }


    }
}
