using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding
{
    public class PathMapBuilder
    {
        private List<GameObject> gridRelations = new();

        private readonly PopulateTilePositions _populateTilePositionsBehavior = new();
        private readonly GridCreate _gridCreate = new();
        private readonly ChunkHandler _chunkHandler = new();
        private readonly NewPathFinding _newPathFinding = new();

        public void CreateMap(int GridSize, float GridScale, Transform GridParent, DirectionalTilesScriptableObject scriptRef, int MapTotalFillPercentage,GridTypeEnum gridType)
        {
                
            gridRelations.Clear();
            Vector3[] grid = _gridCreate.CreateGrid(GridSize, GridScale,gridType);
            Vector3[] mapGrid = _newPathFinding.NodeGridCreator(grid, GridScale);
            List<object> objects = new();
            List<Vector3> mapTotal = MapTotal(mapGrid);

            MapTotalFillPercentage = grid.Length / MapTotalFillPercentage;

            FillMap(mapTotal, MapTotalFillPercentage, grid, GridScale, mapGrid);

            gridRelations = _gridCreate.PlaceGameObjectsAtGridPositions(mapGrid, GridParent);
            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);
            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);
            gridRelations = _chunkHandler.AssignChunkTypes(gridRelations);
            _populateTilePositionsBehavior.SetChildTile(scriptRef, gridRelations);
        }

        public List<Vector3> MapTotal(Vector3[] mapGrid)
        {
            List<Vector3> MapTotal = new List<Vector3>();
            for (int i = 0; i < mapGrid.Length; i++)
            {
                MapTotal.Add(mapGrid[i]);
            }
            return MapTotal;
        }
        public void FillMap(List<Vector3> mapTotal, float MapTotalFillPercentage, Vector3[] grid, float GridScale, Vector3[] mapGrid)
        {
            while (mapTotal.Count < MapTotalFillPercentage)
            {
                var tempGrid = mapTotal.Count == 0 ? mapGrid : mapTotal.ToArray();
                var temp = _newPathFinding.NodeGridCreator(grid, tempGrid, GridScale);
                mapTotal.AddRange(temp.Where(p => !mapTotal.Any(q => p.x == q.x && p.y == q.y && p.z == q.z)));
            }
        }
    }
}