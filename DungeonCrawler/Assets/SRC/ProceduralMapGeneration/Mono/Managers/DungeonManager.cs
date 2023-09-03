using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.mono;
using UnityEngine;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Modles;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Global;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Managers
{
    internal class DungeonManager : MonoBehaviour
    {
        
        public GameObject GridParent;
        public int GridSize;
        public float GridScale;
        public GridTypeEnum GridType;
        public GameObject PlayerPrefab;

        [Range(10, 75)]
        public int MapTotalFillPercentage;

        public DirectionalTilesScriptableObject scriptRef;
        private readonly PathMapBuilder _pathMapBuilder = new();


        private void Awake() => _pathMapBuilder.CreateMap(PopulateCreationModel());
        
        private ProcedualMapGenCreationModel PopulateCreationModel()
        {
            if (GlobalVariables.CreationModel == null) GlobalVariables.CreationModel = new();
            GlobalVariables.CreationModel.GridParent = GridParent;
            GlobalVariables.CreationModel.GridSize = GridSize;
            GlobalVariables.CreationModel.GridScale = GridScale;
            GlobalVariables.CreationModel.GridType = GridType;
            GlobalVariables.CreationModel.PlayerPrefab = PlayerPrefab;
            GlobalVariables.CreationModel.MapTotalFillPercentage = MapTotalFillPercentage;
            GlobalVariables.CreationModel.Rooms = scriptRef;
            return GlobalVariables.CreationModel;
        }

    }
}