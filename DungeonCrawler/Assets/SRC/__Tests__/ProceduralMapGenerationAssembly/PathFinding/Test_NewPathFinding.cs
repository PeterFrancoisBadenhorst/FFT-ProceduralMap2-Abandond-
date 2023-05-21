using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

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
    }
}