using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.PathFinding
{
    internal class NewNode
    {
        public Vector3 Position { get; set; }
        public List<NewNode> Neighbors { get; set; }
        public bool Closed { get; set; }
        public float fCost { get; set; }
        public float hCost { get; set; }
    }
}
