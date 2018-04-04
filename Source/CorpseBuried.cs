using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
namespace RimStory.Harmony
{

    [HarmonyPatch(typeof(Building_Grave))]
    [HarmonyPatch("Notify_CorpseBuried")]
    
    class CorpseBuried
    {      
        static void Postfix(Building_Grave __instance, Pawn worker)
        {
            Resources.lastGrave = __instance;
            if (__instance.Corpse.InnerPawn.IsColonist)
            {

                Resources.deadPawnsForMassFuneralBuried.Add(__instance.Corpse.InnerPawn);
            }
        }
    }
}
