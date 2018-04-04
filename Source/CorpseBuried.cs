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
        // Token: 0x06000157 RID: 343 RVA: 0x0000CD30 File Offset: 0x0000AF30       
        static void Postfix(Building_Grave __instance, Pawn worker)
        {
            Resources.lastGrave = __instance;
            if (__instance.Corpse.InnerPawn.IsColonist)
            {
                Log.Message("Colonist buried "+ __instance.Corpse.InnerPawn);
                Resources.deadPawnsForMassFuneralBuried.Add(__instance.Corpse.InnerPawn);
            }
        }
    }
}
