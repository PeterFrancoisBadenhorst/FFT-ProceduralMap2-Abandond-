using Assets.SRC.ProceduralMapGeneration.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.SRC.ProceduralMapGeneration.Utilities;

namespace Assets.SRC.ProceduralMapGeneration.Utilities.Tests
{
    internal class GridCreate_Mocs
    {
        public NeighborStruct SetUpNeighborStruct(bool north, bool east, bool south, bool west, bool top, bool bottom)
        {
            NeighborStruct returned = new NeighborStruct();
            if (north) returned.NorthNeighbor = new GameObject();
            if (east) returned.EastNeighbor = new GameObject();
            if (south) returned.SouthNeighbor = new GameObject();
            if (west) returned.WestNeighbor = new GameObject();
            if (top) returned.TopNeighbor = new GameObject();
            if (bottom) returned.BottomNeighbor = new GameObject();
            returned.Direction = Enums.DirectionTypeEnum.Blank;
            return returned;
        }
        public List<NeighborStruct> CreatGameObjectList(float scale, int size)
        {
            GameObject parent = new GameObject();
           return GridCreate.FindChunkNeigbors(scale, GridCreate.PlaceGameObjectsAtGridPositions(GridCreate.SquareGrid2DHorizontal(size, scale), parent.transform));
        }

    }
}
