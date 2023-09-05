using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    public class PopulateTilePositions
    {
        /*
         * Sets the child tile for each parent object.
         *
         * @param tolCol The directional tiles scriptable object.
         * @param parentObjects The list of parent objects.
         *
         * @return The list of parent objects.
         */
        public List<GameObject> SetChildTile(DirectionalTilesScriptableObject tolCol, List<GameObject> parentObjects)
        {
            // Get the list of child tiles from the directional tiles scriptable object.
            var j = tolCol.RetunObjectsAsAList();

            // Iterate through the parent objects.
            for (int i = 0; i < parentObjects.Count; i++)
            {
                // Get the child tile index for the current parent object.
                int g = (int)parentObjects[i].GetComponent<ChunkBehavior>().neighborStruct.Direction;

                // Instantiate the child tile at the position of the parent object.
                GameObject t = UtilitiesBehaviour.InstantiateObject(j[g], parentObjects[i].transform.position, Quaternion.identity);

                // Set the parent-child relationship between the parent object and the child tile.
                t.transform.SetParent(parentObjects[i].transform, false);

                // Make the parent object static.
                parentObjects[i].isStatic = true;

                // Set the name of the parent object to its index and position.
                parentObjects[i].name = i + "   " + parentObjects[i].transform.position.ToString();
            }

            // Return the list of parent objects.
            return parentObjects;
        }
    }
}