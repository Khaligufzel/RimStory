using Harmony;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace RimStory.Harmony
{
    [HarmonyPatch(typeof(InteractionWorker_Breakup))]
    [HarmonyPatch("RandomBreakupReason")]
    class RandomBreakup
    {
        static void Postfix(Thought __result, ref Pawn initiator, ref Pawn recipient)
        {
            
            Resources.eventsLog.Add(new Breakup(Utils.CurrentDate(), initiator, recipient, __result));            
        }
    }
}
