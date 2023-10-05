using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.mono
{
    public class SpawnRandomObjectFromCollection : MonoBehaviour
    {
        public List<GameObject> PropCollections;
        [ExcludeFromCoverage]
        [System.Obsolete]
        private void Awake()
        {
            Instantiate(PropCollections[Random.RandomRange(0, PropCollections.Count - 1)], this.transform);
        }
    }
}
