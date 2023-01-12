using Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Utilities
{
    public class GridCreate
    {
        #region Grids
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
        #endregion

        public List<GameObject> FindChunkNeigbors(float scale, List<GameObject> grid)
        {
            GenericUtilities _genericUtilities = new GenericUtilities();
            for (int i = 0; i < grid.Count; i++)
            {
                var comparedValues = _genericUtilities.NeighborsPosition(scale, grid[i].transform.position);
                ChunkBehavior comparedChunk;
                if (grid[i].GetComponent<ChunkBehavior>())
                    comparedChunk = grid[i].GetComponent<ChunkBehavior>();
                else
                    comparedChunk = grid[i].AddComponent<ChunkBehavior>();
                comparedChunk.neighborStruct.OriginObject = grid[i];
                for (int o = 0; o < grid.Count; o++)
                {
                    GameObject gameObject = grid[o];
                    if (!comparedChunk.neighborStruct.NorthNeighbor &&
                       gameObject.transform.position == comparedValues[0])
                        comparedChunk.neighborStruct.NorthNeighbor = grid[o].gameObject;

                    if (!comparedChunk.neighborStruct.EastNeighbor &&
                        gameObject.transform.position == comparedValues[1])
                        comparedChunk.neighborStruct.EastNeighbor = grid[o].gameObject;

                    if (!comparedChunk.neighborStruct.SouthNeighbor &&
                        gameObject.transform.position == comparedValues[2])
                        comparedChunk.neighborStruct.SouthNeighbor = grid[o].gameObject;

                    if (!comparedChunk.neighborStruct.WestNeighbor &&
                        gameObject.transform.position == comparedValues[3])
                        comparedChunk.neighborStruct.WestNeighbor = grid[o].gameObject;

                    if (!comparedChunk.neighborStruct.TopNeighbor &&
                       gameObject.transform.position == comparedValues[4])
                        comparedChunk.neighborStruct.TopNeighbor = grid[o].gameObject;

                    if (!comparedChunk.neighborStruct.BottomNeighbor &&
                       gameObject.transform.position == comparedValues[5])
                        comparedChunk.neighborStruct.BottomNeighbor = grid[o].gameObject;
                }
                grid[i].GetComponent<ChunkBehavior>().neighborStruct = comparedChunk.neighborStruct;
            }
            return grid;
        }
        public List<GameObject> PlaceGameObjectsAtGridPositions(Vector3[] grid, Transform gridParent)//
        {
            List<GameObject> gameObjects = new List<GameObject>();
            for (int i = 0; i < grid.Length; i++)
            {
                var g = new GameObject();
                g.transform.position = grid[i];
                g.transform.parent = gridParent;
                gameObjects.Add(g);
            }
            return gameObjects;
        }
       
        public List<GameObject> AsignChunkTypes(List<GameObject> grid)
        {
            for (int i = 0; i < grid.Count; i++)
            {
                grid[i].GetComponent<ChunkBehavior>().neighborStruct.Direction = FindChunkType(grid[i].GetComponent<ChunkBehavior>().neighborStruct);
            }
            return grid;
        }

        public DirectionTypeEnum FindChunkType(NeighborStruct chunk)
        {
            if (chunk.Direction != DirectionTypeEnum.Collapsed || chunk.Direction == DirectionTypeEnum.Blank)
            {
                string result = "";

                if (chunk.NorthNeighbor)               
                   result += "N";
                
                if (chunk.EastNeighbor)               
                    result += "E";
                
                if (chunk.SouthNeighbor)                
                    result += "S";
                
                if (chunk.WestNeighbor)               
                    result += "W";
                
                if (chunk.TopNeighbor)                
                    result += "T";
                
                if (chunk.BottomNeighbor)               
                    result += "B";
                
               return (DirectionTypeEnum)Enum.Parse(typeof(DirectionTypeEnum), result);

            }
            else if (chunk.Direction == DirectionTypeEnum.Error)
            {
                // Well, something really fucked out,
                // Somewhere. . .
                // (((φ(◎ロ◎;)φ)))
                // I Should probably put some kind of exception here.
                // But then it would make this exceptional.
                return DirectionTypeEnum.Error;
            }
            else
                return chunk.Direction;
            // Just like my dreams of getting a paid 6 month vacation twice a year.
            // o(〒﹏〒)o
        }
    }

}