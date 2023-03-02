using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Noise;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Managers;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using System.Linq;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    public class GridCreate
    {
        #region Grids
        public Vector3[] SquareGrid2DVertical(int gridSize, float scale)
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

        public Vector3[] SquareGrid2DHorizontal(int gridSize, float scale)
        {
            var createdTransforms = new List<Vector3>();
            var centre = gridSize / 2;
            for (int X = 0; X < gridSize; X++)
            {
                for (int Y = 0; Y < gridSize; Y++)
                {
                    var t = new Vector3(
                        (X - centre) * scale,
                        0,
                       (Y - centre) * scale
                       );
                    createdTransforms.Add(t);
                }
            }
            return createdTransforms.ToArray();
        }

        public Vector3[] SquareGrid3D(int gridSize, float scale)
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
        #endregion

        public List<GameObject> FindChunkNeigbors(float scale, List<GameObject> grid)
        {
            Dictionary<Vector3, GameObject> positions = new Dictionary<Vector3, GameObject>();
            GenericUtilities _genericUtilities = new GenericUtilities();

            // Fill the dictionary with the positions and corresponding objects from the grid list
            for (int i = 0; i < grid.Count; i++)
            {
                positions.Add(grid[i].transform.position, grid[i]);
            }

            for (int i = 0; i < grid.Count; i++)
            {
                if (grid[i].activeSelf)
                {

                    var comparedValues = _genericUtilities.NeighborsPosition(scale, grid[i].transform.position);
                    ChunkBehavior comparedChunk;
                    if (grid[i].GetComponent<ChunkBehavior>())
                        comparedChunk = grid[i].GetComponent<ChunkBehavior>();
                    else
                        comparedChunk = grid[i].AddComponent<ChunkBehavior>();
                    comparedChunk.neighborStruct.OriginObject = grid[i];

                    // Look up the neighbors in the dictionary instead of iterating through the entire list
                    if (positions.TryGetValue(comparedValues[0], out GameObject northNeighbor))
                    {
                        comparedChunk.neighborStruct.NorthNeighbor = northNeighbor;
                    }
                    if (positions.TryGetValue(comparedValues[1], out GameObject eastNeighbor))
                    {
                        comparedChunk.neighborStruct.EastNeighbor = eastNeighbor;
                    }
                    if (positions.TryGetValue(comparedValues[2], out GameObject southNeighbor))
                    {
                        comparedChunk.neighborStruct.SouthNeighbor = southNeighbor;
                    }
                    if (positions.TryGetValue(comparedValues[3], out GameObject westNeighbor))
                    {
                        comparedChunk.neighborStruct.WestNeighbor = westNeighbor;
                    }
                    if (positions.TryGetValue(comparedValues[4], out GameObject topNeighbor))
                    {
                        comparedChunk.neighborStruct.TopNeighbor = topNeighbor;
                    }
                    if (positions.TryGetValue(comparedValues[5], out GameObject bottomNeighbor))
                    {
                        comparedChunk.neighborStruct.BottomNeighbor = bottomNeighbor;
                    }

                    grid[i].GetComponent<ChunkBehavior>().neighborStruct = comparedChunk.neighborStruct;
                }
            }
            return grid;
        }

        public List<GameObject> PlaceGameObjectsAtGridPositions(Vector3[] grid, Transform gridParent)//
        {
            List<GameObject> gameObjects = new List<GameObject>(grid.Length);
            for (int i = 0; i < grid.Length; i++)
            {
                var g = new GameObject("Created");
                g.transform.position = grid[i];
                g.transform.parent = gridParent;
                gameObjects.Add(g);
            }
            return gameObjects;
        }

        public List<GameObject> AssignChunkTypes(List<GameObject> grid)
        {
            for (int i = 0; i < grid.Count; i++)
            {
                grid[i].GetComponent<ChunkBehavior>().neighborStruct.Direction = FindChunkType(grid[i].GetComponent<ChunkBehavior>().neighborStruct);
            }
            return grid;
        }

        public List<GameObject> CreateMapPatern(List<GameObject> grid)
        {
            var random = new System.Random();
            List<GameObject> map = new List<GameObject>();
            MapBuilderHelperStruct dataKeeper = new MapBuilderHelperStruct();
            dataKeeper.startObject = grid[random.Next(grid.Count)];
            if (!dataKeeper.previousTilePos)
                dataKeeper.previousTilePos = dataKeeper.startObject;
            for (int i = 0; i < (int)(grid.Count * 0.3f); i++)
            {
                if (!map.Contains(grid[i]))
                {
                    var t = dataKeeper.previousTilePos.GetComponent<ChunkBehavior>();
                    List<GameObject> list = new List<GameObject>();

                    map.Add(dataKeeper.previousTilePos);
                    if (t.neighborStruct.NorthNeighbor && !map.Contains(t.neighborStruct.NorthNeighbor))
                        list.Add(t.neighborStruct.NorthNeighbor);
                    if (t.neighborStruct.EastNeighbor && !map.Contains(t.neighborStruct.EastNeighbor))
                        list.Add(t.neighborStruct.EastNeighbor);
                    if (t.neighborStruct.SouthNeighbor && !map.Contains(t.neighborStruct.SouthNeighbor))
                        list.Add(t.neighborStruct.SouthNeighbor);
                    if (t.neighborStruct.WestNeighbor && !map.Contains(t.neighborStruct.WestNeighbor))
                        list.Add(t.neighborStruct.WestNeighbor);
                    if (t.neighborStruct.TopNeighbor && !map.Contains(t.neighborStruct.TopNeighbor))
                        list.Add(t.neighborStruct.TopNeighbor);
                    if (t.neighborStruct.BottomNeighbor && !map.Contains(t.neighborStruct.BottomNeighbor))
                        list.Add(t.neighborStruct.BottomNeighbor);
                    var f = random.Next(list.Count);
                    dataKeeper.previousTilePos = list[f];
                    list.RemoveAt(f);
                    for (int r = 0; r < list.Count; r++)
                    {
                        list[r].SetActive(false);
                    }
                }
            }
            for (int i = 0; i < map.Count; i++)
            {
                map[i].name = "set tile";
            }
            return map;
        }

        public Vector3[] CreatePath(Vector3[] grid, float scale, int size, float threshold)
        {
            /// need to re factor this
            /// this needs to remove random positions
            /// then iterate through the positions to ensure that each positions is a valid position
            /// then calculate if there are any islands and remove them
            /// then compare to a set size that is we set it to 50% that we need 75% of that 50% in the main island
            /// we can also increase the map size after this section
            var _perlinNoiseGenerator = new PerlinNoiseGenerator();
            var nm = _perlinNoiseGenerator.GeneratePerlinNoise2DTexture(size, scale);
            List<Vector3> path = new List<Vector3>();
            for (int i = 0; i < grid.Count(); i++)
            {
                Color t = nm.GetPixel((int)(grid[i].x / scale), (int)(grid[i].x / scale));
                float g = (t.r + t.g + t.b) / 3;
                if (g > 0.3f)
                {
                    path.Add(grid[i]);
               }
            }


            return path.ToArray();
        }

        public List<GameObject> CleanMap(int scale, List<GameObject> grid)
        {
            for (int i = 0; i < grid.Count; i++)
            {
                if (grid[i].transform.name == "Created")
                {
                    grid[i].SetActive(false);
                }
            }

            return FindChunkNeigbors(scale, grid);
            return grid;
        }

        public DirectionTypeEnum FindChunkType(NeighborStruct chunk)
        {
            if (chunk.Direction != DirectionTypeEnum.Collapsed || chunk.Direction == DirectionTypeEnum.Blank)
            {
                string result = "";

                if (chunk.NorthNeighbor)
                    result += "N";

                if (chunk.EastNeighbor)
                    result += "E";

                if (chunk.SouthNeighbor)
                    result += "S";

                if (chunk.WestNeighbor)
                    result += "W";

                if (chunk.TopNeighbor)
                    result += "T";

                if (chunk.BottomNeighbor)
                    result += "B";

                return (DirectionTypeEnum)Enum.Parse(typeof(DirectionTypeEnum), result);

            }
            else if (chunk.Direction == DirectionTypeEnum.Error)
            {
                // Well, something really fucked out,
                // Somewhere. . .
                // (((φ(◎ロ◎;)φ)))
                // I Should probably put some kind of exception here.
                // But then it would make this exceptional.
                return DirectionTypeEnum.Error;
            }
            else
                return chunk.Direction;
            // Just like my dreams of getting a paid 6 month vacation twice a year.
            // o(〒﹏〒)o
        }
    }

}