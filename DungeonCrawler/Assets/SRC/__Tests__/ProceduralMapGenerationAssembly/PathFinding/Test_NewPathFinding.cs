using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;

namespace Assets.SRC.ProceduralMapGeneration.PathFinding.Tests
{
    public class Test_NewPathFinding
    {
        [TestFixture]
        public class FindEnds
        {
            NewPathFinding pathFinder = new NewPathFinding();
            [Test]
            public void Should_Return_A_List_Of_Two_Vector3s_When_Given_A_List_Of_Vector3s()
            {
                // Arrange
                Vector3[] grid = new Vector3[] { new Vector3(1, 2, 3), new Vector3(4, 5, 6) };
                System.Random random = new System.Random();

                // Act
                Vector3[] pos = pathFinder.FindEnds(grid);

                // Assert
                pos.Count().Should().Be(2);
            }

            [Test]
            public void Should_Return_A_List_Of_Two_Different_Vector3s_When_Given_A_List_Of_Vector3s()
            {
                // Arrange
                Vector3[] grid = new Vector3[] {
                new Vector3(1, 2, 3),
                new Vector3(4, 5, 6),
            };
                System.Random random = new System.Random();

                // Act
                Vector3[] pos = pathFinder.FindEnds(grid);

                // Assert
                pos[0].Should().NotBeEquivalentTo(pos[1]);
            }
        }
        [TestFixture]
        public class Findpath
        {
            NewPathFinding pathFinder = new NewPathFinding();
            [Test]
            public void NullGrid()
            {

                Vector3[] positions = new Vector3[]
                {
                new Vector3(0, 0),
                new Vector3(2, 2)
                };

                Action act = () => pathFinder.Findpath(null, positions);
                act.Should().Throw<ArgumentNullException>();
            }
            [Test]
            public void EmptyGrid()
            {
                List<NewNode> grid = new();

                Vector3[] positions = new Vector3[]
                {
                new Vector3(0, 0),
                new Vector3(2, 2)
                };

                Action act = () => pathFinder.Findpath(grid, positions);
                act.Should().Throw<ArgumentNullException>();
            }
            [Test]
            public void NullPositions()
            {
                List<NewNode> grid = new List<NewNode>
            {
                new NewNode(),
                new NewNode(),
                new NewNode(),
                new NewNode(),
                new NewNode(),
                new NewNode()
            };

                grid[0].Position = new Vector3(0, 0);
                grid[1].Position = new Vector3(1, 0);
                grid[2].Position = new Vector3(2, 0);
                grid[3].Position = new Vector3(0, 1);
                grid[4].Position = new Vector3(1, 1);
                grid[5].Position = new Vector3(2, 1);

                Action act = () => pathFinder.Findpath(grid, null);
                act.Should().Throw<ArgumentNullException>();
            }
            [Test]
            public void EmptyPositions()
            {
                List<NewNode> grid = new List<NewNode>
            {
                new NewNode(),
                new NewNode(),
                new NewNode(),
                new NewNode(),
                new NewNode(),
                new NewNode()
            };

                grid[0].Position = new Vector3(0, 0);
                grid[1].Position = new Vector3(1, 0);
                grid[2].Position = new Vector3(2, 0);
                grid[3].Position = new Vector3(0, 1);
                grid[4].Position = new Vector3(1, 1);
                grid[5].Position = new Vector3(2, 1);

                Vector3[] positions = new Vector3[] { };

                Action act = () => pathFinder.Findpath(grid, positions);
                act.Should().Throw<ArgumentNullException>();
            }
        }
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
                new GameObject()
            };

                grid[0].transform.position = new Vector3(0, 0, 0);
                grid[1].transform.position = new Vector3(1, 0, 0);
                grid[2].transform.position = new Vector3(2, 0, 0);
                grid[3].transform.position = new Vector3(0, 1, 0);
                grid[4].transform.position = new Vector3(1, 1, 0);
                grid[5].transform.position = new Vector3(2, 1, 0);

                Dictionary<Vector3, GameObject> positions = new Dictionary<Vector3, GameObject>();
                positions.Add(grid[0].transform.position, grid[0]);
                positions.Add(grid[1].transform.position, grid[1]);
                positions.Add(grid[2].transform.position, grid[2]);
                positions.Add(grid[3].transform.position, grid[3]);
                positions.Add(grid[4].transform.position, grid[4]);
                positions.Add(grid[5].transform.position, grid[5]);

                GenericUtilities _genericUtilities = new GenericUtilities();

                // Act
                List<GameObject> neighbors = chunkHandler.FindChunkNeigbors(1.0f, grid);
                List<GameObject> assignedTypes = chunkHandler.AssignChunkTypes(neighbors);

                // Assert
                Assert.IsNotNull(assignedTypes);
                Assert.AreEqual(6, assignedTypes.Count);
                Assert.AreEqual(grid[0], assignedTypes[0]);
                Assert.AreEqual(grid[1], assignedTypes[1]);
                Assert.AreEqual(grid[2], assignedTypes[2]);
                Assert.AreEqual(grid[3], assignedTypes[3]);
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
    }
}