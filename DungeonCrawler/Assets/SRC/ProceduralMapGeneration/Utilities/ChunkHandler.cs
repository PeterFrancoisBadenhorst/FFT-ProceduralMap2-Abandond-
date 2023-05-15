using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    internal class ChunkHandler
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
                    if (grid[i].GetComponent<ChunkBehavior>())
                        comparedChunk = grid[i].GetComponent<ChunkBehavior>();
                    else
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
        /// <summary>
        /// This method finds the neighbors of the chunks in the grid.
        /// </summary>
        /// <param name="scale">The scale of the chunks.</param>
        /// <param name="grid">The list of chunks.</param>
        /// <returns>A list of chunks with their neighbors.</returns>
        /// <remarks>
        /// This method iterates over the list of chunks and finds the neighbors of each chunk. The neighbors are determined by the scale of the chunks.
        /// </remarks>
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
                // o(〒﹏〒)o
                return DirectionTypeEnum.Error;
            }
            else
                return chunk.Direction;
        }
    }
}
