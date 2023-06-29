using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared
{
    public class SpawnRandomObjectFromCollection : MonoBehaviour
    {
        public List<GameObject> PropCollections;
        private void Awake()
        {
            Instantiate(PropCollections[Random.RandomRange(0,PropCollections.Count-1)],this.transform);
        }
    }
}
