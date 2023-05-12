using UnityEngine;

namespace PathFinding
{
    public class NewNode
    {
        public Vector3 Position { get; set; }
        public List<NewNode> Neighbors { get; set; } = new List<NewNode>();
        public bool Closed { get; set; } = false;
        public float fCost { get; set; }
        public float hCost { get; set; }
        public NewNode LastNode { get; set; }
    }
}
