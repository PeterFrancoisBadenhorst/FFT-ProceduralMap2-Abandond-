using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Assets.SRC.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding
{
    public class NewPathFinding
    {
        private readonly VectorMath vMath = new ();
        private readonly System.Random random = new();

        public List<NewNodeModel> SetNodeNeighbors(List<NewNodeModel> nodes, float scale)
        {
            List<NewNodeModel> setNodes = new();
            for (int i = 0; i < nodes.Count; i++)
            {
                var currentNode = nodes[i];
                currentNode.Neighbors = FindNeighbors(currentNode, nodes, scale);
                setNodes.Add(currentNode);
            }
            return setNodes.Distinct().ToList();
        }

        public static List<NewNodeModel> FindNeighbors(NewNodeModel node, List<NewNodeModel> nodes, float scale)
        {
            List<NewNodeModel> neighbors = new();
            for (int i = 0; i < nodes.Count; i++)
            {
                //IsNeighbor(node,)
                if (ComparePositions(node.Position, nodes[i].Position, scale))
                {
                    neighbors.Add(nodes[i]);
                }
            }

            return neighbors;
        }

        public static bool ComparePositions(Vector3 poasA, Vector3 posB, float multiplier)
        {
            Vector3[] directions = new Vector3[]
            {
                new Vector3(0, 1, 0) * multiplier+posB,
                new Vector3(0, 0, 1) * multiplier+posB,
                new Vector3(0, 0, -1) * multiplier+posB,
                new Vector3(0, -1, 0) * multiplier+posB,
                new Vector3(1, 0, 0) * multiplier+posB,
                new Vector3(-1, 0, 0) * multiplier+posB
            };

            for (int i = 0; i < directions.Length; i++)
            {
                if (poasA.x == directions[i].x &&
                    poasA.y == directions[i].y &&
                    poasA.z == directions[i].z)
                {
                    return true;
                }
            }
            return false;
        }

        public Vector3[] NodeGridCreator(Vector3[] grid, Vector3[] baseMap, float scale)
        {
            Vector3[] ends =
                {
                     (baseMap[random.Next(0, baseMap.Length)]),
                     (grid[random.Next(0, grid.Length)])
                 };
            return ReturnPath(grid, scale, ends);
        }

        public Vector3[] NodeGridCreator(Vector3[] grid, float scale)
        {
            var ends = FindEnds(grid);   //[0] start [1]end
            return ReturnPath(grid, scale, ends);
        }

        public List<NewNodeModel> CreateNodes(Vector3[] grid, Vector3 endPos)
        {
            List<NewNodeModel> nodes = new();

            for (int i = 0; i < grid.Length; i++)
            {
                NewNodeModel node = new()
                {
                    Position = grid[i]
                };
                node.fCost = vMath.CalculateDistanceBetweenTwoVectors(node.Position, endPos);
                nodes.Add(node);
            }

            return nodes;
        }

        public Vector3[] ReturnPath(Vector3[] grid, float scale, Vector3[] ends)
        {
            List<NewNodeModel> nodes = new();
            nodes = CreateNodes(grid, ends[1]);

            nodes = SetNodeNeighbors(nodes, scale);
            List<Vector3> path = Findpath(nodes, ends);

            return path.ToArray();
        }

        public List<Vector3> Findpath(List<NewNodeModel> grid, Vector3[] positions)
        {
            if (grid == null || grid.Count == 0) { throw new ArgumentNullException("grid"); }
            if (positions == null || positions.Length == 0) { throw new ArgumentNullException("grid"); }

            List<NewNodeModel> sortedListByPosition = new(grid);
            sortedListByPosition.Reverse();
            NewNodeModel startPos = sortedListByPosition.Find(node => node.Position == positions[0]);
            NewNodeModel endPos = sortedListByPosition.Find(node => node.Position == positions[1]);
            NewNodeModel activeNode = startPos;
            List<NewNodeModel> generatedList = new ();
            List<Vector3> convertedGeneratedList = new();

            activeNode = FindActiveNode(activeNode, endPos);
            generatedList = GeneratePath(activeNode, startPos);
            convertedGeneratedList = ConvertPathToPositions(generatedList);

            return convertedGeneratedList;
        }

        public NewNodeModel FindActiveNode(NewNodeModel activeNode, NewNodeModel endPos)
        {
            while (activeNode.Position != endPos.Position)
            {
                NewNodeModel tempNode = activeNode.Neighbors.OrderBy(node => node.fCost).First();
                tempNode.LastNode = activeNode;
                activeNode = tempNode;
            }
            if (activeNode == null) { throw new NullReferenceException(); }
            return activeNode;
        }

        public List<NewNodeModel> GeneratePath(NewNodeModel activeNode, NewNodeModel startPos)
        {
            List<NewNodeModel> generatedList = new();

            while (activeNode.Position != startPos.Position)
            {
                generatedList.Add(activeNode);
                activeNode = activeNode.LastNode;
            }
            generatedList.Reverse();
            return generatedList;
        }

        public List<Vector3> ConvertPathToPositions(List<NewNodeModel> generatedList)
        {
            List<Vector3> convertedGeneratedList = new();

            foreach (NewNodeModel node in generatedList)
            {
                convertedGeneratedList.Add(node.Position);
            }

            return convertedGeneratedList;
        }

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