//using Harmony;
//using RimWorld;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Verse;

//namespace RimStory.Harmony
//{
//    [HarmonyPatch(typeof(IncidentWorker))]
//    [HarmonyPatch("TryExecute")]
//    class IncidentWorkerHook
//    {
//        static void Postfix(IncidentWorker __instance, ref IncidentParms parms, bool __result)
//        {
//            if (__result) {
//                //Log.Warning("name " + __instance.def.defName);
//                //Log.Warning("duration " + __instance.def.durationDays);
//                //Log.Warning("category " + __instance.def.category);
//                //Log.Warning("letter label " + __instance.def.letterLabel);
//                //Log.Warning("letter label " + __instance.def);
//                //Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), __instance.def.letterText));
//               // Log.Warning("letter label: " + __instance.def.letterText);
//                //Log.Warning("letter label: " + __instance.def.label.Translate());
//               // Log.Warning("letter label: " + __instance.ToString());

//                if(__instance is IncidentWorker_AnimalInsanityMass)
//                {
//                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), __instance.def.label));
//                }

//                if (__instance is IncidentWorker_ManhunterPack)
//                {
//                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), __instance.def.label));
//                }

//                if (__instance is IncidentWorker_ColdSnap)
//                {
//                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), __instance.def.label));
//                }

//                if (__instance is IncidentWorker_HeatWave)
//                {
//                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), __instance.def.label));
//                }

//                if (__instance is IncidentWorker_FarmAnimalsWanderIn)
//                {
//                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), __instance.def.label));
//                }

//                if (__instance is IncidentWorker_Infestation)
//                {
//                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), __instance.def.label));
//                }

//                if (__instance is IncidentWorker_RefugeeChased)
//                {
//                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), __instance.def.label));
//                }

//                if (__instance is IncidentWorker_RefugeePodCrash)
//                {
//                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), __instance.def.label));
//                }

//                if (__instance is IncidentWorker_Tornado)
//                {
//                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), __instance.def.label));
//                }

//                if (__instance is IncidentWorker_WandererJoin)
//                {
//                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), __instance.def.label));
//                }
//                else
//                {
//                    Log.Warning(__instance.def.defName);
//                }

                


//            }

//            //Resources.eventsLog.Add(new Breakup(Utils.CurrentDate(), initiator, recipient, __result));
//        }
//    }
//}
