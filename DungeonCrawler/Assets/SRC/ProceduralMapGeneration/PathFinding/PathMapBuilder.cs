﻿using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
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
        public void CreateMap(int GridSize, float GridScale, Transform GridParent, DirectionalTilesScriptableObject scriptRef, int MapTotalFillPercentage)
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
            Debug.Log($"Starting loop.");
            int loopCount = 0;
            while (MapTotal.Count < MapTotalFillPercentage)
            {
                loopCount++;
                Debug.Log($"Iteration {loopCount} as {MapTotal.Count} is less than {MapTotalFillPercentage}");
                var tempGrid = (MapTotal.Count == 0) ? mapGrid : MapTotal.ToArray();
                var temp = _newPathFinding.NodeGridCreator(grid, tempGrid, GridScale);
                for (int g = 0; g < temp.Length; g++)
                {
                    MapTotal.Add(temp[g]);
                }
                MapTotal = MapTotal.Distinct().ToList();
            }
            mapGrid = MapTotal.Distinct().ToArray();


            gridRelations = _gridCreate.PlaceGameObjectsAtGridPositions(mapGrid, GridParent);
            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);

            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);

            gridRelations = _chunkHandler.AssignChunkTypes(gridRelations);

            _populateTilePositionsBehavior.SetChildTile(scriptRef, gridRelations);
        }


    }
}
