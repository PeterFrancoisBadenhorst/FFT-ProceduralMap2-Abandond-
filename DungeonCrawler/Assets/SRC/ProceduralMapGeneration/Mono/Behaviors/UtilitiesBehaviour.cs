using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors
{
    internal class UtilitiesBehaviour : MonoBehaviour
    {
        /**
         * Instantiates a game object at the specified position and rotation.
         *
         * @param gObject The game object to instantiate.
         * @param position The position of the instantiated game object.
         * @param rotation The rotation of the instantiated game object.
         *
         * @return The instantiated game object.
         */
        public static GameObject InstantiateObject(GameObject gObject, Vector3 position, Quaternion rotation)
        {
            // Call the Instantiate() function to instantiate the gObject object at the specified position and rotation.
            return Instantiate(gObject, Vector3.zero, rotation);
        }
        /**
        * Purges a game object immediately.
        *
        * @param obj The game object to purge.
        */
        public static void PurgeObject(GameObject obj)
        {
            // Call the DestroyImmediate() function to purge the obj object immediately.
            DestroyImmediate(obj);
        }
    }
}