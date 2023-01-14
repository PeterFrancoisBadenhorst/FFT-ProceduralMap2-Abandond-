using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using NUnit.Framework;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities
{
    internal class MapBuilder
    {
        private static MapBuilderHelperStruct dataKeeper=new MapBuilderHelperStruct();



        public List<GameObject> ChooseStartTile(List<GameObject> grid)
        {
            dataKeeper.grid = grid;
            var random = new System.Random();
            dataKeeper.startObject = grid[random.Next(grid.Count)];
            return grid;
        }
        //public List<GameObject> CollapseStartTile()
        //{

        //}
    }
}
