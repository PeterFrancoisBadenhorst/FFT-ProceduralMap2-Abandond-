using Assets.SRC.ProceduralMapGeneration.Enums;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Structs
{
    [System.Serializable]
    public struct NeighborStruct
    {
        public DirectionTypeEnum Direction; /*{ get; set; }*/
        public GameObject OriginObject; /*{ get; set; }*/
        public GameObject NorthNeighbor; /*{ get; set; }*/
        public GameObject EastNeighbor; /*{ get; set; }*/
        public GameObject SouthNeighbor; /*{ get; set; }*/
        public GameObject WestNeighbor; /*{ get; set; }*/
        public GameObject TopNeighbor; /*{ get; set; }*/
        public GameObject BottomNeighbor;/* { get; set; }*/
    }
}
