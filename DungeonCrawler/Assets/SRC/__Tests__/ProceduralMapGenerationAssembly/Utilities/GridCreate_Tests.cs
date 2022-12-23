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

namespace Assets.SRC.ProceduralMapGeneration.Utilities.Tests
{
    public class GridCreate_Tests
    {
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(14, 0.5f)]
        [TestCase(16, 22.34f)]
        public void Validate_2DGridCreations_EntityCount_Vertical(int gridSize, float scale)
           => GridCreate.SquareGrid2DVertical(gridSize, scale).Count<Vector3>().Should().Be((gridSize * gridSize));
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(14, 0.5f)]
        [TestCase(16, 22.34f)]
        public void Validate_2DGridCreations_EntityCount_Horizontal(int gridSize, float scale)
           => GridCreate.SquareGrid2DHorizontal(gridSize, scale).Count<Vector3>().Should().Be((gridSize * gridSize));
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(14, 0.5f)]
        [TestCase(16, 22.34f)]
        public void Validate_3DGridCreations_EntityCount(int gridSize, float scale)
            => GridCreate.SquareGrid3D(gridSize, scale).Count<Vector3>().Should().Be((gridSize * gridSize * gridSize));
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(14, 0.5f)]
        [TestCase(16, 22.34f)]
        public void Validate_FindChunkNeigbors(int gridSize, float scale)
        {
            Assert.Fail();
            //var result = GridCreate.SquareGrid2DVertical(gridSize, scale);
            //for (int i = 0; i < result.Count<Vector3>(); i++)
            //{
            //   var t= result[i];               
            //}
        }
        [Test]
        public void Validate_AssignDirectionIDAccordingToPresentNeighbors(List<NeighborStruct> objects)
        {
            Assert.Fail();
        }
        public void Validate_FindChunkType()
        {
            Assert.Fail();
        }
    }
}
