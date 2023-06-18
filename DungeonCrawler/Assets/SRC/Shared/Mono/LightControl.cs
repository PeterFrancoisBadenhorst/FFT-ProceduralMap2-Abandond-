using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared
{
    public class LightControl : MonoBehaviour
    {
        public string Layer;
        private Light[] lights;
        private void OnEnable()
        {
            lights = GetComponentsInChildren<Light>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == Layer) foreach (Light light in lights) { light.enabled = true; }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == Layer) foreach (Light light in lights) { light.enabled = false; }
        }
    }
}
