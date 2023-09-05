//using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
//using FluentAssertions;
//using NUnit.Framework;
//using System;

//namespace Assets.SRC.ProceduralMapGeneration.Generic.Tests
//{
//    public class Test_Enums
//    {
//        [TestFixture]
//        public class GridTypeEnum_Tests
//        {
//            [Test]
//            public void Should_Have_3_Values()
//            {
//                // Arrange
//                GridTypeEnum[] enumValues = (GridTypeEnum[])Enum.GetValues(typeof(GridTypeEnum));

//                // Act
//                var count = enumValues.Length;

//                // Assert
//                count.Should().Be(3);
//            }

//            [Test]
//            public void Should_Have_The_Expected_Values()
//            {
//                // Arrange
//                GridTypeEnum[] enumValues = (GridTypeEnum[])Enum.GetValues(typeof(GridTypeEnum));

//                // Act
//                var expectedValues = new[]
//                {
//                    GridTypeEnum.TwoDimentionVertical,
//                    GridTypeEnum.TwoDimentionHorizontal,
//                    GridTypeEnum.TwoDimentionVertical
//                };
//                // Assert
//                foreach (var expectedValue in expectedValues)
//                {
//                    enumValues.Should().Contain(expectedValue);
//                }
//            }
//        }

//        [TestFixture]
//        public class DirectionTypeEnum_Tests
//        {
//            [Test]
//            public void Should_Have_28_Values()
//            {
//                // Arrange
//                DirectionTypeEnum[] enumValues = (DirectionTypeEnum[])Enum.GetValues(typeof(DirectionTypeEnum));

//                // Act
//                var count = enumValues.Length;

//                // Assert
//                count.Should().Be(67);
//            }

//            [Test]
//            public void Should_Have_The_Expected_Values()
//            {
//                // Arrange
//                DirectionTypeEnum[] directionTypeEnum = (DirectionTypeEnum[])Enum.GetValues(typeof(DirectionTypeEnum));

//                // Act
//                var expectedValues = new[]
//                {
//                DirectionTypeEnum.N,
//                DirectionTypeEnum.NE,
//                DirectionTypeEnum.NS,
//                DirectionTypeEnum.NW,
//                DirectionTypeEnum.NT,
//                DirectionTypeEnum.NB,
//                DirectionTypeEnum.NES,
//                DirectionTypeEnum.NESW,
//                DirectionTypeEnum.NEWTB,
//                DirectionTypeEnum.NESWT,
//                DirectionTypeEnum.EWTB,
//                DirectionTypeEnum.NESWB,
//                DirectionTypeEnum.NESWTB,
//                DirectionTypeEnum.NEW,
//                DirectionTypeEnum.NEWT,
//                DirectionTypeEnum.NEWB,
//                DirectionTypeEnum.NET,
//                DirectionTypeEnum.NETB,
//                DirectionTypeEnum.NEB,
//                DirectionTypeEnum.NEST,
//                DirectionTypeEnum.NESTB,
//                DirectionTypeEnum.NESB,
//                DirectionTypeEnum.NSW,
//                DirectionTypeEnum.NSWT,
//                DirectionTypeEnum.NSWB,
//                DirectionTypeEnum.NST,
//                DirectionTypeEnum.NSTB,
//                DirectionTypeEnum.NSB,
//                DirectionTypeEnum.NSWTB,
//                DirectionTypeEnum.NWT,
//                DirectionTypeEnum.NWTB,
//                DirectionTypeEnum.NWB,
//                DirectionTypeEnum.NTB,
//                DirectionTypeEnum.ES,
//                DirectionTypeEnum.ESW,
//                DirectionTypeEnum.ESWT,
//                DirectionTypeEnum.ESWB,
//                DirectionTypeEnum.ESWTB,
//                DirectionTypeEnum.EW,
//                DirectionTypeEnum.EWT,
//                DirectionTypeEnum.EWB,
//                DirectionTypeEnum.ET,
//                DirectionTypeEnum.ETB,
//                DirectionTypeEnum.EB,
//                DirectionTypeEnum.EST,
//                DirectionTypeEnum.ESTB,
//                DirectionTypeEnum.ESB,
//                DirectionTypeEnum.SW,
//                DirectionTypeEnum.SWT,
//                DirectionTypeEnum.SWB,
//                DirectionTypeEnum.ST,
//                DirectionTypeEnum.STB,
//                DirectionTypeEnum.SB,
//                DirectionTypeEnum.SWT,
//                DirectionTypeEnum.WT,
//                DirectionTypeEnum.WTB,
//                DirectionTypeEnum.WB,
//                DirectionTypeEnum.TB,
//                DirectionTypeEnum.S,
//                DirectionTypeEnum.E,
//                DirectionTypeEnum.W,
//                DirectionTypeEnum.T,
//                DirectionTypeEnum.B,
//                DirectionTypeEnum.Blank,
//                DirectionTypeEnum.Collapsed,
//                DirectionTypeEnum.Error,
//                DirectionTypeEnum.Start
//            };

//                // Assert
//                foreach (var expectedValue in expectedValues)
//                {
//                    directionTypeEnum.Should().Contain(expectedValue);
//                }
//            }
//        }
//    }
//}