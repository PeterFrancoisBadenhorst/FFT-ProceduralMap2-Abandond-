using UnityEngine;
using UnityEngine.TestTools;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.mono
{
    public class ClearChildren : MonoBehaviour
    {
        [ExcludeFromCoverage]
        public void DeleteAllChildren(GameObject parent)
        {
            GameObject[] children = parent.GetComponentsInChildren<GameObject>();
            for (int i = 0; i < children.Length; i++) Destroy(children[i]);
        }
    }
}