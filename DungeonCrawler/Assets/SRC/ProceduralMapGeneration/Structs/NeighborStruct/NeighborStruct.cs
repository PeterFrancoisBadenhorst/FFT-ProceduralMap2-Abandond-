using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs
{
    [System.Serializable]
    public struct NeighborStruct
    {
        public DirectionTypeEnum Direction;
        public GameObject OriginObject;
        public GameObject NorthNeighbor;
        public GameObject EastNeighbor;
        public GameObject SouthNeighbor;
        public GameObject WestNeighbor;
        public GameObject TopNeighbor;
        public GameObject BottomNeighbor;
    }
}