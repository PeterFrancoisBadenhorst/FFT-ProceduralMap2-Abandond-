using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Noise;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Managers;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
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
