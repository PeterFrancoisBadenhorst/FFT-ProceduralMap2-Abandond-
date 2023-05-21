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
        /// <summary>
        /// Sets the child tile for each parent object in the specified list.
        /// </summary>
        /// <param name="tolCol">The directional tiles scriptable object.</param>
        /// <param name="parentObjects">The list of parent objects.</param>
        /// <returns>A list of GameObject that contains the parent objects with their child tiles set.</returns>
        /// <remarks>
        /// The method iterates through the list of parent objects and then gets the child tile for each parent object from the directional tiles scriptable object. The method then instantiates the child tile at the position of the parent object and sets the parent object as the child tile's parent. The method then sets the parent object to be static and sets its name to the index of the parent object in the list followed by the parent object's position.
        /// </remarks>
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
