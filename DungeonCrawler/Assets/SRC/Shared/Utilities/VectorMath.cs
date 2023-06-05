using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Assets.SRC.Shared.Utilities
{
    public class VectorMath
    {
        public float CalculateDistanceBetweenTwoVectors(Vector3 v1, Vector3 v2) => Vector3.Distance(v1, v2);
    }
}