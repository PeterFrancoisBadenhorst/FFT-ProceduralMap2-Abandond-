using UnityEngine;
using Assets.Code.ProceduleDungeon.Utilities;
using Unity.VisualScripting;
using System.Collections.Generic;
using Assets.Code.ProceduleDungeon.Mono.Behaviors;
using Assets.Code.ProceduleDungeon.Structs;

namespace Assets.Code.ProceduleDungeon.Mono.Managers
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
