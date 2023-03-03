using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Noise;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Managers;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    internal class MapBuilder
    {
        private static MapBuilderStruct dataKeeper = new MapBuilderStruct();

        public List<GameObject> ChooseStartTile(List<GameObject> grid)
        {
            dataKeeper.grid = grid;
            var random = new System.Random();
            dataKeeper.startObject = grid[random.Next(grid.Count)];
            return grid;
        }

        public List<GameObject> CollapseTile(List<GameObject> grid, GameObject tile)
        {
            var t = tile.GetComponent<ChunkBehavior>();
            return grid;
        }
    }
}
