using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs
{
    public class MapBuilderStruct
    {
        public List<GameObject> grid { get; set; }
        public GameObject startObject { get; set; }
        public GameObject previousTilePos { get; set; }
    }
}