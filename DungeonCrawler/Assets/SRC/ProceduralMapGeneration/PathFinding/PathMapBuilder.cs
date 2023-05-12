using UnityEngine;

namespace PathFinding
{
    public class PathMapBuilder
    {
        private List<GameObject> gridRelations = new List<GameObject>();

        private readonly PopulateTilePositions _populateTilePositionsBehavior = new PopulateTilePositions();
        private readonly GridCreate _gridCreate = new GridCreate();
        private readonly ChunkHandler _chunkHandler = new ChunkHandler();
        private readonly NewPathFinding _newPathFinding = new NewPathFinding();

        public void CreateMap(int iterations, int gridSize, float gridScale, Transform gridParent, DirectionalTilesScriptableObject scriptRef)
        {
            gridRelations.Clear();

            // Create the grid.
            Vector3[] grid = _gridCreate.SquareGrid2DHorizontal(gridSize, gridScale);

            // Create the map grid.
            Vector3[] mapGrid = _newPathFinding.NodeGridCreator(grid, gridScale);

            // Create a list of all the map positions.
            List<Vector3> mapPositions = new List<Vector3>(mapGrid.Length);
            for (int i = 0; i < mapGrid.Length; i++)
            {
                mapPositions.Add(mapGrid[i]);
            }

            // Create a list of all the objects.
            List<object> objects = new List<object>();

            // Iterate over the iterations.
            for (int h = 0; h < iterations; h++)
            {
                // Create a list of positions for the current iteration.
                List<Vector3> positions = new List<Vector3>();

                // Create the node grid for the current iteration.
                var temp = _newPathFinding.NodeGridCreator(grid, mapPositions, gridScale);

                // Add the positions to the list of positions.
                for (int g = 0; g < temp.Length; g++)
                {
                    positions.Add(temp[g]);
                }

                // Add the list of positions to the list of objects.
                objects.Add(positions);
            }

            // Get the distinct positions from the list of objects.
            mapGrid = mapPositions.Distinct().ToArray();

            // Place the GameObjects at the grid positions.
            gridRelations = _gridCreate.PlaceGameObjectsAtGridPositions(mapGrid, gridParent);

            // Find the chunk neighbors.
            gridRelations = _chunkHandler.FindChunkNeigbors(gridScale, gridRelations);

            // Assign the chunk types.
            gridRelations = _chunkHandler.AssignChunkTypes(gridRelations);

            // Set the child tiles.
            _populateTilePositionsBehavior.SetChildTile(scriptRef, gridRelations);
        }
    }
}
