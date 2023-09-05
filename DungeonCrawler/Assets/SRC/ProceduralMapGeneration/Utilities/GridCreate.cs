using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    public class GridCreate
    {
        /**
         * Creates a grid of the specified size, scale, and grid type.
         *
         * @param gridSize The size of the grid.
         * @param scale The scale of the grid.
         * @param gridType The type of grid to create.
         *
         * @return The grid points.
         */
        public Vector3[] CreateGrid(int gridSize, float scale, GridTypeEnum gridType)
        {
            // Switch on the grid type.
            switch (gridType)
            {
                // Create a 2D vertical grid.
                case GridTypeEnum.TwoDimentionVertical:
                    return SquareGrid2DVertical(gridSize, scale);

                // Create a 2D horizontal grid.
                case GridTypeEnum.TwoDimentionHorizontal:
                    return SquareGrid2DHorizontal(gridSize, scale);

                // Create a 3D grid.
                case GridTypeEnum.ThreeDimention:
                    return SquareGrid3D(gridSize, scale);

                // The default case.
                default:
                    throw new ArgumentOutOfRangeException(nameof(gridType), "GridType not set");
            }
        }

        /**
         * Creates a 2D vertical grid of the specified size and scale.
         *
         * @param gridSize The size of the grid.
         * @param scale The scale of the grid.
         *
         * @return The grid points.
         */
        public Vector3[] SquareGrid2DVertical(int gridSize, float scale)
        {
            // Create a list to store the grid points.
            var createdTransforms = new List<Vector3>();

            // Iterate through the grid.
            for (int X = 0; X < gridSize; X++)
            {
                for (int Y = 0; Y < gridSize; Y++)
                {
                    // Create a new grid point.
                    var t = new Vector3((X - gridSize / 2) * scale, (Y - gridSize / 2) * scale, 0);

                    // Add the grid point to the list.
                    createdTransforms.Add(t);
                }
            }

            // Return the list of grid points.
            return createdTransforms.ToArray();
        }

        /**
         * Creates a 2D horizontal grid of the specified size and scale.
         *
         * @param gridSize The size of the grid.
         * @param scale The scale of the grid.
         *
         * @return The grid points.
         */
        public Vector3[] SquareGrid2DHorizontal(int gridSize, float scale)
        {
            // Create a list to store the grid points.
            var createdTransforms = new List<Vector3>();

            // Get the center of the grid.
            var centre = gridSize / 2;

            // Iterate through the grid.
            for (int X = 0; X < gridSize; X++)
            {
                for (int Y = 0; Y < gridSize; Y++)
                {
                    // Create a new grid point.
                    var t = new Vector3((X - centre) * scale, 0, (Y - centre) * scale);

                    // Add the grid point to the list.
                    createdTransforms.Add(t);
                }
            }

            // Return the list of grid points.
            return createdTransforms.ToArray();
        }

        /**
         * Creates a 3D grid of the specified size and scale.
         *
         * @param gridSize The size of the grid.
         * @param scale The scale of the grid.
         *
         * @return The grid points.
         */
        public Vector3[] SquareGrid3D(int gridSize, float scale)
        {
            // Create a list to store the grid points.
            var createdTransforms = new List<Vector3>();

            // Iterate through the grid.
            for (int X = 0; X < gridSize; X++)
            {
                for (int Y = 0; Y < gridSize; Y++)
                {
                    for (int Z = 0; Z < gridSize; Z++)
                    {
                        // Create a new grid point.
                        var t = new Vector3((X - gridSize / 2) * scale, (Y - gridSize / 2) * scale, (Z - gridSize / 2) * scale);

                        // Add the grid point to the list.
                        createdTransforms.Add(t);
                    }
                }
            }

            // Return the list of grid points.
            return createdTransforms.ToArray();
        }

        /**
         * Places a GameObject at each grid point.
         *
         * @param grid The grid points.
         * @param gridParent The parent transform for the GameObjects.
         *
         * @return The list of GameObjects.
         */
        public List<GameObject> PlaceGameObjectsAtGridPositions(Vector3[] grid, Transform gridParent)
        {
            // Create a list to store the GameObjects.
            List<GameObject> gameObjects = new List<GameObject>(grid.Length);

            // Iterate through the grid.
            for (int i = 0; i < grid.Length; i++)
            {
                // Create a new GameObject.
                var g = new GameObject();

                // Set the position of the GameObject.
                g.transform.position = grid[i];

                // Set the parent of the GameObject.
                g.transform.parent = gridParent;

                // Add the GameObject to the list.
                gameObjects.Add(g);
            }

            // Return the list of GameObjects.
            return gameObjects;
        }
    }
}