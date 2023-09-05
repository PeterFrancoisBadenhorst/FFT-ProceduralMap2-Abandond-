//using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Noise;
//using FluentAssertions;
//using NUnit.Framework;
//using UnityEngine;

//namespace Assets.SRC.ProceduralMapGeneration.Noise.Tests
//{
//    public class Test_PerlinNoiseGenerator
//    {
//        private readonly PerlinNoiseGenerator generator = new();

//        [Test]
//        public void GeneratePerlinNoise2DTexture_Test()
//        {
//            // Arrange
//            int size = 100;
//            float scale = 1.0f;

//            // Act
//            Texture2D noiseTexture2D = generator.GeneratePerlinNoise2DTexture(size, scale);

//            // Assert
//            noiseTexture2D.width.Should().Be(size);
//            noiseTexture2D.height.Should().Be(size);
//        }
//    }
//}