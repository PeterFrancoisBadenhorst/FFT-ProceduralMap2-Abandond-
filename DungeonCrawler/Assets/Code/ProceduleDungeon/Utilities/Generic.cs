using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
namespace Assets.Code.ProceduleDungeon.Utilities
{
    internal class Generic
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
