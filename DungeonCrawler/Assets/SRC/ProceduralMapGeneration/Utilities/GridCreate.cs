using Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Structs;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Utilities
{
    public class GridCreate
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
            var neighborPositions = GenericUtilities.NeighborsPosition(scale);
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
            return neighborStructs;
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

                GameObject h = new GameObject();
                h.AddComponent<ChunkBehavior>();
                h.GetComponent<ChunkBehavior>().direction = ids;
                gameObjects.Add(h);
            }
            return gameObjects;
        }

        public DirectionTypeEnum FindChunkType(NeighborStruct chunk)
        {
            if (chunk.Direction != DirectionTypeEnum.Collapsed || chunk.Direction == DirectionTypeEnum.Blank)
            {
                if (chunk.NorthNeighbor && !chunk.EastNeighbor && !chunk.SouthNeighbor && !chunk.WestNeighbor && !chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.N;
                if (chunk.NorthNeighbor && chunk.EastNeighbor && !chunk.SouthNeighbor && !chunk.WestNeighbor && !chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.NE;
                if (chunk.NorthNeighbor && !chunk.EastNeighbor && chunk.SouthNeighbor && !chunk.WestNeighbor && !chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.NS;
                if (chunk.NorthNeighbor && !chunk.EastNeighbor && !chunk.SouthNeighbor && chunk.WestNeighbor && !chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.NW;
                if (chunk.NorthNeighbor && !chunk.EastNeighbor && !chunk.SouthNeighbor && !chunk.WestNeighbor && chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.NT;
                if (chunk.NorthNeighbor && !chunk.EastNeighbor && !chunk.SouthNeighbor && !chunk.WestNeighbor && !chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.NB;
                if (chunk.NorthNeighbor && chunk.EastNeighbor && chunk.SouthNeighbor && !chunk.WestNeighbor && !chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.NES;
                if (chunk.NorthNeighbor && chunk.EastNeighbor && chunk.SouthNeighbor && chunk.WestNeighbor && !chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.NESW;
                if (chunk.NorthNeighbor && chunk.EastNeighbor && !chunk.SouthNeighbor && chunk.WestNeighbor && chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.NEWTB;
                if (chunk.NorthNeighbor && chunk.EastNeighbor && chunk.SouthNeighbor && chunk.WestNeighbor && chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.NESWT;
                if (!chunk.NorthNeighbor && chunk.EastNeighbor && !chunk.SouthNeighbor && chunk.WestNeighbor && chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.EWTB;
                if (chunk.NorthNeighbor && chunk.EastNeighbor && chunk.SouthNeighbor && chunk.WestNeighbor && !chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.NESWB;
                if (chunk.NorthNeighbor && chunk.EastNeighbor && chunk.SouthNeighbor && chunk.WestNeighbor && chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.NESWBT;
                if (chunk.NorthNeighbor && chunk.EastNeighbor && !chunk.SouthNeighbor && chunk.WestNeighbor && !chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.NEW;
                if (chunk.NorthNeighbor && chunk.EastNeighbor && !chunk.SouthNeighbor && chunk.WestNeighbor && chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.NEWT;
                if (chunk.NorthNeighbor && chunk.EastNeighbor && !chunk.SouthNeighbor && chunk.WestNeighbor && !chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.NEWB;
                if (chunk.NorthNeighbor && chunk.EastNeighbor && !chunk.SouthNeighbor && !chunk.WestNeighbor && chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.NET;
                if (chunk.NorthNeighbor && chunk.EastNeighbor && !chunk.SouthNeighbor && !chunk.WestNeighbor && chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.NETB;
                if (chunk.NorthNeighbor && chunk.EastNeighbor && !chunk.SouthNeighbor && !chunk.WestNeighbor && !chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.NEB;
                if (chunk.NorthNeighbor && chunk.EastNeighbor && chunk.SouthNeighbor && !chunk.WestNeighbor && chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.NEST;
                if (chunk.NorthNeighbor && chunk.EastNeighbor && chunk.SouthNeighbor && !chunk.WestNeighbor && chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.NESTB;
                if (chunk.NorthNeighbor && chunk.EastNeighbor && chunk.SouthNeighbor && !chunk.WestNeighbor && !chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.NESB;
                if (chunk.NorthNeighbor && !chunk.EastNeighbor && chunk.SouthNeighbor && chunk.WestNeighbor && !chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.NSW;
                if (chunk.NorthNeighbor && !chunk.EastNeighbor && chunk.SouthNeighbor && chunk.WestNeighbor && chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.NSWT;
                if (chunk.NorthNeighbor && !chunk.EastNeighbor && chunk.SouthNeighbor && chunk.WestNeighbor && !chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.NSWB;
                if (chunk.NorthNeighbor && !chunk.EastNeighbor && chunk.SouthNeighbor && !chunk.WestNeighbor && chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.NST;
                if (chunk.NorthNeighbor && !chunk.EastNeighbor && chunk.SouthNeighbor && !chunk.WestNeighbor && chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.NSTB;
                if (chunk.NorthNeighbor && !chunk.EastNeighbor && chunk.SouthNeighbor && !chunk.WestNeighbor && !chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.NSB;
                if (chunk.NorthNeighbor && !chunk.EastNeighbor && chunk.SouthNeighbor && chunk.WestNeighbor && chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.NSWTB;
                if (chunk.NorthNeighbor && !chunk.EastNeighbor && !chunk.SouthNeighbor && chunk.WestNeighbor && chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.NWT;
                if (chunk.NorthNeighbor && !chunk.EastNeighbor && !chunk.SouthNeighbor && chunk.WestNeighbor && chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.NWTB;
                if (chunk.NorthNeighbor && !chunk.EastNeighbor && !chunk.SouthNeighbor && chunk.WestNeighbor && !chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.NWB;
                if (chunk.NorthNeighbor && !chunk.EastNeighbor && !chunk.SouthNeighbor && !chunk.WestNeighbor && chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.NTB;
                if (!chunk.NorthNeighbor && chunk.EastNeighbor && chunk.SouthNeighbor && !chunk.WestNeighbor && !chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.ES;
                if (!chunk.NorthNeighbor && chunk.EastNeighbor && chunk.SouthNeighbor && chunk.WestNeighbor && !chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.ESW;
                if (!chunk.NorthNeighbor && chunk.EastNeighbor && chunk.SouthNeighbor && chunk.WestNeighbor && chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.ESWT;
                if (!chunk.NorthNeighbor && chunk.EastNeighbor && chunk.SouthNeighbor && chunk.WestNeighbor && !chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.ESWB;
                if (!chunk.NorthNeighbor && chunk.EastNeighbor && chunk.SouthNeighbor && chunk.WestNeighbor && chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.ESWBT;
                if (!chunk.NorthNeighbor && chunk.EastNeighbor && !chunk.SouthNeighbor && chunk.WestNeighbor && !chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.EW;
                if (!chunk.NorthNeighbor && chunk.EastNeighbor && !chunk.SouthNeighbor && chunk.WestNeighbor && chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.EWT;
                if (!chunk.NorthNeighbor && chunk.EastNeighbor && !chunk.SouthNeighbor && chunk.WestNeighbor && !chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.EWB;
                if (!chunk.NorthNeighbor && chunk.EastNeighbor && !chunk.SouthNeighbor && !chunk.WestNeighbor && chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.ET;
                if (!chunk.NorthNeighbor && chunk.EastNeighbor && !chunk.SouthNeighbor && !chunk.WestNeighbor && chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.ETB;
                if (!chunk.NorthNeighbor && chunk.EastNeighbor && !chunk.SouthNeighbor && !chunk.WestNeighbor && !chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.EB;
                if (!chunk.NorthNeighbor && chunk.EastNeighbor && chunk.SouthNeighbor && !chunk.WestNeighbor && chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.EST;
                if (!chunk.NorthNeighbor && chunk.EastNeighbor && chunk.SouthNeighbor && !chunk.WestNeighbor && chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.ESTB;
                if (!chunk.NorthNeighbor && chunk.EastNeighbor && chunk.SouthNeighbor && !chunk.WestNeighbor && !chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.ESB;
                if (!chunk.NorthNeighbor && !chunk.EastNeighbor && chunk.SouthNeighbor && chunk.WestNeighbor && !chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.SW;
                if (!chunk.NorthNeighbor && !chunk.EastNeighbor && chunk.SouthNeighbor && chunk.WestNeighbor && chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.SWT;
                if (!chunk.NorthNeighbor && !chunk.EastNeighbor && chunk.SouthNeighbor && chunk.WestNeighbor && !chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.SWB;
                if (!chunk.NorthNeighbor && !chunk.EastNeighbor && chunk.SouthNeighbor && !chunk.WestNeighbor && chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.ST;
                if (!chunk.NorthNeighbor && !chunk.EastNeighbor && chunk.SouthNeighbor && !chunk.WestNeighbor && chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.STB;
                if (!chunk.NorthNeighbor && !chunk.EastNeighbor && chunk.SouthNeighbor && !chunk.WestNeighbor && !chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.SB;
                if (!chunk.NorthNeighbor && !chunk.EastNeighbor && chunk.SouthNeighbor && chunk.WestNeighbor && chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.SWTB;
                if (!chunk.NorthNeighbor && !chunk.EastNeighbor && !chunk.SouthNeighbor && chunk.WestNeighbor && chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.WT;
                if (!chunk.NorthNeighbor && !chunk.EastNeighbor && !chunk.SouthNeighbor && chunk.WestNeighbor && chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.WTB;
                if (!chunk.NorthNeighbor && !chunk.EastNeighbor && !chunk.SouthNeighbor && chunk.WestNeighbor && !chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.WB;
                if (!chunk.NorthNeighbor && !chunk.EastNeighbor && !chunk.SouthNeighbor && !chunk.WestNeighbor && chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.TB;
                if (!chunk.NorthNeighbor && !chunk.EastNeighbor && chunk.SouthNeighbor && !chunk.WestNeighbor && !chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.S;
                if (!chunk.NorthNeighbor && chunk.EastNeighbor && !chunk.SouthNeighbor && !chunk.WestNeighbor && !chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.E;
                if (!chunk.NorthNeighbor && !chunk.EastNeighbor && chunk.SouthNeighbor && chunk.WestNeighbor && chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.SWBT;
                if (!chunk.NorthNeighbor && !chunk.EastNeighbor && !chunk.SouthNeighbor && chunk.WestNeighbor && !chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.W;
                if (!chunk.NorthNeighbor && !chunk.EastNeighbor && !chunk.SouthNeighbor && !chunk.WestNeighbor && chunk.TopNeighbor && !chunk.BottomNeighbor)
                    return DirectionTypeEnum.T;
                if (!chunk.NorthNeighbor && !chunk.EastNeighbor && !chunk.SouthNeighbor && !chunk.WestNeighbor && !chunk.TopNeighbor && chunk.BottomNeighbor)
                    return DirectionTypeEnum.B;
                // Well. . . Fuck.
                // this is a problem.
                // It should never reach this
                // ༼ つ ◕_◕ ༽つ
                return DirectionTypeEnum.Error;
            }
            else if (chunk.Direction == DirectionTypeEnum.Error)
            {
                // Well, something fucked out,
                // Somewhere. . .
                // throw exception
                return DirectionTypeEnum.Error;
            }
            else
                return DirectionTypeEnum.Collapsed;
        }
    }

}