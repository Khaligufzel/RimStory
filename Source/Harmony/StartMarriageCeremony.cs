using Harmony;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace RimStory.Harmony
{

    [HarmonyPatch(typeof(VoluntarilyJoinableLordsStarter))]
    [HarmonyPatch("TryStartMarriageCeremony")]
    class StartMarriageCeremony
    {

        static void Postfix(bool __result, ref Pawn firstFiance, ref Pawn secondFiance)
        {
            
            Resources.events.Add(new AMarriage(Utils.CurrentDate(), firstFiance, secondFiance));
            Resources.eventsLog.Add(new AMarriage(Utils.CurrentDate(), firstFiance, secondFiance));
        }
    }
}

