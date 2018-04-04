using Harmony;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace RimStory.Harmony
{
    [HarmonyPatch(typeof(IncidentWorker_RaidEnemy))]
    [HarmonyPatch("TryExecuteWorker")]

    class RaidHook
    {
        // Token: 0x06000157 RID: 343 RVA: 0x0000CD30 File Offset: 0x0000AF30       
        static void Postfix(IncidentWorker_RaidEnemy __instance, IncidentParms parms)
        {
            Log.Warning("  RAID  " + parms.faction );
            Log.Warning("  RAID  " + parms.points);
            
        }
    }
}
