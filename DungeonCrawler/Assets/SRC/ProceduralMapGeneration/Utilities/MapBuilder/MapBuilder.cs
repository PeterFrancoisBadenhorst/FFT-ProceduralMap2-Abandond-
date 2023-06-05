using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    internal class MapBuilder
    {
        private static MapBuilderStruct dataKeeper = new MapBuilderStruct();

        /// <summary>
        /// This method chooses a random tile from the specified grid to be the start tile.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <returns>A list of game objects that contains the start tile.</returns>
        /// <remarks>
        /// The method creates a new System.Random object and then uses it to choose a random index from the grid. The start tile is then set to the game object at the specified index.
        /// </remarks>
        public List<GameObject> ChooseStartTile(List<GameObject> grid)
        {
            dataKeeper.grid = grid;
            var random = new System.Random();
            dataKeeper.startObject = grid[random.Next(grid.Count)];
            return grid;
        }

        /// <summary>
        /// Collapses a tile in the specified grid.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <param name="tile">The tile to collapse.</param>
        /// <returns>A list of game objects that contains the collapsed tile.</returns>
        /// <remarks>
        /// The method gets the ChunkBehavior component from the tile and then calls its Collapse() method.
        /// </remarks>
        public List<GameObject> CollapseTile(List<GameObject> grid, GameObject tile)
        {
            var t = tile.GetComponent<ChunkBehavior>();
            return grid;
        }
    }
}