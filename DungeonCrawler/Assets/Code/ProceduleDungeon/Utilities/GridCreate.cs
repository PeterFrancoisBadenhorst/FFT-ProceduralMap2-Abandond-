using Assets.Code.ProceduleDungeon.Mono.Behaviors;
using Assets.Code.ProceduleDungeon.Structs;
using System.Collections.Generic;
using Assets.Code.ProceduleDungeon.Enums;
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

        public NeighborStruct FindChunkType(NeighborStruct chunk)
        {
            return new NeighborStruct();
            switch (chunk.Direction)
            {
                /// this needs to change to an if statement
                case DirectionTypeEnum.N:
                    break;
                case DirectionTypeEnum.NE:
                    break;
                case DirectionTypeEnum.NS:
                    break;
                case DirectionTypeEnum.NW:
                    break;
                case DirectionTypeEnum.NT:
                    break;
                case DirectionTypeEnum.NB:
                    break;
                case DirectionTypeEnum.NES:
                    break;
                case DirectionTypeEnum.NESW:
                    break;
                case DirectionTypeEnum.NESWT:
                    break;
                case DirectionTypeEnum.NESWB:
                    break;
                case DirectionTypeEnum.NESWBT:
                    break;
                case DirectionTypeEnum.NEW:
                    break;
                case DirectionTypeEnum.NEWT:
                    break;
                case DirectionTypeEnum.NEWB:
                    break;
                case DirectionTypeEnum.NET:
                    break;
                case DirectionTypeEnum.NETB:
                    break;
                case DirectionTypeEnum.NEB:
                    break;
                case DirectionTypeEnum.NEST:
                    break;
                case DirectionTypeEnum.NESTB:
                    break;
                case DirectionTypeEnum.NESB:
                    break;
                case DirectionTypeEnum.NSW:
                    break;
                case DirectionTypeEnum.NSWT:
                    break;
                case DirectionTypeEnum.NSWB:
                    break;
                case DirectionTypeEnum.NST:
                    break;
                case DirectionTypeEnum.NSTB:
                    break;
                case DirectionTypeEnum.NSB:
                    break;
                case DirectionTypeEnum.NSWTB:
                    break;
                case DirectionTypeEnum.NWT:
                    break;
                case DirectionTypeEnum.NWTB:
                    break;
                case DirectionTypeEnum.NWB:
                    break;
                case DirectionTypeEnum.NTB:
                    break;
                case DirectionTypeEnum.ES:
                    break;
                case DirectionTypeEnum.ESW:
                    break;
                case DirectionTypeEnum.ESWT:
                    break;
                case DirectionTypeEnum.ESWB:
                    break;
                case DirectionTypeEnum.ESWBT:
                    break;
                case DirectionTypeEnum.EW:
                    break;
                case DirectionTypeEnum.EWT:
                    break;
                case DirectionTypeEnum.EWB:
                    break;
                case DirectionTypeEnum.ET:
                    break;
                case DirectionTypeEnum.ETB:
                    break;
                case DirectionTypeEnum.EB:
                    break;
                case DirectionTypeEnum.EST:
                    break;
                case DirectionTypeEnum.ESTB:
                    break;
                case DirectionTypeEnum.ESB:
                    break;
                case DirectionTypeEnum.SW:
                    break;
                case DirectionTypeEnum.SWT:
                    break;
                case DirectionTypeEnum.SWB:
                    break;
                case DirectionTypeEnum.ST:
                    break;
                case DirectionTypeEnum.STB:
                    break;
                case DirectionTypeEnum.SB:
                    break;
                case DirectionTypeEnum.SWTB:
                    break;
                case DirectionTypeEnum.WT:
                    break;
                case DirectionTypeEnum.WTB:
                    break;
                case DirectionTypeEnum.WB:
                    break;
                case DirectionTypeEnum.TB:
                    break;
                case DirectionTypeEnum.S:
                    break;
                case DirectionTypeEnum.SWBT:
                    break;
                case DirectionTypeEnum.W:
                    break;
                case DirectionTypeEnum.T:
                    break;
            }
        }
    }
}