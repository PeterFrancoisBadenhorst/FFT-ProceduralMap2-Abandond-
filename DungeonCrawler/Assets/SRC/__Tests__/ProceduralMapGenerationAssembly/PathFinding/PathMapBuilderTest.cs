using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.PathFinding.Tests
{
    public class PathMapBuilderTest
    {
        PathMapBuilder pathMapBuilder = new();
        [Test]
        public void FillMap_ShouldFillTheMapToTheSpecifiedPercentage()
        {
            // Arrange
            List<Vector3> mapTotal = new List<Vector3>();
            float mapTotalFillPercentage = 0.5f;
            Vector3[] grid = new Vector3[]
            {
                new Vector3(1, 2, 3),
                new Vector3(4, 5, 6),
                new Vector3(7, 8, 9)
            };
            float gridScale = 1.0f;
            Vector3[] mapGrid = new Vector3[]
            {
                new Vector3(10, 11, 12),
                new Vector3(13, 14, 15),
                new Vector3(16, 17, 18)
            };

            // Act
            pathMapBuilder.FillMap(mapTotal, mapTotalFillPercentage, grid, gridScale, mapGrid);

            // Assert
            Assert.That(mapTotal.Count, Is.EqualTo(3));
        }
        [Test]
        public void MapTotal_ShouldReturnAListOfAllVectorsInTheMapGrid()
        {
            // Arrange
            Vector3[] mapGrid = new Vector3[]
            {
                new Vector3(1, 2, 3),
                new Vector3(4, 5, 6),
                new Vector3(7, 8, 9)
            };
            // Act
            List<Vector3> mapTotal = pathMapBuilder.MapTotal(mapGrid);
            // Assert
            Assert.That(mapTotal.Count, Is.EqualTo(3));
            Assert.That(mapTotal.All(p => p.x == 1 || p.x == 4 || p.x == 7));
            Assert.That(mapTotal.All(p => p.y == 2 || p.y == 5 || p.y == 8));
            Assert.That(mapTotal.All(p => p.z == 3 || p.z == 6 || p.z == 9));
        }
        [TestCase(GridTypeEnum.ThreeDimention)]
        [TestCase(GridTypeEnum.TwoDimentionHorizontal)]
        [TestCase(GridTypeEnum.TwoDimentionVertical)]
        public void CreateMap_ShouldCreateAMapWithTheSpecifiedSizeAndFillPercentage(GridTypeEnum gridType)
        {
            // Arrange
            int gridSize = 3;
            float gridScale = 1.0f;
            GameObject gridParent = new();
            DirectionalTilesScriptableObject scriptRef = new DirectionalTilesScriptableObject();
            int mapTotalFillPercentage = 1;
            // Act
            pathMapBuilder.CreateMap(gridSize, gridScale, gridParent.transform, scriptRef, mapTotalFillPercentage, gridType);
            // Assert
            Assert.Pass();


        }
    }
}