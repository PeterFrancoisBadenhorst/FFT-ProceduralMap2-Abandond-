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
        public void CreateMap(int GridSize, float GridScale, Transform GridParent, DirectionalTilesScriptableObject scriptRef)
        {
            gridRelations.Clear();
            Vector3[] grid = _gridCreate.SquareGrid2DHorizontal(GridSize, GridScale);//
            Vector3[] mapGrid = _newPathFinding.NodeGridCreator(grid, GridScale);  // Map created here
            gridRelations = _gridCreate.PlaceGameObjectsAtGridPositions(mapGrid, GridParent);
            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);

            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);
            // gridRelations = _gridCreate.AssignDirectionIDAccordingToPresentNeighbors(listedObjects);
            gridRelations = _chunkHandler.AssignChunkTypes(gridRelations);

            _populateTilePositionsBehavior.SetChildTile(scriptRef, gridRelations);
        }


    }
}
