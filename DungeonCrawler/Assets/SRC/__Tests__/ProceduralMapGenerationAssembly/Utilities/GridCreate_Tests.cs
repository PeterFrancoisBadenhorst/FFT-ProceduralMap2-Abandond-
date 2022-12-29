using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assets.SRC.ProceduralMapGeneration.Utilities;
using System.Linq;
using FluentAssertions;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;
using Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Enums;

namespace Assets.SRC.ProceduralMapGeneration.Utilities.Tests
{
    [TestFixture]
    public class GridCreate_Tests
    {
        private GridCreate _gridCreate;
        [SetUp]
        public void SetUp()
        {
            _gridCreate = new GridCreate();
        }
        [TearDown]
        public void TearDown()
        {
            _gridCreate = null;
        }


        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(14, 0.5f)]
        [TestCase(16, 22.34f)]
        public void Validate_2DGridCreations_EntityCount_Vertical(int gridSize, float scale)
           => GridCreate.SquareGrid2DVertical(gridSize, scale).Count<Vector3>().Should().Be((gridSize * gridSize));
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(14, 0.5f)]
        [TestCase(16, 22.34f)]
        public void Validate_2DGridCreations_EntityCount_Horizontal(int gridSize, float scale)
           => GridCreate.SquareGrid2DHorizontal(gridSize, scale).Count<Vector3>().Should().Be((gridSize * gridSize));
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(14, 0.5f)]
        [TestCase(16, 22.34f)]
        public void Validate_3DGridCreations_EntityCount(int gridSize, float scale)
            => GridCreate.SquareGrid3D(gridSize, scale).Count<Vector3>().Should().Be((gridSize * gridSize * gridSize));
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(14, 0.5f)]
        [TestCase(16, 22.34f)]
        public void Validate_FindChunkNeigbors(int gridSize, float scale)
        {
            Assert.Fail();
            //var result = GridCreate.SquareGrid2DVertical(gridSize, scale);
            //for (int i = 0; i < result.Count<Vector3>(); i++)
            //{
            //   var t= result[i];               
            //}
        }
        [Test]
        public void Validate_AssignDirectionIDAccordingToPresentNeighbors(List<NeighborStruct> objects)
        {
            Assert.Fail();
        }
        private NeighborStruct SetUpNeighborStruct(bool north, bool east, bool south, bool west, bool top, bool bottom)
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
        //                              north, -, -, -, -, -
        [TestCase(DirectionTypeEnum.N, true, false, false, false, false, false)]
        //                              north, east, -, -, -, -
        [TestCase(DirectionTypeEnum.NE, true, true, false, false, false, false)]
        //                              north, -, south, -, -, -
        [TestCase(DirectionTypeEnum.NS, true, false, true, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NW, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NT, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NB, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NES, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NEW, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NET, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NEB, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NEST, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NESB, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NETB, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.E, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.ES, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.EST, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.ESB, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.EW, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.EWT, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.EWB, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.ET, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.ETB, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.EB, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.ESW, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.Blank, false, false, false, false, false, false)]



        public void Validate_FindChunkType(DirectionTypeEnum proved, bool north, bool east, bool south, bool west, bool top, bool bottom)
        {
            /// Given
            var result = SetUpNeighborStruct(north, east, south, west, top, bottom);
            /// When
            result.Direction.Should().Be(Enums.DirectionTypeEnum.Blank);
            /// Then
            _gridCreate.FindChunkType(result).Should().Be(proved);
        }
    }
}
