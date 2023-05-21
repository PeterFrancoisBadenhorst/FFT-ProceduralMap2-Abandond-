using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    public class GridCreate
    {
        /// <summary>
        /// This method returns a list of Vector3 objects that represent the positions of a 2D square grid.
        /// </summary>
        /// <param name="gridSize">The size of the grid.</param>
        /// <param name="scale">The scale of the grid.</param>
        /// <returns>A list of Vector3 objects that represent the positions of a 2D square grid.</returns>
        /// <remarks>
        /// The method iterates over the grid and returns the position of each tile. The scale is used to adjust the size of the tiles.
        /// </remarks>
        public Vector3[] SquareGrid2DVertical(int gridSize, float scale)
        {
            var createdTransforms = new List<Vector3>();
            for (int X = 0; X < gridSize; X++)
            {
                for (int Y = 0; Y < gridSize; Y++)
                {
                    var t = new Vector3(
                        (X - gridSize / 2) * scale,
                        (Y - gridSize / 2) * scale,
                        0);
                    createdTransforms.Add(t);
                }
            }
            return createdTransforms.ToArray();
        }

        /// <summary>
        /// This method returns a list of Vector3 objects that represent the positions of a 2D square grid.
        /// </summary>
        /// <param name="gridSize">The size of the grid.</param>
        /// <param name="scale">The scale of the grid.</param>
        /// <returns>A list of Vector3 objects that represent the positions of a 2D square grid.</returns>
        /// <remarks>
        /// The method iterates over the grid and returns the position of each tile. The scale is used to adjust the size of the tiles. The grid is created horizontally, with the origin at the center of the grid.
        /// </remarks>
        public Vector3[] SquareGrid2DHorizontal(int gridSize, float scale)
        {
            var createdTransforms = new List<Vector3>();
            var centre = gridSize / 2;
            for (int X = 0; X < gridSize; X++)
            {
                for (int Y = 0; Y < gridSize; Y++)
                {
                    var t = new Vector3(
                        (X - centre) * scale,
                        0,
                       (Y - centre) * scale
                       );
                    createdTransforms.Add(t);
                }
            }
            return createdTransforms.ToArray();
        }

        /// <summary>
        /// This method returns a list of Vector3 objects that represent the positions of a 3D square grid.
        /// </summary>
        /// <param name="gridSize">The size of the grid.</param>
        /// <param name="scale">The scale of the grid.</param>
        /// <returns>A list of Vector3 objects that represent the positions of a 3D square grid.</returns>
        /// <remarks>
        /// The method iterates over the grid and returns the position of each tile. The scale is used to adjust the size of the tiles. The grid is created with the origin at the center of the grid.
        /// </remarks>
        public Vector3[] SquareGrid3D(int gridSize, float scale)
        {
            var createdTransforms = new List<Vector3>();
            for (int X = 0; X < gridSize; X++)
            {
                for (int Y = 0; Y < gridSize; Y++)
                {
                    for (int Z = 0; Z < gridSize; Z++)
                    {
                        var t = new Vector3(
                             (X - gridSize / 2) * scale,
                             (Y - gridSize / 2) * scale,
                             (Z - gridSize / 2) * scale);
                        createdTransforms.Add(t);
                    }
                }
            }
            return createdTransforms.ToArray();
        }

        /// <summary>
        /// This method places a list of game objects at the specified grid positions.
        /// </summary>
        /// <param name="grid">The grid positions.</param>
        /// <param name="gridParent">The parent transform of the game objects.</param>
        /// <returns>A list of game objects that were placed at the grid positions.</returns>
        /// <remarks>
        /// The method iterates over the grid and creates a new game object for each position. The game objects are then placed at the specified positions and their parent transform is set to the gridParent transform.
        /// </remarks>
        public List<GameObject> PlaceGameObjectsAtGridPositions(Vector3[] grid, Transform gridParent)//
        {
            List<GameObject> gameObjects = new List<GameObject>(grid.Length);
            for (int i = 0; i < grid.Length; i++)
            {
                var g = new GameObject();
                g.transform.position = grid[i];
                g.transform.parent = gridParent;
                gameObjects.Add(g);
            }
            return gameObjects;
        }
    }
}