using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Managers
{
    internal class DungeonManager : MonoBehaviour
    {
        public GameObject TempPrefab;
        public Transform GridParent;
        public int GridSize;
        public float GridScale;

        [Range(10, 75)]
        public int MapTotalFillPercentage;

        public DirectionalTilesScriptableObject scriptRef;

        private readonly PathMapBuilder _pathMapBuilder = new();

        private void Start()
        {
            _pathMapBuilder.CreateMap(GridSize, GridScale, this.transform, scriptRef, MapTotalFillPercentage);
        }
    }
}