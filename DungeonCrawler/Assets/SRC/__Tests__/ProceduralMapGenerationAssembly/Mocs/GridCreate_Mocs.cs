using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Utilities.Tests
{
    internal class GridCreate_Mocs
    {
        public UnityEngine.Vector3[] GridPositions;
        public List<GameObject> TestGrid;

        public NeighborStruct SetUpNeighborStruct(bool north, bool east, bool south, bool west, bool top, bool bottom)
        {
            NeighborStruct returned = new NeighborStruct();
            if (north) returned.NorthNeighbor = new GameObject();
            if (east) returned.EastNeighbor = new GameObject();
            if (south) returned.SouthNeighbor = new GameObject();
            if (west) returned.WestNeighbor = new GameObject();
            if (top) returned.TopNeighbor = new GameObject();
            if (bottom) returned.BottomNeighbor = new GameObject();
            returned.Direction = DirectionTypeEnum.Blank;
            return returned;
        }

        public List<NeighborStruct> CreatGameObjectList(float scale, int size)
        {
            List<NeighborStruct> list = new List<NeighborStruct>();
            return list;
            //GridCreate gridCreate = new GridCreate();
            //GameObject parent = new GameObject();
            //return gridCreate.FindChunkNeigbors(scale, gridCreate.PlaceGameObjectsAtGridPositions(gridCreate.SquareGrid2DHorizontal(size, scale), parent.transform));
        }
    }
}