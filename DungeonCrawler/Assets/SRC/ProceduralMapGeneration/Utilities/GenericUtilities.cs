using UnityEngine;
namespace Assets.SRC.ProceduralMapGeneration.Utilities
{
    public class GenericUtilities
    {
        public static Vector3[] NeighborsPosition(float scale)
        {
            var top = Vector3.up * scale;
            var bottom = Vector3.down * scale;
            var north = Vector3.right * scale;
            var east = Vector3.forward * scale;
            var west = Vector3.back * scale;
            var south = -Vector3.left * scale;

            return new Vector3[] { north, east, south, west, top, bottom };
        }
    }
}
