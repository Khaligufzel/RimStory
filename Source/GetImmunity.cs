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
            ////Log.Message("1337"); 
            //if (hediffs.Count > 0)
            //{
            //    foreach (Hediff h in hediffs)
            //    {
            //        if (h == diseaseInstance)
            //        {

            //            flag = true;
            //            //lastDisease = h;

            //        }                    
            //    }               
            //}

            //if (!flag)
            //{
               
            //    Resources.events.Add(new ASurvivedDesease(Utils.CurrentDate(), pawn, diseaseInstance));
            //    hediffs.Add(diseaseInstance);
            //    flag = true;
            //    Log.Message("Adding survived diseaes");
            //    Log.Message("  H.C: " + hediffs.Count());
            //}

        }
    }

    //[HarmonyPatch(typeof(HediffUtility))]
    //[HarmonyPatch("FullyImmune")]
    //class AnyHediffMakesFullyImmuneTo
    //{
    //    //static void Postfix(bool __result)
    //    //{
    //    //    Log.Message(__result + " hey");
    //    //    //Resources.eventsLog.Add(new Breakup(Utils.CurrentDate(), initiator, recipient, __result));
    //    //}
    //}
}
