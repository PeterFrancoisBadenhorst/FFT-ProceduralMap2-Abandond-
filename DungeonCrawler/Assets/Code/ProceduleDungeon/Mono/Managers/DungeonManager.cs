using UnityEngine;
using Assets.Code.ProceduleDungeon.Utilities;
using Unity.VisualScripting;

namespace Assets.Code.ProceduleDungeon.Mono.Managers
{
    internal class DungeonManager : MonoBehaviour
    {
        public GameObject TempPrefab;
        public Transform GridParent;
        public int GridSize;
        public float GridScale;


        private void Start()
        {
           /// if (GridParent == null) this.transform = GridParent;
           var grid = GridCreate.SquareGrid2DHorizontal(GridSize, GridScale);
            for (int i = 0; i < grid.Length; i++)
            {
              var t =  Instantiate(TempPrefab, grid[i],Quaternion.identity);
                t.transform.SetParent(GridParent);
            }
        }


    }
}
