
using Assets.SRC.Tests.Assets.SRC.__Tests__.ProceduralMapGenerationAssembly.Mocs;
using FluentAssertions;
using NUnit.Framework;

namespace Assets.SRC.ProceduralMapGeneration.Utilities.Test
{
    public class GenericUtilities_Tests
    {
        private GenericUtilities_Mocs _genericUtilities_Mocs;
        #region [SetUp]&&[TearDown]
        [SetUp]
        public void SetUp()
        {
            _genericUtilities_Mocs = new GenericUtilities_Mocs();
        }

        [TearDown]
        public void TearDown()
        {
            _genericUtilities_Mocs = null;
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
            //var result = GenericUtilities.NeighborsPosition(scale);
            //result.Should().BeEquivalentTo(_genericUtilities_Mocs.SetUpNeighbors(scale));
            Assert.Fail();
        }
    }
}

