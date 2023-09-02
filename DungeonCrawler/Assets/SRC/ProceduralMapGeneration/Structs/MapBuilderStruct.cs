using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs
{
    // This class represents the data needed to build a map.
    public class MapBuilderStruct
    {
        // The grid of GameObjects that make up the map.
        public List<GameObject> grid { get; set; }
        // The starting object on the map.
        public GameObject startObject { get; set; }
        // The previous tile position. This is used to track the player's movement.
        public GameObject previousTilePos { get; set; }
    }
}