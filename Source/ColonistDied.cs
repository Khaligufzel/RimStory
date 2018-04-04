using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace RimStory.Harmony
{

    [HarmonyPatch(typeof(Pawn))]
    [HarmonyPatch("Kill")]

    class ColonistDied
    {
        static void Prefix(Pawn __instance)
        {
            if (__instance.IsColonist)
            {
                
                Resources.eventsLog.Add(new AMemorialDay(Utils.CurrentDate(), __instance));
               
                Resources.deadPawns.Add(__instance);
                Resources.deadPawnsForMassFuneral.Add(__instance);

                Resources.events.Add(new ADead(Utils.CurrentDate(), __instance));

                if (!Resources.isMemorialDayCreated)
                {                   
                    Resources.events.Add(new AMemorialDay(Utils.CurrentDate(), __instance));
                    Resources.isMemorialDayCreated = true;
                }

            }

        }
    }
}
