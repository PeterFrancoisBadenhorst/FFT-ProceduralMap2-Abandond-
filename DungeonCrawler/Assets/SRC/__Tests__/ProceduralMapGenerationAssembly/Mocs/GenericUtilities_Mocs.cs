using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.SRC.Tests.Assets.SRC.__Tests__.ProceduralMapGenerationAssembly.Mocs
{
    internal class GenericUtilities_Mocs
    {
        public Vector3[] SetUpNeighbors(float scale)
        {

            return new Vector3[]
                {
                    Vector3.right* scale,
                    Vector3.forward * scale,
                    Vector3.left* scale,
                    Vector3.back* scale,
                    Vector3.up* scale,
                    Vector3.down* scale
                 };
        }
    }
}
