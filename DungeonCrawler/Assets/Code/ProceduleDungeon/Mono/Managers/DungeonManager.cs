using UnityEngine;
using Assets.Code.ProceduleDungeon.Utilities;
using Unity.VisualScripting;
using System.Collections.Generic;
using Assets.Code.ProceduleDungeon.Mono.Behaviors;

namespace Assets.Code.ProceduleDungeon.Mono.Managers
{
    internal class DungeonManager : MonoBehaviour
    {
        public GameObject TempPrefab;
        public Transform GridParent;
        public int GridSize;
        public float GridScale;

        private readonly List<GameObject> chunkPositions = new List<GameObject>();

        private void Start()
        {
            SetUpGrid();
        }
        private void SetUpGrid()
        {
            var grid = GridCreate.SquareGrid2DHorizontal(GridSize, GridScale);
            for (int i = 0; i < grid.Length; i++)
            {
                var t = Instantiate(TempPrefab, grid[i], Quaternion.identity, GridParent);
                chunkPositions.Add(t);
            }
            
        }
        private void FindChunkNeigbors()
        {
            for (int i = 0; i < chunkPositions.Count; i++)
            {
                chunkPositions[i].GetComponent<ChunkBehavior>().FindNeigbors(chunkPositions, i);
            }
        }
    }
}
