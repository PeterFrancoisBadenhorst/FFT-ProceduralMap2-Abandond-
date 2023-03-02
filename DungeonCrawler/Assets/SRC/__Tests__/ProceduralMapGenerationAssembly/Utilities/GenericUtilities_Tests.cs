using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Noise;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Managers;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.Tests.Assets.SRC.__Tests__.ProceduralMapGenerationAssembly.Mocs;
using FluentAssertions;
using NUnit.Framework;
using System.Numerics;

namespace Assets.SRC.ProceduralMapGeneration.Utilities.Test
{
    public class GenericUtilities_Tests
    {
        private GenericUtilities_Mocs _genericUtilities_Mocs;
        private GenericUtilities _genericUtilities;
        #region [SetUp]&&[TearDown]
        [SetUp]
        public void SetUp()
        {
            _genericUtilities_Mocs = new GenericUtilities_Mocs();
            _genericUtilities = new GenericUtilities();
        }

        [TearDown]
        public void TearDown()
        {
            _genericUtilities_Mocs = null;
            _genericUtilities = null;
        }
        #endregion

        #region Validate_NeighborsPosition Test Cases
        [TestCase(1, 1)]
        [TestCase(2, 5)]
        [TestCase(2, 15)]
        [TestCase(14, 0.5f)]
        [TestCase(16, 22.34f)]
        #endregion
        public void Validate_NeighborsPosition(float scale, float multiplyer)
        {
            var offset = UnityEngine.Vector3.one* multiplyer;
            var result = _genericUtilities.NeighborsPosition(scale, offset);
            // Length Check
            result.Length.Should().Be(6);
            // Null checks
            result[0].Should().NotBeNull();
            result[1].Should().NotBeNull();
            result[2].Should().NotBeNull();
            result[3].Should().NotBeNull();
            result[4].Should().NotBeNull();
            result[5].Should().NotBeNull();
            // position check
            result[0].Should().BeEquivalentTo((UnityEngine.Vector3.forward * scale) + offset);
            result[1].Should().BeEquivalentTo((UnityEngine.Vector3.right * scale) + offset);
            result[2].Should().BeEquivalentTo((UnityEngine.Vector3.back * scale) + offset);
            result[3].Should().BeEquivalentTo((UnityEngine.Vector3.left * scale) + offset);
            result[4].Should().BeEquivalentTo((UnityEngine.Vector3.up * scale) + offset);
            result[5].Should().BeEquivalentTo((UnityEngine.Vector3.down * scale) + offset);
        }
    }
}

