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
        /// This method gets the next node in the path from the given node.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <returns>The next node in the path.</returns>
        private NewNode GetNextNode(NewNode node)
        {
            float dis = float.MaxValue;
            NewNode returnedNode = null;
            var t = node.Neighbors.Count;

            for (int i = 0; i < t; i++)
            {
                if (node.Neighbors[i].fCost <= dis)
                {
                    dis = node.Neighbors[i].fCost;
                    returnedNode = node.Neighbors[i];
                }
            }

            returnedNode.LastNode = node;
            return returnedNode;
        }
    }
}