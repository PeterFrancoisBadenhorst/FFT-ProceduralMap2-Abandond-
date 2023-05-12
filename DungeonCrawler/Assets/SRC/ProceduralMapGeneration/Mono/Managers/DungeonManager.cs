using UnityEngine;

namespace PathFinding
{
    public class DungeonManager : MonoBehaviour
    {
        public GameObject TempPrefab;
        public Transform GridParent;
        public int GridSize;
        public float GridScale;
        public int Iterations;

        public DirectionalTilesScriptableObject scriptRef;

        private PathMapBuilder _pathMapBuilder;

        private void Start()
        {
            _pathMapBuilder = new PathMapBuilder();
            _pathMapBuilder.CreateMap(Iterations, GridSize, GridScale, this.transform, scriptRef);
        }

    }
}
