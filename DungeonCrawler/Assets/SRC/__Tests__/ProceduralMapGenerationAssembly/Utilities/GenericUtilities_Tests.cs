
using NUnit.Framework;
using FluentAssertions;
using UnityEngine;
using Assets.SRC.Tests.Assets.SRC.__Tests__.ProceduralMapGenerationAssembly.Mocs;
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
using Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Utilities.Tests;

namespace Assets.SRC.ProceduralMapGeneration.Utilities.Test
{
    public class GenericUtilities_Tests
    {
        private GenericUtilities_Mocs _genericUtilities_Mocs;
        #region [SetUp]&&[TearDown]
        [SetUp]
        public void SetUp()
        {
            _genericUtilities_Mocs= new GenericUtilities_Mocs();
        }

        [TearDown]
        public void TearDown()
        {
            _genericUtilities_Mocs= null;
        }
        #endregion

        #region Validate_NeighborsPosition Test Cases
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(25)]
        [TestCase(44.2f)]
        #endregion
        public void Validate_NeighborsPosition(float scale)
        {
            var result = GenericUtilities.NeighborsPosition(scale);
            result.Should().BeEquivalentTo(_genericUtilities_Mocs.SetUpNeighbors(scale));
        }
    }
}

