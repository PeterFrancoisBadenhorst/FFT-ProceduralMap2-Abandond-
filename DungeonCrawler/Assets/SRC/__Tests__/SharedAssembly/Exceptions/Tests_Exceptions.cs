using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Assets.SRC.Shared.Utilities;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using System;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Exceptions;

namespace Assets.SRC.ProceduralMapGeneration.Generic.Tests
{
    public class Tests_Exceptions
    {
        [Test]
        public void NotImplementedException_ShouldThrowNotImplementedException()
        {
            CustomExceptions mesh = new CustomExceptions();

            Assert.Throws<NotImplementedException>(
                () => mesh.NotImplementedException());
        }
    }
}