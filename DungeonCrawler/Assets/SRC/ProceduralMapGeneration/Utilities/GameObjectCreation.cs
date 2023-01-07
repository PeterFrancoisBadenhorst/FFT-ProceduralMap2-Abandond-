using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Exceptions;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    internal class GameObjectCreation
    {
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
            CustomExceptions exp = new CustomExceptions();
            return exp.NotImplementedException();
        }


    }
}
