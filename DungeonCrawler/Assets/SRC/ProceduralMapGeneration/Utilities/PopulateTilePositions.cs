using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Utilities
{
    public class PopulateTilePositions 
    {
        public List<GameObject> SetChildTile(GameObject placeHolder, List<GameObject> parentObjects)
        {
            for (int i = 0; i < parentObjects.Count; i++)
            {
                Debug.Log(parentObjects[i].transform.position);
                GameObject t = UtilitiesBehaviour.InstantiateObject(placeHolder, parentObjects[i].transform.position, Quaternion.identity);
                t.transform.position = parentObjects[i].transform.position;
                t.transform.SetParent(parentObjects[i].transform, false);
                parentObjects[i].isStatic = true;
                parentObjects[i].name =  i + "   " + parentObjects[i].transform.position.ToString() ;
            }
            return parentObjects;
        }
    }
}
