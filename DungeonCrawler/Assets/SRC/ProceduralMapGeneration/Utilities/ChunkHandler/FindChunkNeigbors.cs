using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    public partial class ChunkHandler
    {
        /// <summary>
        /// This method finds the neighbors of the chunks in the grid.
        /// </summary>
        /// <param name="scale">The scale of the chunks.</param>
        /// <param name="grid">The list of chunks.</param>
        /// <returns>A list of chunks with their neighbors.</returns>
        public List<GameObject> FindChunkNeigbors(float scale, List<GameObject> grid)
        {
            Dictionary<Vector3, GameObject> positions = new Dictionary<Vector3, GameObject>();
            GenericUtilities _genericUtilities = new GenericUtilities();

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
                    comparedChunk = grid[i].AddComponent<ChunkBehavior>();

                    comparedChunk.neighborStruct.OriginObject = grid[i];

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

       
    }
}