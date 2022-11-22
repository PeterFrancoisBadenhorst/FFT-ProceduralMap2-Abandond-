﻿using Assets.Code.ProceduleDungeon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.ProceduleDungeon.Structs
{
    public struct NeighborStruct
    {
        public DirectionTypeEnum Direction { get; set; }
        public GameObject OriginObject { get; set; }
        public GameObject NorthNeighbor { get; set; }
        public GameObject EastNeighbor { get; set; }
        public GameObject SouthNeighbor { get; set; }
        public GameObject WestNeighbor { get; set; }
        public GameObject TopNeighbor { get; set; }
        public GameObject BottomNeighbor { get; set; }
    }
}
