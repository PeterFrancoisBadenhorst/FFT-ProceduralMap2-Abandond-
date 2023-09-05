using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Assets.SRC.Shared.Enums;
using System;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Assets.SRC.Shared.Utilities
{
    public class VectorMath
    {
        public float CalculateDistanceBetweenTwoVectors(Vector3 v1, Vector3 v2) => Vector3.Distance(v1, v2);

        public Vector3 ConvertV2ToV3(Vector2 V2, VectorMathConvertionEnum scheme)
        {
            Vector3 v3 = Vector3.zero;
            switch (scheme)
            {
                case VectorMathConvertionEnum.XY_XYZ:
                    v3.x = V2.x;
                    v3.y = V2.y;
                    v3.z = 0;
                    return v3;
                case VectorMathConvertionEnum.XY_XZY:
                    v3.x = V2.x;
                    v3.y = 0;
                    v3.z = V2.y;
                    return v3;
                case VectorMathConvertionEnum.XY_YXZ:
                    v3.x = V2.y;
                    v3.y = V2.x;
                    v3.z = 0;
                    return v3;
                case VectorMathConvertionEnum.XY_ZXY:
                    v3.x = V2.y;
                    v3.y = 0;
                    v3.z = V2.x;
                    return v3;
                case VectorMathConvertionEnum.XY_YZX:
                    v3.x = 0;
                    v3.y = V2.x;
                    v3.z = V2.y;
                    return v3;
                case VectorMathConvertionEnum.XY_ZYX:
                    v3.x = 0;
                    v3.y = V2.y;
                    v3.z = V2.x;
                    return v3;
                default:
                    throw new ArgumentOutOfRangeException(nameof(scheme), scheme, "Invalid scheme");
            }
        }
    }
}