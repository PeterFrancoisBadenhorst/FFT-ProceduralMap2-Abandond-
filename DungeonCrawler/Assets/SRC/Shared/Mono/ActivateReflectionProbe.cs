using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared
{
    [RequireComponent(typeof(BoxCollider))]
    public class ActivateReflectionProbe : MonoBehaviour
    {
        public string Layer;
        private ReflectionProbe _reflectionProbe;

        private void Awake()
        {
            _reflectionProbe = this.GetComponent<ReflectionProbe>();
            this.GetComponent<Collider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == Layer) _reflectionProbe.enabled = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == Layer) _reflectionProbe.enabled = false;
        }
    }
}