using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Modles
{
    public class ProcedualMapGenCreationModel
    {
        public GameObject GridParent;
        public GameObject PlayerPrefab;
        public int GridSize;
        public int MapTotalFillPercentage;
        public float GridScale;
        public GridTypeEnum GridType;
        public DirectionalTilesScriptableObject Rooms;

        public Vector3[] Grid;
        public Vector3[] MapGrid;
        public List<Vector3> MapTotal;
        public List<Vector3> WorkingMapPath;
        public List<Vector3> CreatedGridTransforms;
        public List<GameObject> GridRelations;
        public List<GameObject> GridGa;
        public Vector3[] WorkingEnds;
        public List<NewNodeModel> Nodes = new();

        public readonly PopulateTilePositions _populateTilePositionsBehavior = new();
        public readonly GridCreate _gridCreate = new();
        public readonly ChunkHandler _chunkHandler = new();
        public readonly NewPathFinding _newPathFinding = new();
    }
}
