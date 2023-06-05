using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    public partial class ChunkHandler
    {
        /// <summary>
        /// This method assigns chunk types to the chunks in the grid.
        /// </summary>
        /// <param name="grid">The list of chunks.</param>
        /// <returns>A list of chunks with their assigned chunk types.</returns>
        public List<GameObject> AssignChunkTypes(List<GameObject> grid)
        {
            for (int i = 0; i < grid.Count; i++)
            {
                grid[i].GetComponent<ChunkBehavior>().neighborStruct.Direction = FindChunkType(grid[i].GetComponent<ChunkBehavior>().neighborStruct);
            }
            return grid;
        }
    }
}