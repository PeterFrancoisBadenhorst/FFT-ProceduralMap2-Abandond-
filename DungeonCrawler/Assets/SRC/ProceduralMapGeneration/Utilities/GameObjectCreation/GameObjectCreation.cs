using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Exceptions;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    internal class GameObjectCreation
    {
        private CustomExceptions exp = new CustomExceptions();

        /// <summary>
        /// This method creates a game object tile.
        /// </summary>
        /// <param name="baseObject">The base object to create the tile on.</param>
        /// <param name="envMat">The material to use for the tile.</param>
        /// <returns>The created game object tile.</returns>
        /// <remarks>
        /// This method creates a game object tile by adding the necessary components to the base object. The components added are:
        ///   * MeshFilter
        ///   * MeshRenderer
        ///   * MeshCollider
        ///   * Rigidbody
        ///
        /// The MeshFilter component is used to specify the mesh for the tile. The MeshRenderer component is used to render the tile. The MeshCollider component is used to detect collisions with the tile. The Rigidbody component is used to control the movement of the tile.
        ///
        /// The tile is created as a static object, meaning it will not move or be affected by gravity.
        /// </remarks>
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

        /// <summary>
        /// This method returns a mesh that can be used to render a game object tile.
        /// </summary>
        /// <returns>A mesh that can be used to render a game object tile.</returns>
        /// <remarks>
        /// This method is currently not implemented, so it will throw a NotImplementedException when called.
        /// </remarks>
        private Mesh GetMesh()
        {
            return exp.NotImplementedException();
        }
    }
}