using Assets.Code.ProceduleDungeon.Mono.Behaviors;
using Assets.Code.ProceduleDungeon.Structs;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Code.ProceduleDungeon.Utilities
{
    internal class GridCreate
    {
        public static Vector3[] SquareGrid2DVertical(int gridSize, float scale)
        {
            var createdTransforms = new List<Vector3>();
            for (int X = 0; X < gridSize; X++)
            {
                for (int Y = 0; Y < gridSize; Y++)
                {
                    var t = new Vector3(
                        (X - gridSize / 2) * scale,
                        (Y - gridSize / 2) * scale,
                        0);
                    createdTransforms.Add(t);
                }
            }
            return createdTransforms.ToArray();
        }
        public static Vector3[] SquareGrid2DHorizontal(int gridSize, float scale)
        {
            var createdTransforms = new List<Vector3>();
            for (int X = 0; X < gridSize; X++)
            {
                for (int Y = 0; Y < gridSize; Y++)
                {
                    var t = new Vector3(
                        (X - gridSize / 2) * scale,
                        0,
                       (Y - gridSize / 2) * scale);
                    createdTransforms.Add(t);
                }
            }
            return createdTransforms.ToArray();
        }
        public static Vector3[] SquareGrid3D(int gridSize, float scale)
        {
            var createdTransforms = new List<Vector3>();
            for (int X = 0; X < gridSize; X++)
            {
                for (int Y = 0; Y < gridSize; Y++)
                {
                    for (int Z = 0; Z < gridSize; Z++)
                    {
                        var t = new Vector3(
                             (X - gridSize / 2) * scale,
                             (Y - gridSize / 2) * scale,
                             (Z - gridSize / 2) * scale);
                        createdTransforms.Add(t);
                    }
                }
            }
            return createdTransforms.ToArray();
        }

        public static List<NeighborStruct> FindChunkNeigbors(float scale, List<GameObject> grid)
        {
            List<NeighborStruct> neighborStructs = new List<NeighborStruct>();
            var neighborPositions = Generic.NeighborsPosition(scale);
            for (int i = 0; i < grid.Count; i++)
            {
                var neighbors = new NeighborStruct();
                neighbors.OriginObject = grid[i];
                var pos = grid[i].transform.position;
                for (int g = 0; g < grid.Count; g++)
                {
                    var compared = grid[g].transform.position;

                    if (compared.x == pos.x + neighborPositions[0].x) neighbors.NorthNeighbor = grid[g];

                    else if (compared.y == pos.y + neighborPositions[1].y) neighbors.EastNeighbor = grid[g];

                    else if (compared.x == pos.x + neighborPositions[2].x) neighbors.SouthNeighbor = grid[g];

                    else if (compared.y == pos.y + neighborPositions[3].y) neighbors.WestNeighbor = grid[g];

                    else if (compared.z == pos.z + neighborPositions[4].z) neighbors.TopNeighbor = grid[g];

                    else if (compared.z == pos.z + neighborPositions[5].z) neighbors.BottomNeighbor = grid[g];

                }
                neighborStructs.Add(neighbors);
            }
            return  neighborStructs;
        }
        public static List<GameObject> PlaceGameObjectsAtGridPositions(Vector3[] grid, Transform gridParent)
        {
            List<GameObject> gameObjects = new List<GameObject>();
            for (int i = 0; i < grid.Length; i++)
            {
                var g = new GameObject();
                g.transform.position = grid[i];
                g.transform.parent = gridParent;
                gameObjects.Add(g);
            }
            return gameObjects;
        }

        public static List<GameObject> AssignDirectionIDAccordingToPresentNeighbors(List<NeighborStruct> objects)
        {
            List<GameObject> gameObjects = new List<GameObject>();
            for (int i = 0; i < objects.Count; i++)
            {
                DirectionIDStruct ids = new DirectionIDStruct();
                NeighborStruct t = objects[i];
                if (t.NorthNeighbor) ids.NothID = true;
                if (t.EastNeighbor) ids.EastID = true;
                if (t.SouthNeighbor) ids.SouthID = true;
                if (t.WestNeighbor) ids.WestID = true;
                if (t.TopNeighbor) ids.TopID = true;
                if (t.BottomNeighbor) ids.BottomID = true;

                GameObject h=new GameObject();
                h.AddComponent<ChunkBehavior>();
                h.GetComponent<ChunkBehavior>().direction=ids;
                gameObjects.Add(h);
            }
            return gameObjects;
        }
    }
}
