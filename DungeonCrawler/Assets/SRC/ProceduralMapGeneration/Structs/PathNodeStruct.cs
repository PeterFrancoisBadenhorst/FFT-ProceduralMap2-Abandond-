using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs
{
    public class PathNodeStruct
    {
        public PathNode North { get; set; }
        public float? NorthCost { get; set; }
        public PathNode East { get; set; }
        public float? EasthCost { get; set; }
        public PathNode South { get; set; }
        public float? SouthCost { get; set; }
        public PathNode West { get; set; }
        public float? WestCost { get; set; }
        public PathNode Top { get; set; }
        public float? TopCost { get; set; }
        public PathNode Bottom { get; set; }
        public float? BottomCost { get; set; }
    }
}
