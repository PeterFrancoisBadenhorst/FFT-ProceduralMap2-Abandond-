using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Noise;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using System.Collections.Generic;
using System.Linq;
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
            GenerateRandomPath(map, dataKeeper);
            
            for (int i = 0; i < map.Count; i++)
            {
                map[i].name = "set tile";
            }
            return map;
        }
        public static void GenerateRandomPath(List<GameObject> map, MapBuilderStruct dataKeeper)
        {
            var random = new System.Random();
            if (!dataKeeper.previousTilePos)
                dataKeeper.previousTilePos = dataKeeper.startObject;

            var chunk = dataKeeper.previousTilePos.GetComponent<ChunkBehavior>();
            var list = new List<GameObject>();
            for (int i = 0; i < (int)(map.Count * 0.3f); i++)
            {
                if (!map.Contains(dataKeeper.previousTilePos))
                { 
                    map.Add(dataKeeper.previousTilePos);

                    if (chunk.neighborStruct.NorthNeighbor && !map.Contains(chunk.neighborStruct.NorthNeighbor))
                    {
                        list.Add(chunk.neighborStruct.NorthNeighbor);
                    }
                    if (chunk.neighborStruct.EastNeighbor && !map.Contains(chunk.neighborStruct.EastNeighbor))
                    {
                        list.Add(chunk.neighborStruct.EastNeighbor);
                    }
                    if (chunk.neighborStruct.SouthNeighbor && !map.Contains(chunk.neighborStruct.SouthNeighbor))
                    {
                        list.Add(chunk.neighborStruct.SouthNeighbor);
                    }
                    if (chunk.neighborStruct.WestNeighbor && !map.Contains(chunk.neighborStruct.WestNeighbor))
                    {
                        list.Add(chunk.neighborStruct.WestNeighbor);
                    }
                    if (chunk.neighborStruct.TopNeighbor && !map.Contains(chunk.neighborStruct.TopNeighbor))
                    {
                        list.Add(chunk.neighborStruct.TopNeighbor);
                    }
                    if (chunk.neighborStruct.BottomNeighbor && !map.Contains(chunk.neighborStruct.BottomNeighbor))
                    {
                        list.Add(chunk.neighborStruct.BottomNeighbor);
                    }

                    var index = random.Next(list.Count);
                    dataKeeper.previousTilePos = list[index];
                    list.RemoveAt(index);

                    foreach (var go in list)
                    {
                        go.SetActive(false);
                    }
                }
            }
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
            ChunkHandler ch = new ChunkHandler();
            return ch.FindChunkNeigbors(scale, grid);
        }
    }
}