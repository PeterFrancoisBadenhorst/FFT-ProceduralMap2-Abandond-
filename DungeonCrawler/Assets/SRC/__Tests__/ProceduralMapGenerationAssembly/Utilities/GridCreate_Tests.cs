using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Utilities.Tests
{
    [TestFixture]
    public class GridCreate_Tests
    {
        private GridCreate _gridCreate;

        public Transform GridParent { get; private set; }

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

        [Test, Order(1)]
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(14, 0.5f)]
        [TestCase(16, 22.34f)]
        public void Validate_SquareGrid2DVertical(int gridSize, float scale)
        {
            var t = _gridCreate.SquareGrid2DVertical(gridSize, scale);
            t.Should().NotBeNull();
            t.Should().NotBeEmpty();
            t.Length.Should().Be(gridSize * gridSize);
        }

        [Test, Order(1)]
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(14, 0.5f)]
        [TestCase(16, 22.34f)]
        public void Validate_SquareGrid2DHorizontal(int gridSize, float scale)
        {
            var t = _gridCreate.SquareGrid2DHorizontal(gridSize, scale);
            t.Should().NotBeNull();
            t.Should().NotBeEmpty();
            t.Length.Should().Be(gridSize * gridSize);
        }

        [Test, Order(1)]
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(14, 0.5f)]
        [TestCase(16, 22.34f)]
        public void Validate_SquareGrid3D(int gridSize, float scale)
        {
            var t = _gridCreate.SquareGrid3D(gridSize, scale);
            t.Should().NotBeNull();
            t.Should().NotBeEmpty();
            t.Length.Should().Be(gridSize * gridSize * gridSize);
        }


        [Test, Order(2)]
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(14, 0.5f)]
        [TestCase(16, 22.34f)]
        public void Validate_PlaceGameObjectsAtGridPositions(int gridSize, float scale)
        {
            // 3D Grid
            var positions3D = _gridCreate.SquareGrid3D(gridSize, scale);
            List<GameObject> grid3D = _gridCreate.PlaceGameObjectsAtGridPositions(positions3D, GridParent);
            // Grid size check
            grid3D.Count.Should().Be(positions3D.Length);
            // Position allocation check
            for (int i = 0; i < grid3D.Count; i++)
                grid3D[i].transform.position.Should().Be(positions3D[i]);

            // 2D H Grid
            var positions2DH = _gridCreate.SquareGrid3D(gridSize, scale);
            List<GameObject> grid2DH = _gridCreate.PlaceGameObjectsAtGridPositions(positions2DH, GridParent);
            // Grid size check
            grid2DH.Count.Should().Be(positions3D.Length);
            // Position allocation check
            for (int i = 0; i < grid2DH.Count; i++)
                grid2DH[i].transform.position.Should().Be(positions2DH[i]);

            // 2D V Grid
            var positions2DV = _gridCreate.SquareGrid3D(gridSize, scale);
            List<GameObject> grid2DV = _gridCreate.PlaceGameObjectsAtGridPositions(positions2DV, GridParent);
            // Grid size check
            grid2DV.Count.Should().Be(positions3D.Length);
            // Position allocation check
            for (int i = 0; i < grid2DV.Count; i++)
                grid2DV[i].transform.position.Should().Be(positions2DV[i]);
        }


        [Test, Order(2)]
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(6, 0.5f)]
        [TestCase(10, 22.34f)]
        public void Validate_FindChunkNeigbors(int gridSize, float scale)
        {
            ChunkHandler chunkHandler = new();
            var positions3D = _gridCreate.SquareGrid3D(gridSize, scale);
            var grid3D = _gridCreate.PlaceGameObjectsAtGridPositions(positions3D, GridParent);
            var positions2DH = _gridCreate.SquareGrid3D(gridSize, scale);
            var grid2DH = _gridCreate.PlaceGameObjectsAtGridPositions(positions2DH, GridParent);
            var positions2DV = _gridCreate.SquareGrid3D(gridSize, scale);
            var grid2DV = _gridCreate.PlaceGameObjectsAtGridPositions(positions2DV, GridParent);

            List<GameObject> test3D = chunkHandler.FindChunkNeigbors(scale, grid3D);
            List<GameObject> test2DH = chunkHandler.FindChunkNeigbors(scale, grid2DH);
            List<GameObject> test2DV = chunkHandler.FindChunkNeigbors(scale, grid2DV);

            for (int i = 0; i < test3D.Count; i++)
            {
                var t = test3D[i].GetComponent<ChunkBehavior>();
                t.neighborStruct.Direction.Should().NotBe(DirectionTypeEnum.Collapsed);
                t.neighborStruct.Direction.Should().NotBe(DirectionTypeEnum.Blank);
            }
            for (int i = 0; i < test2DH.Count; i++)
            {
                var t = test2DH[i].GetComponent<ChunkBehavior>();
                t.neighborStruct.Direction.Should().NotBe(DirectionTypeEnum.Collapsed);
                t.neighborStruct.Direction.Should().NotBe(DirectionTypeEnum.Blank);
            }
            for (int i = 0; i < test2DV.Count; i++)
            {
                var t = test2DV[i].GetComponent<ChunkBehavior>();
                t.neighborStruct.Direction.Should().NotBe(DirectionTypeEnum.Collapsed);
                t.neighborStruct.Direction.Should().NotBe(DirectionTypeEnum.Blank);
            }
        }

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
        public void FindChunkType_ShouldReturnTheCorrectChunkType(DirectionTypeEnum expectedChunkType, bool northNeighbor, bool eastNeighbor, bool southNeighbor, bool westNeighbor, bool topNeighbor, bool bottomNeighbor)
        {
            ChunkHandler chunkHandler = new();
            // Arrange
            NeighborStruct chunk = new ();
            if (northNeighbor) chunk.NorthNeighbor = new GameObject();
            if (eastNeighbor) chunk.EastNeighbor = new GameObject();
            if (southNeighbor) chunk.SouthNeighbor = new GameObject();
            if (westNeighbor) chunk.WestNeighbor = new GameObject();
            if (topNeighbor) chunk.TopNeighbor = new GameObject();
            if (bottomNeighbor) chunk.BottomNeighbor = new GameObject();

            // Act
            DirectionTypeEnum chunkType = chunkHandler.FindChunkType(chunk);

            // Assert
            Assert.That(chunkType, Is.EqualTo(expectedChunkType));
        }
    }
}