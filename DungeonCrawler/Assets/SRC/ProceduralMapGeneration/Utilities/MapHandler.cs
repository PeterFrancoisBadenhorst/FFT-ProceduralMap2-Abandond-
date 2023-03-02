using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Noise;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    internal class MapHandler
    {
        public List<GameObject> CreateMapPatern(List<GameObject> grid)
        {
            var random = new System.Random();
            List<GameObject> map = new List<GameObject>();
            MapBuilderStruct dataKeeper = new MapBuilderStruct();
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
            ChunkHandler ch=new ChunkHandler();
            return ch.FindChunkNeigbors(scale, grid);
        }
    }
}
