using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Noise;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Managers;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Exceptions;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    internal class GameObjectCreation
    {
        private CustomExceptions exp = new CustomExceptions();
        public GameObject CreateGameObjectTile(GameObject baseObject, Material envMat)
        {
            var mf = baseObject.AddComponent<MeshFilter>();
            mf.mesh = GetMesh();
            var mr = baseObject.AddComponent<MeshRenderer>();
            mr.material = envMat;
            var mc = baseObject.AddComponent<MeshCollider>();
            mc.convex = true;
            mc.sharedMesh = mf.mesh;
            var rb = baseObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;
            baseObject.isStatic = true;

            return baseObject;
        }

        private Mesh GetMesh()
        {
            return exp.NotImplementedException();
        }


    }
}
