using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using System;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    public class FindChunkDirection
    {
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
                // (((?(???;)?)))
                // I Should probably put some kind of exception here.
                // But then it would make this exceptional.
                // o(???)o
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