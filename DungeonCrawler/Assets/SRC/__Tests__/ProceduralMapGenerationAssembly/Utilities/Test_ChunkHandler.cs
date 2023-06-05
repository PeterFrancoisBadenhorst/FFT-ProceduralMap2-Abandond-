using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;

namespace Assets.SRC.ProceduralMapGeneration.PathFinding.Tests
{
    public class Test_ChunkHandler
    {
        [TestFixture]
        public class FindChunkNeigborsTests
        {
            ChunkHandler chunkHandler = new ChunkHandler();
            [Test]
            public void TestFindChunkNeigbors_WithValidInput_ReturnsCorrectNeighbors()
            {
                // Arrange
                List<GameObject> grid = new List<GameObject>
            {
                new GameObject(),
                new GameObject(),
                new GameObject(),
                new GameObject(),
                new GameObject(),
                new GameObject(),
                new GameObject(),
                new GameObject()
            };

                grid[0].transform.position = new Vector3(1, 0, 0);
                grid[1].transform.position = new Vector3(0, 1, 0);
                grid[2].transform.position = new Vector3(0, 0, 1);
                grid[3].transform.position = new Vector3(1, 1, 0);
                grid[4].transform.position = new Vector3(1, 0, 1);
                grid[5].transform.position = new Vector3(0, 1, 1);
                grid[6].transform.position = new Vector3(1, 1, 1);



                Dictionary<Vector3, GameObject> positions = new Dictionary<Vector3, GameObject>();
                positions.Add(grid[0].transform.position, grid[0]);
                positions.Add(grid[1].transform.position, grid[1]);
                positions.Add(grid[2].transform.position, grid[2]);
                positions.Add(grid[3].transform.position, grid[3]);
                positions.Add(grid[4].transform.position, grid[4]);
                positions.Add(grid[5].transform.position, grid[5]);
                positions.Add(grid[6].transform.position, grid[6]);

                // Act
                List<GameObject> neighbors = chunkHandler.FindChunkNeigbors(1.0f, grid);


                // Assert
                neighbors.Should().NotBeNullOrEmpty();
                neighbors[0].Should().NotBeNull();
                neighbors[2].Should().NotBeNull();
                neighbors[3].Should().NotBeNull();
                neighbors[4].Should().NotBeNull();
                neighbors[5].Should().NotBeNull();
                neighbors[6].Should().NotBeNull();

                neighbors[0].Should().BeEquivalentTo(grid[0]);
                neighbors[1].Should().BeEquivalentTo(grid[1]);
                neighbors[2].Should().BeEquivalentTo(grid[2]);
                neighbors[3].Should().BeEquivalentTo(grid[3]);
                neighbors[4].Should().BeEquivalentTo(grid[4]);
                neighbors[5].Should().BeEquivalentTo(grid[5]);
                neighbors[6].Should().BeEquivalentTo(grid[6]);

            }

            [Test]
            public void TestFindChunkNeigbors_WithInvalidInput_ReturnsEmptyList()
            {
                // Arrange
                List<GameObject> grid = new List<GameObject>();

                // Act
                List<GameObject> neighbors = chunkHandler.FindChunkNeigbors(1.0f, grid);

                // Assert
                Assert.IsNotNull(neighbors);
                Assert.IsEmpty(neighbors);
            }
        }
        [TestFixture]
        public class AssignChunkTypesTests
        {
            ChunkHandler chunkHandler = new ChunkHandler();
            [Test]
            public void TestAssignChunkTypes_WithValidInput_AssignsCorrectTypes()
            {
                // Arrange
                List<GameObject> grid = new List<GameObject>
            {
                new GameObject(),
                new GameObject(),
                new GameObject(),
                new GameObject(),
                new GameObject(),
                new GameObject(),
                new GameObject(),
                new GameObject()
            };

                grid[0].transform.position = new Vector3(1, 0, 0);
                grid[1].transform.position = new Vector3(0, 1, 0);
                grid[2].transform.position = new Vector3(0, 0, 1);
                grid[3].transform.position = new Vector3(1, 1, 0);
                grid[4].transform.position = new Vector3(1, 0, 1);
                grid[5].transform.position = new Vector3(0, 1, 1);
                grid[6].transform.position = new Vector3(1, 1, 1);



                Dictionary<Vector3, GameObject> positions = new Dictionary<Vector3, GameObject>();
                positions.Add(grid[0].transform.position, grid[0]);
                positions.Add(grid[1].transform.position, grid[1]);
                positions.Add(grid[2].transform.position, grid[2]);
                positions.Add(grid[3].transform.position, grid[3]);
                positions.Add(grid[4].transform.position, grid[4]);
                positions.Add(grid[5].transform.position, grid[5]);
                positions.Add(grid[6].transform.position, grid[6]);

                GenericUtilities _genericUtilities = new GenericUtilities();

                // Act
                List<GameObject> neighbors = chunkHandler.FindChunkNeigbors(1.0f, grid);
                List<GameObject> assignedTypes = chunkHandler.AssignChunkTypes(neighbors);

                // Assert
                Assert.IsNotNull(assignedTypes);
                Assert.AreEqual(8, assignedTypes.Count);
                Assert.AreEqual(grid[0], assignedTypes[0]);
                Assert.AreEqual(grid[1], assignedTypes[1]);
                Assert.AreEqual(grid[2], assignedTypes[2]);
                Assert.AreEqual(grid[3], assignedTypes[3]);
                Assert.AreEqual(grid[4], assignedTypes[4]);
                Assert.AreEqual(grid[5], assignedTypes[5]);
                Assert.AreEqual(grid[6], assignedTypes[6]);
                Assert.AreEqual(grid[7], assignedTypes[7]);
            }

            [Test]
            public void TestAssignChunkTypes_WithInvalidInput_ReturnsEmptyList()
            {
                // Arrange
                List<GameObject> grid = new List<GameObject>();

                // Act
                List<GameObject> assignedTypes = chunkHandler.AssignChunkTypes(grid);

                // Assert
                Assert.IsNotNull(assignedTypes);
                Assert.IsEmpty(assignedTypes);
            }
        }
        [TestFixture]
        public class GenericTestsForChunkHandle
        {
            [Test]
            public void Error_Error()
            {
                ChunkHandler chunkHandler = new ChunkHandler();
                NeighborStruct chunk = new();
                chunk.Direction = DirectionTypeEnum.Error;
                Action act = () => chunkHandler.FindChunkType(chunk);
                act.Should().Throw<ArgumentException>();
            }           
            [Test]
            public void Return_Collapsed()
            {
                ChunkHandler chunkHandler = new ChunkHandler();
                NeighborStruct chunk = new();
                chunk.Direction = DirectionTypeEnum.Collapsed;
                var test = chunkHandler.FindChunkType(chunk);
                test.Should().Be(DirectionTypeEnum.Collapsed);
            }
        }
    }
}