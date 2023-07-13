using UnityEngine;
using UnityEngine.TestTools;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.mono
{
    [RequireComponent(typeof(BoxCollider))]
    public class ActivateReflectionProbe : MonoBehaviour
    {
        public string Layer;
        private ReflectionProbe _reflectionProbe;
        [ExcludeFromCoverage]
        private void Awake()
        {
            _reflectionProbe = this.GetComponent<ReflectionProbe>();
            this.GetComponent<Collider>().isTrigger = true;
        }
        [ExcludeFromCoverage]
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == Layer) _reflectionProbe.enabled = true;
        }
        [ExcludeFromCoverage]
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == Layer) _reflectionProbe.enabled = false;
        }
    }
}