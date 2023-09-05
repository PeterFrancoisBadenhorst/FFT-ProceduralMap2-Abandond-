//using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
//using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
//using FluentAssertions;
//using NUnit.Framework;
//using System.Collections.Generic;
//using UnityEngine;

//namespace Assets.SRC.ProceduralMapGeneration.Generic.Tests
//{
//    public class Test_Structs
//    {
//        [TestFixture]
//        public class DirectionIDStructTests
//        {
//            [Test]
//            public void Should_Have_Correct_Default_Values()
//            {
//                // Arrange
//                var directionIDStruct = new DirectionIDStruct();

//                // Act

//                // Assert
//                directionIDStruct.NothID.Should().BeFalse();
//                directionIDStruct.EastID.Should().BeFalse();
//                directionIDStruct.WestID.Should().BeFalse();
//                directionIDStruct.SouthID.Should().BeFalse();
//                directionIDStruct.TopID.Should().BeFalse();
//                directionIDStruct.BottomID.Should().BeFalse();
//            }

//            [Test]
//            public void Should_Be_Able_To_Set_And_Get_Values()
//            {
//                // Arrange
//                DirectionIDStruct directionIDStruct = new();

//                // Act
//                directionIDStruct.NothID = true;
//                directionIDStruct.EastID = true;
//                directionIDStruct.WestID = true;
//                directionIDStruct.SouthID = true;
//                directionIDStruct.TopID = true;
//                directionIDStruct.BottomID = true;

//                // Assert
//                directionIDStruct.NothID.Should().BeTrue();
//                directionIDStruct.EastID.Should().BeTrue();
//                directionIDStruct.WestID.Should().BeTrue();
//                directionIDStruct.SouthID.Should().BeTrue();
//                directionIDStruct.TopID.Should().BeTrue();
//                directionIDStruct.BottomID.Should().BeTrue();
//            }
//        }

//        [TestFixture]
//        public class MapBuilderStructTests
//        {
//            [Test]
//            public void Should_Have_Correct_Default_Values()
//            {
//                // Arrange
//                var mapBuilderStruct = new MapBuilderStruct();

//                // Act

//                // Assert
//                mapBuilderStruct.grid.Should().BeNullOrEmpty();
//                mapBuilderStruct.startObject.Should().BeNull();
//                mapBuilderStruct.previousTilePos.Should().BeNull();
//            }

//            [Test]
//            public void Should_Be_Able_To_Set_And_Get_Values()
//            {
//                // Arrange
//                var mapBuilderStruct = new MapBuilderStruct();

//                // Act
//                var grid = new List<GameObject>();
//                var startObject = new GameObject();
//                var previousTilePos = new GameObject();

//                mapBuilderStruct.grid = grid;
//                mapBuilderStruct.startObject = startObject;
//                mapBuilderStruct.previousTilePos = previousTilePos;

//                // Assert
//                mapBuilderStruct.grid.Should().BeEquivalentTo(grid);
//                mapBuilderStruct.startObject.Should().BeEquivalentTo(startObject);
//                mapBuilderStruct.previousTilePos.Should().BeEquivalentTo(previousTilePos);
//            }
//        }

//        [TestFixture]
//        public class NeighborStructTests
//        {
//            [Test]
//            public void Should_Have_Correct_Default_Values()
//            {
//                // Arrange
//                var neighborStruct = new NeighborStruct();

//                // Act

//                // Assert

//                neighborStruct.OriginObject.Should().BeNull();
//                neighborStruct.NorthNeighbor.Should().BeNull();
//                neighborStruct.EastNeighbor.Should().BeNull();
//                neighborStruct.SouthNeighbor.Should().BeNull();
//                neighborStruct.WestNeighbor.Should().BeNull();
//                neighborStruct.TopNeighbor.Should().BeNull();
//                neighborStruct.BottomNeighbor.Should().BeNull();
//            }

//            [Test]
//            public void Should_Be_Able_To_Set_And_Get_Values()
//            {
//                // Arrange
//                var neighborStruct = new NeighborStruct();

//                // Act
//                var direction = DirectionTypeEnum.N;
//                var originObject = new GameObject();
//                var northNeighbor = new GameObject();
//                var eastNeighbor = new GameObject();
//                var southNeighbor = new GameObject();
//                var westNeighbor = new GameObject();
//                var topNeighbor = new GameObject();
//                var bottomNeighbor = new GameObject();

//                neighborStruct.Direction = direction;
//                neighborStruct.OriginObject = originObject;
//                neighborStruct.NorthNeighbor = northNeighbor;
//                neighborStruct.EastNeighbor = eastNeighbor;
//                neighborStruct.SouthNeighbor = southNeighbor;
//                neighborStruct.WestNeighbor = westNeighbor;
//                neighborStruct.TopNeighbor = topNeighbor;
//                neighborStruct.BottomNeighbor = bottomNeighbor;

//                // Assert

//                neighborStruct.OriginObject.Should().BeEquivalentTo(originObject);
//                neighborStruct.NorthNeighbor.Should().BeEquivalentTo(northNeighbor);
//                neighborStruct.EastNeighbor.Should().BeEquivalentTo(eastNeighbor);
//                neighborStruct.SouthNeighbor.Should().BeEquivalentTo(southNeighbor);
//                neighborStruct.WestNeighbor.Should().BeEquivalentTo(westNeighbor);
//                neighborStruct.TopNeighbor.Should().BeEquivalentTo(topNeighbor);
//                neighborStruct.BottomNeighbor.Should().BeEquivalentTo(bottomNeighbor);
//            }
//        }
//    }
//}