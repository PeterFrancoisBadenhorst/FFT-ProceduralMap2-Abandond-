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
using Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;

namespace Assets.SRC.ProceduralMapGeneration.Utilities.Tests
{
    [TestFixture]
    public class GridCreate_Tests
    {
        private GridCreate _gridCreate;
        private GridCreate_Mocs _gridCreate_Mocs;


        #region [SetUp]&&[TearDown]
        [SetUp]
        public void SetUp()
        {
            _gridCreate = new GridCreate();
            _gridCreate_Mocs = new GridCreate_Mocs();
        }

        [TearDown]
        public void TearDown()
        {
            _gridCreate = null;
            _gridCreate_Mocs = null;
        }
        #endregion

        #region Validate_SquareGrid2DVertical Test Cases
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(14, 0.5f)]
        [TestCase(16, 22.34f)]
        #endregion
        public void Validate_SquareGrid2DVertical(int gridSize, float scale)
           => GridCreate.SquareGrid2DVertical(gridSize, scale).Count<Vector3>().Should().Be((gridSize * gridSize));

        #region Validate_SquareGrid2DHorizontal Test Cases
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(14, 0.5f)]
        [TestCase(16, 22.34f)]
        #endregion
        public void Validate_SquareGrid2DHorizontal(int gridSize, float scale)
           => GridCreate.SquareGrid2DHorizontal(gridSize, scale).Count<Vector3>().Should().Be((gridSize * gridSize));

        #region Validate_SquareGrid3D Test Cases
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(14, 0.5f)]
        [TestCase(16, 22.34f)]
        #endregion
        public void Validate_SquareGrid3D(int gridSize, float scale)
            => GridCreate.SquareGrid3D(gridSize, scale).Count<Vector3>().Should().Be((gridSize * gridSize * gridSize));

        [Test]
        public void Validate_FindChunkNeigbors(int gridSize, float scale)
        {
            Assert.Fail();
            //var result = GridCreate.SquareGrid2DVertical(gridSize, scale);
            //for (int i = 0; i < result.Count<Vector3>(); i++)
            //{
            //   var t= result[i];               
            //}
        }
        #region Validate_AssignDirectionIDAccordingToPresentNeighbors Test Cases
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(14, 0.5f)]
        [TestCase(16, 22.34f)]
        #endregion
        public void Validate_AssignDirectionIDAccordingToPresentNeighbors(int size,float scale)
        {
            // Given
            List<GameObject> list = GridCreate.AssignDirectionIDAccordingToPresentNeighbors(_gridCreate_Mocs.CreatGameObjectList(scale, size));
            for (int i = 0; i < list.Count; i++)
            {
                var t = list[i];
                // Test for ChunkBehavior
                if (!t.GetComponent<ChunkBehavior>()) Assert.Fail("Object does not have a 'ChunkBehavior' @ : " + i);
                // Test For Direction Values being set
                var g = t.GetComponent<ChunkBehavior>();
                if (!g.Direction.NothID &&
                    !g.Direction.EastID &&
                    !g.Direction.SouthID &&
                    !g.Direction.WestID &&
                    !g.Direction.TopID &&
                    !g.Direction.BottomID)
                    Assert.Fail("Direction not being set at @ : " + i);
            }
        }

        #region Validate_FindChunkType Test Cases
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.N, true, false, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NE, true, true, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NET, true, true, false, false, true, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NEB, true, true, false, false, false, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NEW, true, true, false, true, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NEWT, true, true, false, true, true, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NEWB, true, true, false, true, false, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NEWTB, true, true, false, true, true, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NES, true, true, true, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NEST, true, true, true, false, true, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NESB, true, true, true, false, false, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NESTB, true, true, true, false, true, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NETB, true, true, false, false, true, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NS, true, false, true, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NSW, true, false, true, true, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NST, true, false, true, false, true, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NSB, true, false, true, false, false, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NSTB, true, false, true, false, true, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NW, true, false, false, true, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NWT, true, false, false, true, true, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NWB, true, false, false, true, false, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NWTB, true, false, false, true, true, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NT, true, false, false, false, true, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NTB, true, false, false, false, true, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.NB, true, false, false, false, false, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.E, false, true, false, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.ES, false, true, true, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.ESW, false, true, true, true, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.EST, false, true, true, false, true, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.ESB, false, true, true, false, false, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.ESTB, false, true, true, false, true, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.EW, false, true, false, true, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.EWT, false, true, false, true, true, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.EWTB, false, true, false, true, true, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.EWB, false, true, false, true, false, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.ET, false, true, false, false, true, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.ETB, false, true, false, false, true, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.EB, false, true, false, false, false, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.S, false, false, true, false, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.SW, false, false, true, true, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.SWT, false, false, true, true, true, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.SWB, false, false, true, true, false, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.SWTB, false, false, true, true, true, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.ST, false, false, true, false, true, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.STB, false, false, true, false, true, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.SB, false, false, true, false, false, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.W, false, false, false, true, false, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.WT, false, false, false, true, true, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.WTB, false, false, false, true, true, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.WB, false, false, false, true, false, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.T, false, false, false, false, true, false)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.TB, false, false, false, false, true, true)]
        //                              north, east, south, west, top, bottom
        [TestCase(DirectionTypeEnum.B, false, false, false, false, false, true)]
        #endregion
        public void Validate_FindChunkType(DirectionTypeEnum proved, bool north, bool east, bool south, bool west, bool top, bool bottom)
        {
            /// Given
            var result = _gridCreate_Mocs.SetUpNeighborStruct(north, east, south, west, top, bottom);
            /// When
            result.Direction.Should().Be(Enums.DirectionTypeEnum.Blank);
            /// Then
            _gridCreate.FindChunkType(result).Should().Be(proved);
        }
    }
}
