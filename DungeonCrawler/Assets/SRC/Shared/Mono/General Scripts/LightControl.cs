using UnityEngine;
using UnityEngine.TestTools;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.mono
{
    public class LightControl : MonoBehaviour
    {
        public string Layer;
        private Light[] lights;
        [ExcludeFromCoverage]
        private void OnEnable()
        {
            lights = GetComponentsInChildren<Light>();
        }
        [ExcludeFromCoverage]
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == Layer) foreach (Light light in lights) { light.enabled = true; }
        }
        [ExcludeFromCoverage]
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == Layer) foreach (Light light in lights) { light.enabled = false; }
        }
    }
}
