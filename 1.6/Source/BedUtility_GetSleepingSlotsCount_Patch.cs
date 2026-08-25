using System;
using HarmonyLib;
using RimWorld;

namespace BunkBeds
{
    [HarmonyPatch(typeof(BedUtility), "GetSleepingSlotsCount")]
    public static class BedUtility_GetSleepingSlotsCount_Patch
    {
        [ThreadStatic]
        public static CompBunkBed bunkBedComp;

        public static bool Prefix(ref int __result)
        {
            if (bunkBedComp == null)
                return true;
            __result = bunkBedComp.Props.pawnCount;
            return false;
        }
    }
}
