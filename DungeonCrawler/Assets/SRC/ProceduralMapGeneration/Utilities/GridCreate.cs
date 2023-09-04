using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Global;
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
        public Vector3[] CreateGrid()
        {
            // Switch on the grid type.
            switch (GlobalVariables.CreationModel.GridType)
            {
                // Create a 2D vertical grid.
                case GridTypeEnum.TwoDimentionVertical:
                    return SquareGrid2DVertical();

                // Create a 2D horizontal grid.
                case GridTypeEnum.TwoDimentionHorizontal:
                    return SquareGrid2DHorizontal();

                // Create a 3D grid.
                case GridTypeEnum.ThreeDimention:
                    return SquareGrid3D();

                // The default case.
                default:
                    throw new ArgumentOutOfRangeException(nameof(GlobalVariables.CreationModel.GridSize), "GridType not set");
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
        public Vector3[] SquareGrid2DVertical()
        {
            // Create a list to store the grid points.
            GlobalVariables.CreationModel.CreatedGridTransforms = new List<Vector3>();

            // Iterate through the grid.
            for (int X = 0; X < GlobalVariables.CreationModel.GridSize; X++)
            {
                for (int Y = 0; Y < GlobalVariables.CreationModel.GridSize; Y++)
                {
                    // Create a new grid point.
                    var t = new Vector3(
                        (X - GlobalVariables.CreationModel.GridSize / 2) * GlobalVariables.CreationModel.GridScale,
                        (Y - GlobalVariables.CreationModel.GridSize / 2) * GlobalVariables.CreationModel.GridScale,
                        0);

                    // Add the grid point to the list.
                    GlobalVariables.CreationModel.CreatedGridTransforms.Add(t);
                }
            }

            // Return the list of grid points.
            return GlobalVariables.CreationModel.CreatedGridTransforms.ToArray();
        }

        /**
         * Creates a 2D horizontal grid of the specified size and scale.
         *
         * @param gridSize The size of the grid.
         * @param scale The scale of the grid.
         *
         * @return The grid points.
         */
        public Vector3[] SquareGrid2DHorizontal()
        {
            // Create a list to store the grid points.
            GlobalVariables.CreationModel.CreatedGridTransforms = new List<Vector3>();

            // Get the center of the grid.
            var centre = GlobalVariables.CreationModel.GridSize / 2;

            // Iterate through the grid.
            for (int X = 0; X < GlobalVariables.CreationModel.GridSize; X++)
            {
                for (int Y = 0; Y < GlobalVariables.CreationModel.GridSize; Y++)
                {
                    // Create a new grid point.
                    var t = new Vector3(
                        (X - centre) * GlobalVariables.CreationModel.GridScale,
                        0,
                        (Y - centre) * GlobalVariables.CreationModel.GridScale);

                    // Add the grid point to the list.
                    GlobalVariables.CreationModel.CreatedGridTransforms.Add(t);
                }
            }

            // Return the list of grid points.
            return GlobalVariables.CreationModel.CreatedGridTransforms.ToArray();
        }

        /**
         * Creates a 3D grid of the specified size and scale.
         *
         * @param gridSize The size of the grid.
         * @param scale The scale of the grid.
         *
         * @return The grid points.
         */
        public Vector3[] SquareGrid3D()
        {
            // Create a list to store the grid points.
            GlobalVariables.CreationModel.CreatedGridTransforms = new List<Vector3>();

            // Iterate through the grid.
            for (int X = 0; X < GlobalVariables.CreationModel.GridSize; X++)
            {
                for (int Y = 0; Y < GlobalVariables.CreationModel.GridSize; Y++)
                {
                    for (int Z = 0; Z < GlobalVariables.CreationModel.GridSize; Z++)
                    {
                        // Create a new grid point.
                        var t = new Vector3(
                            (X - GlobalVariables.CreationModel.GridSize / 2) * GlobalVariables.CreationModel.GridScale,
                            (Y - GlobalVariables.CreationModel.GridSize / 2) * GlobalVariables.CreationModel.GridScale,
                            (Z - GlobalVariables.CreationModel.GridSize / 2) * GlobalVariables.CreationModel.GridScale);

                        // Add the grid point to the list.
                        GlobalVariables.CreationModel.CreatedGridTransforms.Add(t);
                    }
                }
            }

            // Return the list of grid points.
            return GlobalVariables.CreationModel.CreatedGridTransforms.ToArray();
        }

        /**
         * Places a GameObject at each grid point.
         *
         * @param grid The grid points.
         * @param gridParent The parent transform for the GameObjects.
         *
         * @return The list of GameObjects.
         */
        public List<GameObject> PlaceGameObjectsAtGridPositions()
        {
            // Create a list to store the GameObjects.
            GlobalVariables.CreationModel.GridRelations = new List<GameObject>(GlobalVariables.CreationModel.Grid.Length);

            // Iterate through the grid.
            for (int i = 0; i < GlobalVariables.CreationModel.Grid.Length; i++)
            {
                // Create a new GameObject.
                var g = new GameObject();

                // Set the position of the GameObject.
                g.transform.position = GlobalVariables.CreationModel.Grid[i];

                // Set the parent of the GameObject.
                g.transform.parent = GlobalVariables.CreationModel.GridParent.transform;

                // Add the GameObject to the list.
                GlobalVariables.CreationModel.GridRelations.Add(g);
            }

            // Return the list of GameObjects.
            return GlobalVariables.CreationModel.GridRelations;
        }
    }
}