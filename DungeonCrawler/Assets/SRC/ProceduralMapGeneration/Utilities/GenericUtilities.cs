using UnityEngine;
namespace Assets.SRC.ProceduralMapGeneration.Utilities
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
        public static Vector3[] NeighborsPosition(float scale)
        {
            var north = Vector3.right * scale;//    0 N 1;0;0 X
            var east = Vector3.forward * scale;//   1 E 0;0;1 X
            var south = Vector3.left * scale;//     2 S -1;0;0 O
            var west = Vector3.back * scale;//      3 w 0;0;-1
            var top = Vector3.up * scale;//         4 T 0;1;0
            var bottom = Vector3.down * scale;//    5 B 0;-1;0

            return new Vector3[] { north, east, south, west, top, bottom };
        }
    }
}
