using Harmony;
using HugsLib;
using HugsLib.Utils;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace RimStory
{
   
    //[HarmonyPatch(typeof(Building_Grave), "Notify_CorpseBuried", null)]
    //public static class BuildingGraveHook
    //{       
    //    [HarmonyPostfix]
    //    public static void PlanFuneral(Building_Grave __instance, Pawn worker)
    //    {
    //        Log.Message("Building grave I HOPE for: "+ worker);
    //        Log.Message("Of course I was wrong. "+worker+ " BURIED dead pawn");
    //    }
    //}

    public class RimStory : ModBase
    {
        public override string ModIdentifier => "RimStory";

        public override ModContentPack ModContentPack => base.ModContentPack;

        protected override bool HarmonyAutoPatch => base.HarmonyAutoPatch;

        public override void DefsLoaded()
        {
            base.DefsLoaded();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        public override void MapGenerated(Map map)
        {
            base.MapGenerated(map);
            
        }

        public override void MapLoaded(Map map)
        {
            Log.Message(map+" loaded.");
            Resources.TEST_MAP = map;

            //Resources.RS_Save();
            base.MapLoaded(map);

            


            ///////////////////////////////////// One tick per hour \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            HugsLibController.Instance.TickDelayScheduler.ScheduleCallback(() => {
               // Log.Message(" "+ Resources.lastDeadPawn);
                //if (Resources.lastDeadPawn != null)
                //{
                    
                //    if (Resources.lastDeadPawn.Corpse != null)
                //    {
                        
                //        if (map.listerThings.ThingsInGroup(ThingRequestGroup.Grave) != null)
                //        {
                            
                //            foreach (Building_Grave grave in map.listerThings.ThingsInGroup(ThingRequestGroup.Grave))
                //            {
                //                if (grave.Corpse.InnerPawn == Resources.lastDeadPawn && grave.Corpse.InnerPawn != null)
                //                {
                                    
                //                    Resources.lastGrave = grave;
                //                }
                //            }
                //        }
                //    }
                //}

                if (Resources.events.Count > 0)
                {
                    foreach (IEvent e in Resources.events)
                    {                     
                            e.TryStartEvent(map);                                                                            
                    }
                    
                }

                foreach (IEvent e in Resources.eventsToDelete)
                {
                    Resources.events.Remove(e);
                }
                Resources.eventsToDelete.Clear();
              
            }, 2500, null, true);

            ///////////////////////////////////// Mass funeral \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\   
            HugsLibController.Instance.TickDelayScheduler.ScheduleCallback(() => {
                Log.Message("1");

                Log.Message(Resources.deadPawnsForMassFuneral.Count + " pawns dead");
                Log.Message(Resources.deadPawnsForMassFuneralBuried.Count + " pawns buried");

                if (Resources.deadPawnsForMassFuneralBuried.Count > 0)
                {
                    Log.Message("2");
                    if (Resources.dateLastFuneral == null || (Utils.CurrentDay() != Resources.dateLastFuneral.getDate().day && Utils.CurrentQuadrum() != Resources.dateLastFuneral.getDate().quadrum && Utils.CurrentYear() != Resources.dateLastFuneral.getDate().year))
                    {
                        Log.Message("3");
                    }

                    if (MassFuneral.TryStartMassFuneral(map))
                    {
                            Log.Message("4");
                            Resources.deadPawnsForMassFuneralBuried.Clear();
                            Resources.dateLastFuneral = Utils.CurrentDate();
                    }
                }
                

            }, 2500, null, true);
        }

        public override void OnGUI()
        {
            base.OnGUI();
        }

        public override void SettingsChanged()
        {
            base.SettingsChanged();
        }

        public override void Tick(int currentTick)
        {
            base.Tick(currentTick);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void WorldLoaded()
        {
            base.WorldLoaded();
            var obj = UtilityWorldObjectManager.GetUtilityWorldObject<Saves>();


        }
    }
}