using Harmony;
using HugsLib;
using HugsLib.Utils;
using RimWorld;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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

        public override void MapDiscarded(Map map)
        {
            base.MapDiscarded(map);
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
                            
                        
                        if(e is AMarriage && RimStoryMod.settings.enableMarriageAnniversary)
                        {
                            e.TryStartEvent(map);
                        }

                        if (e is AMemorialDay && RimStoryMod.settings.enableMemoryDay)
                        {
                            e.TryStartEvent(map);
                        }

                        if (e is ABigThreat && RimStoryMod.settings.enableDaysOfVictory)
                        {
                            e.TryStartEvent(map);
                        }

                        if (e is ADead && RimStoryMod.settings.enableIndividualThoughts)
                        {
                            e.TryStartEvent(map);
                        }
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
              
                if (Resources.deadPawnsForMassFuneralBuried.Count > 0 && RimStoryMod.settings.enableFunerals)
                {
                    
                    if (Resources.dateLastFuneral == null || (Utils.CurrentDay() != Resources.dateLastFuneral.GetDate().day && Utils.CurrentQuadrum() != Resources.dateLastFuneral.GetDate().quadrum && Utils.CurrentYear() != Resources.dateLastFuneral.GetDate().year))
                    {
                       
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

        public override void SceneLoaded(Scene scene)
        {

            ///////////////////////////////////// Dirty hacks for deleting static lists. Don't look. \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 

            base.SceneLoaded(scene);
            if (GenScene.InEntryScene == true)
            {
                Resources.eventsLog.Clear();
                Resources.events.Clear();
            }
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