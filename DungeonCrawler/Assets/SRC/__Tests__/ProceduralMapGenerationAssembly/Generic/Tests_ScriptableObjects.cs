using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Assets.SRC.ProceduralMapGeneration.Generic.Tests
{
	public class Test_ScriptableObjects
	{
		[Test]
		public void Should_Return_A_List_Of_GameObjects()
		{
			// Arrange
			var directionalTilesScriptableObject = new DirectionalTilesScriptableObject();

			// Act
			var listOfGameObjects = directionalTilesScriptableObject.RetunObjectsAsAList();

			// Assert
			listOfGameObjects.Should().HaveCount(63);
		}	
	}
}