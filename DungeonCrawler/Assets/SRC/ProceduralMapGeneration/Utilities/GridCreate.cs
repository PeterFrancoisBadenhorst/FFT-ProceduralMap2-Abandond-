using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    public class GridCreate
    {
        public Vector3[] CreateGrid(int gridSize, float scale, GridTypeEnum gridType) => gridType switch
        {
            GridTypeEnum.TwoDimentionVertical => SquareGrid2DVertical(gridSize, scale),
            GridTypeEnum.TwoDimentionHorizontal => SquareGrid2DHorizontal(gridSize, scale),
            GridTypeEnum.ThreeDimention => SquareGrid3D(gridSize, scale),
            _ => throw new ArgumentOutOfRangeException(nameof(gridType), "GridType not set")
        };

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

        public List<GameObject> PlaceGameObjectsAtGridPositions(Vector3[] grid, Transform gridParent)//
        {
            List<GameObject> gameObjects =new(grid.Length);
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