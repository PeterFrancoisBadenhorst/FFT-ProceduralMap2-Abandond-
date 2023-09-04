using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Global;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Assets.SRC.Shared.Utilities;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    public class ChunkHandler
    {
        /**
         * Assigns a chunk type to each GameObject in the grid.
         *
         * @param grid The list of GameObjects.
         *
         * @return The list of GameObjects.
         */
        public List<GameObject> AssignChunkTypes(List<GameObject> grid)
        {
            // Iterate through the grid.
            for (int i = 0; i < grid.Count; i++)
            {
                // Get the chunk behavior component from the current GameObject.
                var chunkBehavior = grid[i].GetComponent<ChunkBehavior>();

                // Find the chunk type for the current GameObject.
                var chunkType = FindChunkType(chunkBehavior.neighborStruct);

                // Set the chunk type on the chunk behavior component.
                chunkBehavior.neighborStruct.Direction = chunkType;
            }

            // Return the list of GameObjects.
            return grid;
        }
        /**
         * Finds the neighbors of each GameObject in the grid.
         *
         * @param scale The scale of the grid.
         * @param grid The list of GameObjects.
         *
         * @return The list of GameObjects.
         */
        public List<GameObject> FindChunkNeigbors()
        {
            // Create a dictionary to store the positions and GameObjects.
            // This dictionary will be used to quickly look up the neighbors of a GameObject.
            Dictionary<Vector3, GameObject> positions = new Dictionary<Vector3, GameObject>();
            GenericUtilities _genericUtilities = new GenericUtilities();

            // Iterate through the grid and add the positions and GameObjects to the dictionary.
            // This will create a mapping from a GameObject's position to the GameObject itself.
            for (int i = 0; i < GlobalVariables.CreationModel.GridRelations.Count; i++)
            {
                positions.Add(GlobalVariables.CreationModel.GridRelations[i].transform.position, GlobalVariables.CreationModel.GridRelations[i]);
            }

            // Iterate through the grid again.
            // For each GameObject, find its neighbors and set the neighbors on the GameObject.
            for (int i = 0; i < GlobalVariables.CreationModel.GridRelations.Count; i++)
            {
                // If the current GameObject is active.
                if (GlobalVariables.CreationModel.GridRelations[i].activeSelf)
                {
                    // Find the neighbors of the current GameObject.
                    var comparedValues = _genericUtilities.NeighborsPosition(GlobalVariables.CreationModel.GridScale, GlobalVariables.CreationModel.GridRelations[i].transform.position);
                    // Create a ChunkBehavior component for the current GameObject if it doesn't have one already.
                    ChunkBehavior comparedChunk = GlobalVariables.CreationModel.GridRelations[i].AddComponent<ChunkBehavior>();
                    // Set the neighbor struct of the ChunkBehavior component.
                    comparedChunk.neighborStruct.OriginObject = GlobalVariables.CreationModel.GridRelations[i];

                    if (positions.TryGetValue(comparedValues[0], out GameObject northNeighbor))
                    {
                        // Set the neighbor at the specified index.
                        comparedChunk.neighborStruct.NorthNeighbor = northNeighbor;
                    }
                    if (positions.TryGetValue(comparedValues[1], out GameObject eastNeighbor))
                    {
                        // Set the neighbor at the specified index.
                        comparedChunk.neighborStruct.EastNeighbor = eastNeighbor;
                    }
                    if (positions.TryGetValue(comparedValues[2], out GameObject southNeighbor))
                    {
                        // Set the neighbor at the specified index.
                        comparedChunk.neighborStruct.SouthNeighbor = southNeighbor;
                    }
                    if (positions.TryGetValue(comparedValues[3], out GameObject westNeighbor))
                    {
                        // Set the neighbor at the specified index.
                        comparedChunk.neighborStruct.WestNeighbor = westNeighbor;
                    }
                    if (positions.TryGetValue(comparedValues[4], out GameObject topNeighbor))
                    {
                        // Set the neighbor at the specified index.
                        comparedChunk.neighborStruct.TopNeighbor = topNeighbor;
                    }
                    if (positions.TryGetValue(comparedValues[5], out GameObject bottomNeighbor))
                    {
                        // Set the neighbor at the specified index.
                        comparedChunk.neighborStruct.BottomNeighbor = bottomNeighbor;
                    }
                    // Set the neighbor struct of the current GameObject.
                    GlobalVariables.CreationModel.GridRelations[i].GetComponent<ChunkBehavior>().neighborStruct = comparedChunk.neighborStruct;
                }
            }
            return GlobalVariables.CreationModel.GridRelations;
        }
        /**
          * Finds the neighbors of each GameObject in the grid.
          *
          * This function iterates through the list of GameObjects in the grid and finds
          * the neighbors of each GameObject. The neighbors are the GameObjects that
          * are directly adjacent to the GameObject.
          *
          * @param scale The scale of the grid.
          * @param grid The list of GameObjects.
          *
          * @return The list of GameObjects.
          */
        public DirectionTypeEnum FindChunkType(NeighborStruct chunk)
        {
            // This function finds the type of a chunk based on its neighbors.

            // Check if the chunk is in an error state.
            if (chunk.Direction == DirectionTypeEnum.Error)
            {
                // Throw an exception.
                throw new ArgumentException("System Erroed out : Chunk Handler > Find Chunk Type");
                // Well, something really fucked out,
                // Somewhere. . .
                // (((φ(◎ロ◎;)φ)))
                // I Should probably put some kind of exception here.
                // But then it would make this exceptional.
                // o(〒﹏〒)o
            }

            // Check if the chunk is collapsed or blank.
            else if (chunk.Direction != DirectionTypeEnum.Collapsed && chunk.Direction != DirectionTypeEnum.Blank)
            {
                // Initialize a string to store the chunk's neighbors.
                string result = "";

                // Add each neighbor to the string.
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

                // Convert the string to a `DirectionTypeEnum` and return it.
                return (DirectionTypeEnum)Enum.Parse(typeof(DirectionTypeEnum), result);
            }

            // The chunk is collapsed or blank, so just return its current direction.
            else
                return chunk.Direction;
        }
    }
}