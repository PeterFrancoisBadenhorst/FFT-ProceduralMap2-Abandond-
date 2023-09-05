using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Global;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
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
        public List<GameObject> SetChildTile()
        {
            // Get the list of child tiles from the directional tiles scriptable object.
            var RoomCount = GlobalVariables.CreationModel.Rooms.RetunObjectsAsAList();

            // Iterate through the parent objects.
            for (int i = 0; i < RoomCount.Count; i++)
            {
                // Get the child tile index for the current parent object.
                int g = (int)GlobalVariables.CreationModel.GridRelations[i].GetComponent<ChunkBehavior>().neighborStruct.Direction;

                // Instantiate the child tile at the position of the parent object.
                GameObject t = UtilitiesBehaviour.InstantiateObject(RoomCount[g], GlobalVariables.CreationModel.GridRelations[i].transform.position, Quaternion.identity);

                // Set the parent-child relationship between the parent object and the child tile.
                t.transform.SetParent(GlobalVariables.CreationModel.GridRelations[i].transform, false);

                // Make the parent object static.
                GlobalVariables.CreationModel.GridRelations[i].isStatic = true;

                // Set the name of the parent object to its index and position.
                GlobalVariables.CreationModel.GridRelations[i].name = i + "   " + GlobalVariables.CreationModel.GridRelations[i].transform.position.ToString();
            }

            // Return the list of parent objects.
            return GlobalVariables.CreationModel.GridRelations;
        }
    }
}