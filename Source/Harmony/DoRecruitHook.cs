using Harmony;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace RimStory.Harmony
{
    [HarmonyPatch(typeof(InteractionWorker_RecruitAttempt))]
    [HarmonyPatch("DoRecruit")]

    class DoRecruitHook
    {
        static void Postfix(Pawn recruiter, Pawn recruitee)
        {
            
            Resources.eventsLog.Add(new ARecruitment(Utils.CurrentDate(), recruiter, recruitee));                       
            
        }
    }
}
