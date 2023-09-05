using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using UnityEngine;

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

        private void OnEnable() => _pathMapBuilder.CreateMap(GridSize, GridScale, GridParent.transform, scriptRef, MapTotalFillPercentage, GridType);

    }
}