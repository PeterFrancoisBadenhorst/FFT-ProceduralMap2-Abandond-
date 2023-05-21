using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Utilities;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Noise;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Managers;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DirectionalTilesScriptableObject", order = 1)]
    public class DirectionalTilesScriptableObject : ScriptableObject
    {
        public GameObject N;
        public GameObject NE;
        public GameObject NS;
        public GameObject NW;
        public GameObject NT;
        public GameObject NB;
        public GameObject NES;
        public GameObject NESW;
        public GameObject NEWTB;
        public GameObject NESWT;
        public GameObject EWTB;
        public GameObject NESWB;
        public GameObject NESWBT;
        public GameObject NEW;
        public GameObject NEWT;
        public GameObject NEWB;
        public GameObject NET;
        public GameObject NETB;
        public GameObject NEB;
        public GameObject NEST;
        public GameObject NESTB;
        public GameObject NESB;
        public GameObject NSW;
        public GameObject NSWT;
        public GameObject NSWB;
        public GameObject NST;
        public GameObject NSTB;
        public GameObject NSB;
        public GameObject NSWTB;
        public GameObject NWT;
        public GameObject NWTB;
        public GameObject NWB;
        public GameObject NTB;
        public GameObject ES;
        public GameObject ESW;
        public GameObject ESWT;
        public GameObject ESWB;
        public GameObject ESWBT;
        public GameObject EW;
        public GameObject EWT;
        public GameObject EWB;
        public GameObject ET;
        public GameObject ETB;
        public GameObject EB;
        public GameObject EST;
        public GameObject ESTB;
        public GameObject ESB;
        public GameObject SW;
        public GameObject SWT;
        public GameObject SWB;
        public GameObject ST;
        public GameObject STB;
        public GameObject SB;
        public GameObject SWTB;
        public GameObject WT;
        public GameObject WTB;
        public GameObject WB;
        public GameObject TB;
        public GameObject S;
        public GameObject E;
        public GameObject SWBT;
        public GameObject W;
        public GameObject T;
        public GameObject B;
        public GameObject NESWTB;
        public GameObject ESWTB;

        public List<GameObject> RetunObjectsAsAList()
        {
            return new List<GameObject>()
                {
                            N,
                            NE,
                            NS,
                            NW,
                            NT,
                            NB,
                            NES,
                            NESW,
                            NEWTB,
                            NESWT,
                            EWTB,
                            NESWB,
                            NESWTB,
                            NEW,
                            NEWT,
                            NEWB,
                            NET,
                            NETB,
                            NEB,
                            NEST,
                            NESTB,
                            NESB,
                            NSW,
                            NSWT,
                            NSWB,
                            NST,
                            NSTB,
                            NSB,
                            NSWTB,
                            NWT,
                            NWTB,
                            NWB,
                            NTB,
                            ES,
                            ESW,
                            ESWT,
                            ESWB,
                            ESWTB,
                            EW,
                            EWT,
                            EWB,
                            ET,
                            ETB,
                            EB,
                            EST,
                            ESTB,
                            ESB,
                            SW,
                            SWT,
                            SWB,
                            ST,
                            STB,
                            SB,
                            SWTB,
                            WT,
                            WTB,
                            WB,
                            TB,
                            S,
                            E,
                            W,
                            T,
                            B,
                };
        }
    }
}
