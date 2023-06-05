using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Assets.SRC.Shared.Utilities;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using System;

namespace Assets.SRC.ProceduralMapGeneration.Generic.Tests
{
    public class Test_VectorMath
    {
        [Test]
        public void CalculateDistanceBetweenTwoVectors_ShouldReturnTheCorrectDistance()
        {
            // Arrange
            VectorMath vectorMath = new VectorMath();
            Vector3 v1 = new Vector3(1, 2, 3);
            Vector3 v2 = new Vector3(4, 5, 6);
            // Act
            float expectedDistance = 5.196152F;
            float actualDistance = vectorMath.CalculateDistanceBetweenTwoVectors(v1, v2);
            // Assert
            actualDistance.Should().Be(expectedDistance);
        }

    }
}