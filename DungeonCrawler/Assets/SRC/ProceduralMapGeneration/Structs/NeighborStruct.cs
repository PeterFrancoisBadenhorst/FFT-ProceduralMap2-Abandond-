using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs
{
    // This struct represents a neighbor of a chunk.
    [System.Serializable]
    public struct NeighborStruct
    {
        // The direction of the neighbor.
        public DirectionTypeEnum Direction;
        // The origin object of the neighbor.
        public GameObject OriginObject;
        // The north neighbor of the chunk.
        public GameObject NorthNeighbor;
        // The east neighbor of the chunk.
        public GameObject EastNeighbor;
        // The south neighbor of the chunk.
        public GameObject SouthNeighbor;
        // The west neighbor of the chunk.
        public GameObject WestNeighbor;
        // The top neighbor of the chunk.
        public GameObject TopNeighbor;
        // The bottom neighbor of the chunk.
        public GameObject BottomNeighbor;
    }
}