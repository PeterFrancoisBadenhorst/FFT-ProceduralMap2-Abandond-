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

        private NewPathFinding pathFinder = new NewPathFinding();
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
}