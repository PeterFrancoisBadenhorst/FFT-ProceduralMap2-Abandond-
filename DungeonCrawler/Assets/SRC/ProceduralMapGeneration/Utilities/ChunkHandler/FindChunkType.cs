using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using System;

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
        /// <remarks>
        /// This method iterates over the list of chunks and finds the neighbors of each chunk. The neighbors are determined by the scale of the chunks.
        /// </remarks>
        public DirectionTypeEnum FindChunkType(NeighborStruct chunk)
        {
            if (chunk.Direction == DirectionTypeEnum.Error)
            {
                // Well, something really fucked out,
                // Somewhere. . .
                // (((φ(◎ロ◎;)φ)))
                // I Should probably put some kind of exception here.
                // But then it would make this exceptional.
                // o(〒﹏〒)o
                throw new ArgumentException("System Erroed out : Chunk Handler > Find Chunk Type");
            }
            else if (chunk.Direction != DirectionTypeEnum.Collapsed || chunk.Direction == DirectionTypeEnum.Blank)
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
            else
                return chunk.Direction;
        }
    }
}