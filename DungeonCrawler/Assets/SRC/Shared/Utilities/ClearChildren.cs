using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared
{
    public class ClearChildren : MonoBehaviour
    {
        public void DeleteAllChildren(GameObject parent)
        {
            GameObject[] children = parent.GetComponentsInChildren<GameObject>();
            for (int i = 0; i < children.Length; i++) Destroy(children[i]);
        }
    }
}