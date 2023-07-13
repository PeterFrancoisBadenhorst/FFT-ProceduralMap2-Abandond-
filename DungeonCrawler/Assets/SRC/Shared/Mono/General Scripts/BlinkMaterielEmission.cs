using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using UnityEngine.TestTools;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.mono
{
    public class BlinkMaterielEmission : MonoBehaviour
    {
        private MeshRenderer[] renders;
        public Material materiel;
        private Vector2 materialPingPong;
        [ExcludeFromCoverage]
        private void OnEnable()
        {
            materialPingPong = new(Random.Range(0, 2), 2);
        }
        [ExcludeFromCoverage]
        private void FixedUpdate()
        {
            materialPingPong.x = Mathf.PingPong(materialPingPong.x, materialPingPong.y);
            materiel.SetColor("_EmissionColor", new Vector4(Color.red.r, Color.red.g, Color.red.b, 0) * materialPingPong.x);
        }
    }
}
