using Harmony;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace RimStory.Harmony
{
    [HarmonyPatch(typeof(RelationsUtility))]
    [HarmonyPatch("TryDevelopBondRelation")]


    class BondHook
    {
        static void Postfix(bool __result, ref Pawn humanlike, ref Pawn animal)
        {
            //Resources.eventsLog.Add(new ARecruitment(Utils.CurrentDate(), humanlike, animal));
            if (__result)
            {
                Log.Message("bonded");
                Resources.eventsLog.Add(new ABonded(Utils.CurrentDate(), humanlike, animal));
            }
        }

    }
}
