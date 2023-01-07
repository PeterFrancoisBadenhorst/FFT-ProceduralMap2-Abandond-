using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors
{
    internal class UtilitiesBehaviour : MonoBehaviour
    {
        public static GameObject InstantiateObject(GameObject gObject,Vector3 position,Quaternion rotation)
        {
           return Instantiate(gObject, position, rotation);
        }
    }
}
