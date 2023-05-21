﻿namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Enums
{
    public enum DirectionTypeEnum
    {
        N, NE, NS, NW, NT,
        NB, NES, NESW, NEWTB, NESWT,
        EWTB, NESWB, NESWTB, NEW, NEWT,
        NEWB, NET, NETB, NEB, NEST,
        NESTB, NESB, NSW, NSWT, NSWB,
        NST, NSTB, NSB, NSWTB, NWT,
        NWTB, NWB, NTB, ES, ESW,
        ESWT, ESWB, ESWTB, EW, EWT,
        EWB, ET, ETB, EB, EST,
        ESTB, ESB, SW, SWT, SWB,
        ST, STB, SB, SWTB, WT,
        WTB, WB, TB, S, E,
        W, T, B,

        // Boiler plate values
        Blank,

        Collapsed,
        Error,
        Start,
    }
}