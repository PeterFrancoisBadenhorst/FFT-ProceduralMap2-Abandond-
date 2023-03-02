using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Noise;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Managers;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using UnityEngine;
namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    public class GenericUtilities
    {
        /*
         * N 1;0;0
         * E 0;0;1
         * S -1;0;0
         * w 0;0;-1
         * T 0;1;0
         * B 0;-1;0
         */
        public Vector3[] NeighborsPosition(float scale,Vector3 offset)
        {
            var north = (Vector3.forward * scale)+ offset;//    0 N 1;0;0 
            var east = (Vector3.right * scale) + offset;//      1 E 0;0;1 
            var south = (Vector3.back * scale) + offset;//      2 S -1;0;0 
            var west = (Vector3.left * scale) + offset;//       3 w 0;0;-1
            var top = (Vector3.up * scale) + offset;//          4 T 0;1;0
            var bottom = (Vector3.down * scale) + offset;//     5 B 0;-1;0

            return new Vector3[] { north, east, south, west, top, bottom };
        }
    }
}
