using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding
{
    /// <summary>
    /// H Cost => Diff to neighbors
    /// F Cost => Diff to end point
    /// ToDo:
    ///  Get grid
    ///  create node per pos in grid -
    ///  Set Neighbors of Nodes -
    ///  end-start node chooser -
    ///  Itterate through Neighbors to get to end node -
    ///  Return Array of positions to use -
    ///
    ///
    /// Issue : getting Null Ref in   GetNextNode @   node.Neighbors.Count;
    /// </summary>
    public partial class NewPathFinding
    {
        /// <summary>
        /// This method finds the start and end points of the path.
        /// </summary>
        /// <param name="grid">The grid of points.</param>
        /// <returns>An array of Vector3 objects representing the start and end points.</returns>
        public Vector3[] FindEnds(Vector3[] grid)
        {
            Vector3[] pos;
            do
            {
                pos = new Vector3[]
                {
                    (grid[random.Next(0, grid.Length)]),
                    (grid[random.Next(0, grid.Length)])
                };
            } while (pos[0] == pos[1]);
            {
                pos = new Vector3[]
               {
                    (grid[random.Next(0, grid.Length)]),
                    (grid[random.Next(0, grid.Length)])
               };
            }
            return pos;
        }
    }
}
