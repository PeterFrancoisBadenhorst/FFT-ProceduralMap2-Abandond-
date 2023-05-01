﻿
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Noise;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Managers;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Managers
{
    internal class DungeonManager : MonoBehaviour
    {
        public GameObject TempPrefab;
        public Transform GridParent;
        public int GridSize;
        public float GridScale;
        public int MinTiles;
        [Range(0, 100)]
        public float Threshold;
        public DirectionalTilesScriptableObject scriptRef;

        private List<GameObject> gridRelations = new();
        private bool overMinTiles = false;
        private int maxTileOverAttempts = 5;

        private readonly System.Random random = new();
        private readonly PopulateTilePositions _populateTilePositionsBehavior = new();
        private readonly GridCreate _gridCreate = new();
        private readonly MapHandler _mapHandler = new();
        private readonly ChunkHandler _chunkHandler = new();
        private readonly PathFinding _pathFinding = new();
        private readonly NewPathFinding _newPathFinding = new();

        private readonly PathMapBuilder _pathMapBuilder = new();
        private void Start()
        {
            // SetUpGrid();
            _pathMapBuilder.CreateMap(GridSize, GridScale, this.transform, scriptRef);
        }
        private void SetUpGrid()
        {
            gridRelations.Clear();
            Vector3[] grid = _gridCreate.SquareGrid2DHorizontal(GridSize, GridScale);//
            Vector3[] mapGrid = _newPathFinding.NodeGridCreator(grid, GridScale);  // Map created here
            while (overMinTiles)
            {
                --maxTileOverAttempts;
                Vector3[] temp = _newPathFinding.NodeGridCreator(grid, GridScale);
                if (maxTileOverAttempts >= 0)
                {
                    if (temp.Length >= MinTiles)
                    {
                        mapGrid = temp;
                        overMinTiles = true;
                    }
                }
                else
                {
                    Debug.LogWarning("Min tile Could not be overcome.");
                    mapGrid = temp;
                }
            }
            gridRelations = _gridCreate.PlaceGameObjectsAtGridPositions(mapGrid, GridParent);
            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);

            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);
            // gridRelations = _gridCreate.AssignDirectionIDAccordingToPresentNeighbors(listedObjects);
            gridRelations = _chunkHandler.AssignChunkTypes(gridRelations);

            _populateTilePositionsBehavior.SetChildTile(scriptRef, gridRelations);
        }

    }
}
