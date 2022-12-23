
using NUnit.Framework;
using FluentAssertions;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Utilities.Test
{
    public class GenericUtilities_Tests
    {
        private Vector3[] SetUpNeighbors(float scale)
        {

            return new Vector3[]
                {
                    Vector3.right* scale,
                    Vector3.forward * scale,
                    Vector3.left* scale,
                    Vector3.back* scale,
                    Vector3.up* scale,
                    Vector3.down* scale
                 };
        }


        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(25)]
        [TestCase(44.2f)]
        public void NeighborsPosition(float scale)
        {
            var result = GenericUtilities.NeighborsPosition(scale);
            result.Should().BeEquivalentTo(SetUpNeighbors(scale));
        }
    }
}

