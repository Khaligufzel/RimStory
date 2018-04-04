using Harmony;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace RimStory.Harmony
{
    [HarmonyPatch(typeof(ImmunityRecord))]
    [HarmonyPatch("ImmunityTick")]
    public static class GetImmunity
    {
        private static bool flag = false;
        private static Hediff lastDisease;
        private static List<Hediff> hediffs = new List<Hediff>();
 
        static void Postfix(ref Pawn pawn, ref bool sick, ref Hediff diseaseInstance)
        {


        }
    }

  
}
