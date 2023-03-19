
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

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Managers
{
    internal class DungeonManager : MonoBehaviour
    {
        public GameObject TempPrefab;
        public Transform GridParent;
        public int GridSize;
        public float GridScale;
        [Range(0,100)]
        public float Threshold;
        public DirectionalTilesScriptableObject scriptRef;

        private List<GameObject> gridRelations = new List<GameObject>();

        private readonly System.Random random = new System.Random();
        private readonly PopulateTilePositions _populateTilePositionsBehavior = new PopulateTilePositions();
        private readonly GridCreate _gridCreate = new GridCreate();
        private readonly MapHandler _mapHandler = new MapHandler();
        private readonly ChunkHandler _chunkHandler= new ChunkHandler();
        private readonly PathFinding _pathFinding = new PathFinding();
        private void Start()
        {
            SetUpGrid();
        }
        private void SetUpGrid()
        {
            gridRelations.Clear();
            Vector3[] grid = _gridCreate.SquareGrid2DHorizontal(GridSize, GridScale);//
            var startPos = grid[random.Next(0, grid.Length)];
            Vector3[] mapGrid = _pathFinding.PathPositions(grid, grid[random.Next(0, grid.Length)], grid[random.Next(0, grid.Length)], GridScale);// this is returning nothing, assumpton is neighbors arnt being set
            Debug.LogError(mapGrid.Length);
             gridRelations = _gridCreate.PlaceGameObjectsAtGridPositions(mapGrid, GridParent);
            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);

            gridRelations = _chunkHandler.FindChunkNeigbors(GridScale, gridRelations);
            // gridRelations = _gridCreate.AssignDirectionIDAccordingToPresentNeighbors(listedObjects);
            gridRelations = _chunkHandler.AssignChunkTypes(gridRelations);

            _populateTilePositionsBehavior.SetChildTile(scriptRef, gridRelations);
        }

    }
}
