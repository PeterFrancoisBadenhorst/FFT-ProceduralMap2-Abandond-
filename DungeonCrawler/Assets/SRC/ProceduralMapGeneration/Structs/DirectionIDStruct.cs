namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs
{
    // This struct represents a set of directions.
    public struct DirectionIDStruct
    {
        // Whether the north direction is valid.
        public bool NothID { get; set; }
        // Whether the east direction is valid.
        public bool EastID { get; set; }
        // Whether the west direction is valid.
        public bool WestID { get; set; }
        // Whether the south direction is valid.
        public bool SouthID { get; set; }
        // Whether the top direction is valid.
        public bool TopID { get; set; }
        // Whether the bottom direction is valid.
        public bool BottomID { get; set; }
    }
}