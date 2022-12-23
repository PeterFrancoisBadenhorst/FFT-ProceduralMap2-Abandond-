
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
                    Vector3.down* scale,
                    Vector3.back* scale,
                    Vector3.up* scale,
                    Vector3.down* scale
                 };
        }


        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        public void NeighborsPosition(float scale)
        {
            var result = GenericUtilities.NeighborsPosition(scale);
            result.Should().BeEquivalentTo(SetUpNeighbors(scale));
        }
    }
}

/*
   public static Vector3[] NeighborsPosition(float scale)
        {
            var top = Vector3.up * scale;
            var bottom = Vector3.down * scale;
            var north = Vector3.right * scale;
            var east = Vector3.forward * scale;
            var west = Vector3.back * scale;
            var south = -Vector3.left * scale;

            return new Vector3[] { north, east, south, west, top, bottom };
        }
 */