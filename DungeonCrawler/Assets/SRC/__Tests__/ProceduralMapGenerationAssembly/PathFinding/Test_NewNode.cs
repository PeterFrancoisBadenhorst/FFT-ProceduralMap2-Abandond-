using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.PathFinding.Tests
{
    public class Test_NewNode
    {
        [Test]
        public void Should_Create_A_New_Node_With_A_Position()
        {
            // Arrange
            Vector3 position = new Vector3(1, 2, 3);

            // Act
            NewNodeModel node = new NewNodeModel() { Position = position };

            // Assert
            node.Position.Should().Be(position);
        }

        [Test]
        public void Should_Not_Have_An_Empty_List_Of_Neighbors_ByDefault()
        {
            // Arrange
            NewNodeModel node = new NewNodeModel();

            // Act
            List<NewNodeModel> neighbors = node.Neighbors;

            // Assert
            neighbors.Should().BeNullOrEmpty();
        }

        [Test]
        public void Should_Not_Be_Closed_ByDefault()
        {
            // Arrange
            NewNodeModel node = new NewNodeModel();

            // Act
            bool closed = node.Closed;

            // Assert
            closed.Should().BeFalse();
        }

        [Test]
        public void Should_Have_A_Default_Cost_Of_Zero()
        {
            // Arrange
            NewNodeModel node = new NewNodeModel();

            // Act
            float cost = node.fCost;

            // Assert
            cost.Should().Be(0f);
        }

        [Test]
        public void Should_Have_A_Default_Heuristic_Cost_Of_Zero()
        {
            // Arrange
            NewNodeModel node = new NewNodeModel();

            // Act
            float hCost = node.hCost;

            // Assert
            hCost.Should().Be(0f);
        }

        [Test]
        public void Should_Not_Have_A_LastNode_ByDefault()
        {
            // Arrange
            NewNodeModel node = new NewNodeModel();

            // Act
            NewNodeModel lastNode = node.LastNode;

            // Assert
            lastNode.Should().BeNull();
        }
    }
}