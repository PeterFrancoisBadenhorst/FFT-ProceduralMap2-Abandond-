using UnityEngine;

namespace PathFinding
{
    public class UtilitiesBehaviour : MonoBehaviour
    {
        public static GameObject InstantiateObject(GameObject gObject, Vector3 position = Vector3.zero, Quaternion rotation = Quaternion.identity)
        {
            return Instantiate(gObject, position, rotation);
        }
        public static void PurgeObject(GameObject obj)
        {
            DestroyImmediate(obj);
        }
    }
}
