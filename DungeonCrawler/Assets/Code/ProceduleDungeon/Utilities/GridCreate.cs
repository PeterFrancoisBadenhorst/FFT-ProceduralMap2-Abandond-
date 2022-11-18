using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.ProceduleDungeon.Utilities
{
    internal class GridCreate
    {
        public static Vector3[] SquareGrid2DVertical(int gridSize, float scale)
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
        public static Vector3[] SquareGrid2DHorizontal(int gridSize, float scale)
        {
            var createdTransforms = new List<Vector3>();
            for (int X = 0; X < gridSize; X++)
            {
                for (int Y = 0; Y < gridSize; Y++)
                {
                    var t = new Vector3(
                        (X - gridSize / 2) * scale,
                        0,
                       (Y - gridSize / 2) * scale);
                    createdTransforms.Add(t);
                }
            }
            return createdTransforms.ToArray();
        }
        public static Vector3[] SquareGrid3D(int gridSize, float scale)
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
    }
}
