﻿using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors
{
    internal class UtilitiesBehaviour : MonoBehaviour
    {
        public static GameObject InstantiateObject(GameObject gObject, Vector3 position, Quaternion rotation)
        {
            return Instantiate(gObject, Vector3.zero, rotation);
        }

        public static void PurgeObject(GameObject obj)
        {
            DestroyImmediate(obj);
        }
    }
}