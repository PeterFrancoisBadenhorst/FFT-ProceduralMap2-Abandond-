using Assets.SRC.ProceduralMapGeneration.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Mono.Managers
{
    internal class DungeonManager : MonoBehaviour
    {
        public GameObject TempPrefab;
        public Transform GridParent;
        public int GridSize;
        public float GridScale;

        private List<GameObject> gridRelations = new List<GameObject>();

        private void Start()
        {
            SetUpGrid();
        }
        private void SetUpGrid()
        {
            gridRelations = GridCreate.AssignDirectionIDAccordingToPresentNeighbors(GridCreate.FindChunkNeigbors(GridScale, GridCreate.PlaceGameObjectsAtGridPositions(GridCreate.SquareGrid2DHorizontal(GridSize, GridScale), GridParent)));
        }

    }
}
