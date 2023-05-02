using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Noise;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Managers;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    public class PopulateTilePositions 
    {
        public List<GameObject> SetChildTile(DirectionalTilesScriptableObject tolCol, List<GameObject> parentObjects)
        {
            var j = tolCol.RetunObjectsAsAList();
            for (int i = 0; i < parentObjects.Count; i++)
            {
                int g = (int)parentObjects[i].GetComponent<ChunkBehavior>().neighborStruct.Direction;

                GameObject t = UtilitiesBehaviour.InstantiateObject(j[g], parentObjects[i].transform.position, Quaternion.identity);

                t.transform.SetParent(parentObjects[i].transform, false);
                parentObjects[i].isStatic = true;
                parentObjects[i].name =  i + "   " + parentObjects[i].transform.position.ToString() ;
            }
            return parentObjects;
        }
    }
}
