using Harmony;
using HugsLib;
using HugsLib.Utils;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace RimStory
{

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

            Resources.TEST_MAP = map;

            base.MapLoaded(map);

            


            ///////////////////////////////////// One tick per hour \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            HugsLibController.Instance.TickDelayScheduler.ScheduleCallback(() => {


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
              
                if (Resources.deadPawnsForMassFuneralBuried.Count > 0)
                {
                    
                    if (Resources.dateLastFuneral == null || (Utils.CurrentDay() != Resources.dateLastFuneral.getDate().day && Utils.CurrentQuadrum() != Resources.dateLastFuneral.getDate().quadrum && Utils.CurrentYear() != Resources.dateLastFuneral.getDate().year))
                    {
                        Log.Message("3");
                    }

                    if (MassFuneral.TryStartMassFuneral(map))
                    {                          
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