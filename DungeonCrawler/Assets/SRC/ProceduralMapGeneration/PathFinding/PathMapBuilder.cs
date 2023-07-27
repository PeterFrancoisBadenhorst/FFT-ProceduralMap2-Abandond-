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

        public void CreateMap(int GridSize, float GridScale, Transform GridParent, DirectionalTilesScriptableObject scriptRef, int MapTotalFillPercentage, GridTypeEnum gridType)
        {
            gridRelations.Clear();
            Vector3[] grid = _gridCreate.CreateGrid(GridSize, GridScale, gridType);
            Vector3[] mapGrid = _newPathFinding.NodeGridCreator(grid, GridScale);
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
            List<Vector3> MapTotal = new();
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