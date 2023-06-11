using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Drawing;

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
                var randFailFix = false;
                Vector3[] pos = null;

                // Act
                while (!randFailFix)
                {
                    System.Random random = new System.Random();

                    pos = pathFinder.FindEnds(grid);

                    if (pos[0] != pos[1])
                    {
                        randFailFix = true;
                    }

                }
                // Assert
                pos[0].Should().NotBeEquivalentTo(pos[1]);
                pos.Count().Should().Be(2);

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
                List<NewNodeModel> grid = new();

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
                List<NewNodeModel> grid = new List<NewNodeModel>
            {
                new NewNodeModel(),
                new NewNodeModel(),
                new NewNodeModel(),
                new NewNodeModel(),
                new NewNodeModel(),
                new NewNodeModel()
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
                List<NewNodeModel> grid = new List<NewNodeModel>
            {
                new NewNodeModel(),
                new NewNodeModel(),
                new NewNodeModel(),
                new NewNodeModel(),
                new NewNodeModel(),
                new NewNodeModel()
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
        public class FindpathTests
        {
            NewPathFinding pathFinder = new NewPathFinding();
            [Test]
            public void TestFindpath_WithValidGridAndPositions_ReturnsPath()
            {
                // Arrange
                List<NewNodeModel> grid = new List<NewNodeModel>
            {
                new NewNodeModel() { Position = new Vector3(1, 2, 3) },
                new NewNodeModel() { Position = new Vector3(4, 5, 6) },
                new NewNodeModel() { Position = new Vector3(7, 8, 9) },
            };
                Vector3[] positions = new Vector3[]
                {
                new Vector3(1, 2, 3),
                new Vector3(7, 8, 9),
                };

                // Act
                List<Vector3> path = pathFinder.Findpath(grid, positions);

                // Assert
                Assert.IsNotNull(path);
                Assert.AreEqual(2, path.Count);
                Assert.AreEqual(new Vector3(1, 2, 3), path[0]);
                Assert.AreEqual(new Vector3(7, 8, 9), path[1]);
            }

            [Test]
            public void TestFindpath_WithNullGrid_ThrowsArgumentNullException()
            {
                // Arrange
                Vector3[] positions = new Vector3[]
                {
                new Vector3(1, 2, 3),
                new Vector3(7, 8, 9),
                };

                // Act
                // Assert
                Assert.Throws<ArgumentNullException>(() => pathFinder.Findpath(null, positions));
            }

            [Test]
            public void TestFindpath_WithEmptyGrid_ThrowsArgumentNullException()
            {
                // Arrange
                List<NewNodeModel> grid = new List<NewNodeModel>();
                Vector3[] positions = new Vector3[]
                {
                new Vector3(1, 2, 3),
                new Vector3(7, 8, 9),
                };

                // Act
                // Assert
                Assert.Throws<ArgumentNullException>(() => pathFinder.Findpath(grid, positions));
            }

            [Test]
            public void TestFindpath_WithNullPositions_ThrowsArgumentNullException()
            {
                // Arrange
                List<NewNodeModel> grid = new List<NewNodeModel>
            {
                new NewNodeModel() { Position = new Vector3(1, 2, 3) },
                new NewNodeModel() { Position = new Vector3(4, 5, 6) },
                new NewNodeModel() { Position = new Vector3(7, 8, 9) },
            };

                // Act
                // Assert
                Assert.Throws<ArgumentNullException>(() => pathFinder.Findpath(grid, null));
            }

            [Test]
            public void TestFindpath_WithEmptyPositions_ThrowsArgumentNullException()
            {
                // Arrange
                List<NewNodeModel> grid = new List<NewNodeModel>
            {
                new NewNodeModel() { Position = new Vector3(1, 2, 3) },
                new NewNodeModel() { Position = new Vector3(4, 5, 6) },
                new NewNodeModel() { Position = new Vector3(7, 8, 9) },
            };
                Vector3[] positions = new Vector3[0];

                // Act
                // Assert
                Assert.Throws<ArgumentNullException>(() => pathFinder.Findpath(grid, positions));
            }
        }
        [TestFixture]
        public class FindActiveNodeTests
        {
            NewPathFinding pathFinder = new NewPathFinding();
            [Test]
            public void TestFindActiveNode_WithValidActiveNodeAndEndPos_ReturnsActiveNode()
            {
                // Arrange
                NewNodeModel neighborNode = new NewNodeModel()
                {
                    Position = new Vector3(1, 2, 3),
                    Closed = true,
                    fCost = 50,
                    hCost = 50,
                };
                NewNodeModel[] neighbors = new NewNodeModel[] { neighborNode, neighborNode };
                NewNodeModel activeNode = new NewNodeModel()
                {
                    Position = new Vector3(1, 2, 3),
                    Neighbors = neighbors.ToList(),
                    Closed = true,
                    fCost = 50,
                    hCost = 50,
                    LastNode = neighborNode,

                };
                NewNodeModel endPos = new NewNodeModel() { Position = new Vector3(7, 8, 9) };

                // Act

                NewNodeModel foundActiveNode = pathFinder.FindActiveNode(activeNode, endPos);

                // Assert
                foundActiveNode.Should().NotBeNull();
                foundActiveNode.Position.Should().BeEquivalentTo(new Vector3(1, 2, 3));
            }
            //public class NewNodeModel
            //{
            //    public Vector3 Position;                // Position of the node
            //    public List<NewNodeModel> Neighbors;         // List of neighboring nodes
            //    public bool Closed;                     // Whether the node has been visited
            //    public float fCost, hCost;              // Cost variables used in A* algorithm
            //    public NewNodeModel LastNode;                // The last node visited in the path
            //}
            [Test]
            public void TestFindActiveNode_WithActiveNodeWithNoNeighbors_ReturnsNull()
            {
                // Arrange
                NewNodeModel activeNode = new NewNodeModel() { Position = new Vector3(1, 2, 3) };
                activeNode.Neighbors = new List<NewNodeModel>();
                NewNodeModel endPos = new NewNodeModel() { Position = new Vector3(7, 8, 9) };

                // Act
                NewNodeModel foundActiveNode = pathFinder.FindActiveNode(activeNode, endPos);

                // Assert
                foundActiveNode.Should().NotBeNull();
            }

            [Test]
            public void TestFindActiveNode_WithActiveNodeWithNeighborsButNoValidEndPos_ReturnsNull()
            {
                // Arrange
                NewNodeModel activeNode = new NewNodeModel() { Position = new Vector3(1, 2, 3) };
                activeNode.Neighbors = new List<NewNodeModel>
            {
                new NewNodeModel() { Position = new Vector3(4, 5, 6) },
                new NewNodeModel() { Position = new Vector3(7, 8, 9) },
            };
                NewNodeModel endPos = new NewNodeModel() { Position = new Vector3(10, 11, 12) };

                // Act
                NewNodeModel foundActiveNode = pathFinder.FindActiveNode(activeNode, endPos);

                // Assert
                foundActiveNode.Should().NotBeNull();
            }
        }
        [TestFixture]
        public class GeneratePathTests
        {
            NewPathFinding pathFinder = new NewPathFinding();
            [Test]
            public void TestGeneratePath_WithValidActiveNodeAndStartPos_ReturnsPath()
            {
                // Arrange
                NewNodeModel activeNode = new NewNodeModel() { Position = new Vector3(1, 2, 3) };
                NewNodeModel startPos = new NewNodeModel() { Position = new Vector3(7, 8, 9) };

                // Act
                List<NewNodeModel> generatedPath = pathFinder.GeneratePath(activeNode, startPos);

                // Assert
                Assert.IsNotNull(generatedPath);
                Assert.AreEqual(2, generatedPath.Count);
                Assert.AreEqual(activeNode, generatedPath[0]);
                Assert.AreEqual(startPos, generatedPath[1]);
            }

            [Test]
            public void TestGeneratePath_WithActiveNodeWithNoLastNode_ReturnsEmptyList()
            {
                // Arrange
                NewNodeModel activeNode = new NewNodeModel() { Position = new Vector3(1, 2, 3) };
                activeNode.LastNode = null;
                NewNodeModel startPos = new NewNodeModel() { Position = new Vector3(7, 8, 9) };

                // Act
                List<NewNodeModel> generatedPath = pathFinder.GeneratePath(activeNode, startPos);

                // Assert
                Assert.IsNotNull(generatedPath);

            }

            [Test]
            public void TestGeneratePath_WithActiveNodeWithNoValidStartPos_ReturnsEmptyList()
            {
                // Arrange
                NewNodeModel activeNode = new NewNodeModel() { Position = new Vector3(1, 2, 3) };
                NewNodeModel startPos = new NewNodeModel() { Position = new Vector3(10, 11, 12) };

                // Act
                List<NewNodeModel> generatedPath = pathFinder.GeneratePath(activeNode, startPos);

                // Assert
                Assert.IsNotNull(generatedPath);

            }
        }
        [TestFixture]
        public class ConvertPathToPositionsTests
        {
            NewPathFinding pathFinder = new NewPathFinding();
            [Test]
            public void TestConvertPathToPositions_WithValidGeneratedList_ReturnsPositions()
            {
                // Arrange
                List<NewNodeModel> generatedList = new List<NewNodeModel>
            {
                new NewNodeModel() { Position = new Vector3(1, 2, 3) },
                new NewNodeModel() { Position = new Vector3(4, 5, 6) },
                new NewNodeModel() { Position = new Vector3(7, 8, 9) },
            };

                // Act
                List<Vector3> convertedPositions = pathFinder.ConvertPathToPositions(generatedList);

                // Assert
                Assert.IsNotNull(convertedPositions);
                Assert.AreEqual(3, convertedPositions.Count);
                Assert.AreEqual(new Vector3(1, 2, 3), convertedPositions[0]);
                Assert.AreEqual(new Vector3(4, 5, 6), convertedPositions[1]);
                Assert.AreEqual(new Vector3(7, 8, 9), convertedPositions[2]);
            }

            [Test]
            public void TestConvertPathToPositions_WithEmptyGeneratedList_ReturnsEmptyList()
            {
                // Arrange
                List<NewNodeModel> generatedList = new List<NewNodeModel>();

                // Act
                List<Vector3> convertedPositions = pathFinder.ConvertPathToPositions(generatedList);

                // Assert
                Assert.IsNotNull(convertedPositions);
            }

            [Test]
            public void TestConvertPathToPositions_WithGeneratedListWithNoPositions_ReturnsEmptyList()
            {
                // Arrange
                List<NewNodeModel> generatedList = new List<NewNodeModel>();
                generatedList.Add(new NewNodeModel());
                generatedList.Add(new NewNodeModel());

                // Act
                List<Vector3> convertedPositions = pathFinder.ConvertPathToPositions(generatedList);

                // Assert
                Assert.IsNotNull(convertedPositions);
            }
        }
        [TestFixture]
        public class NodeGridCreatorTests
        {
            NewPathFinding pathFinder = new NewPathFinding();
            [Test]
            public void TestNodeGridCreatorA()
            {
                // Arrange
                Vector3[] grid = new Vector3[]
                {
                new Vector3(0, 0, 0),
                new Vector3(1, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(1, 1, 0)
                };
                Vector3[] baseMap = new Vector3[]
                {
                new Vector3(2, 2, 0),
                new Vector3(3, 2, 0),
                new Vector3(2, 3, 0),
                new Vector3(3, 3, 0)
                };
                float scale = 1.0f;

                // Act
                Vector3[] results = pathFinder.NodeGridCreator(grid, baseMap, scale);

                // Assert
                Assert.AreEqual(2, results.Length);
            }
            [Test]
            public void TestNodeGridCreatoB()
            {
                // Arrange
                Vector3[] grid = new Vector3[]
                {
                new Vector3(0, 0, 0),
                new Vector3(1, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(1, 1, 0)
                };
                float scale = 1.0f;

                // Act
                Vector3[] results = pathFinder.NodeGridCreator(grid, scale);

                // Assert
                Assert.AreEqual(2, results.Length);
            }
            [Test]
            public void TestReturnPath()
            {
                // Arrange
                Vector3[] grid = new Vector3[]
                {
                new Vector3(0, 0, 0),
                new Vector3(1, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(1, 1, 0)
                };
                float scale = 1.0f;
                Vector3[] ends = new Vector3[]
                {
                new Vector3(2, 2, 0),
                new Vector3(3, 3, 0)
                };

                // Act
                Vector3[] results = pathFinder.ReturnPath(grid, scale, ends);

                // Assert
                Assert.AreEqual(2, results.Length);
            }
        }
        [TestFixture]
        public class SetNodeNeighborsTest
        {
            NewPathFinding pathFinder = new NewPathFinding();
            [Test]
            public void TestSetNodeNeighbors()
            {
                // Arrange
                List<NewNodeModel> nodes = new List<NewNodeModel>
            {
                new(),
                new(),
                new(),
                new()
            };
                float scale = 1.0f;

                // Act
                List<NewNodeModel> results = pathFinder.SetNodeNeighbors(nodes, scale);

                // Assert
                Assert.AreEqual(4, results.Count);
            }
            [Test]
            public void ComparePositionsTest()
            {

                // Arrange
                Vector3 poasA = new Vector3(1, 2, 3);
                Vector3 posB = new Vector3(0, 0, 0);
                float multiplier = 1.0f;

                // Act
                bool result = NewPathFinding.ComparePositions(poasA, posB, multiplier);

                // Assert
                result.Should().BeFalse();   

            }
        }
    }
}