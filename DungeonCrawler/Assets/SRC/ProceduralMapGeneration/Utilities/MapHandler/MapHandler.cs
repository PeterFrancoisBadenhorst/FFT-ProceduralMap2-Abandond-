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
        /// <summary>
        /// Creates a map pattern from the specified grid.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <returns>A list of game objects that contains the created map pattern.</returns>
        /// <remarks>
        /// The method creates a new System.Random object and then uses it to choose a random index from the grid. The start tile is then set to the game object at the specified index. The method then iterates through the grid and adds tiles to the map pattern until the desired number of tiles have been added. The method sets the name of each tile in the map pattern to "set tile".
        /// </remarks>
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
        /// <summary>
        /// Creates a path from the specified grid.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="size">The size.</param>
        /// <param name="threshold">The threshold.</param>
        /// <returns>A list of Vector3 that contains the created path.</returns>
        /// <remarks>
        /// The method creates a new PerlinNoiseGenerator object and then uses it to generate a Perlin noise texture of the specified size and scale. The method then iterates through the grid and adds positions to the path that have a noise value greater than the threshold. The method returns a list of Vector3 that contains the created path.
        /// </remarks>
        public Vector3[] CreatePath(Vector3[] grid, float scale, int size, float threshold)
        {
            // To Do :
            // need to refactor this
            // this needs to remove random positions
            // then iterate through the positions to ensure that each positions is a valid position
            // then calculate if there are any islands and remove them
            // then compare to a set size that is we set it to 50% that we need 75% of that 50% in the main island
            // we can also increase the map size after this section
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
        /// <summary>
        /// Cleans a map.
        /// </summary>
        /// <param name="scale">The scale.</param>
        /// <param name="grid">The grid.</param>
        /// <returns>A list of GameObject that contains the cleaned map.</returns>
        /// <remarks>
        /// The method iterates through the grid and sets the active state of each game object to false if its transform name is "Created". The method then creates a new ChunkHandler object and then uses it to find the neighbors of each chunk in the grid. The method returns a list of GameObject that contains the cleaned map.
        /// </remarks>
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
