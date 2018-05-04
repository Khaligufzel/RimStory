using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using HugsLib.Utils;
using UnityEngine;

namespace RimStory
{
    public class Saves : UtilityWorldObject
    {
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_References.Look<Building_Grave>(ref Resources.lastGrave, "RS_LastGrave", true);
      
            Scribe_Collections.Look<IEvent>(ref Resources.events, "RS_Events", LookMode.Deep, null);
            Scribe_Collections.Look<IEvent>(ref Resources.eventsLog, "RS_EventsLog", LookMode.Deep, null);

            Scribe_Collections.Look<Pawn>(ref Resources.pawnsAttended, "RS_PawnsAttended", LookMode.Reference, null, true);
            Scribe_Collections.Look<Pawn>(ref Resources.deadPawnsForMassFuneral, "RS_DeadPawns", LookMode.Reference, null, true);
            Scribe_Collections.Look<Pawn>(ref Resources.deadPawnsForMassFuneralBuried, "RS_DeadPawnsBuried", LookMode.Reference, null, true);   

            Scribe_Values.Look<bool>(ref Resources.isMemorialDayCreated, "RS_Memorial_Day", false);
            Scribe_Values.Look<Vector2>(ref Window_Story.logSize, "RS_Window_Size" );

            Scribe_Values.Look<bool>(ref Resources.showRaidsInLog, "RS_ShowRaidInLog", true);
            Scribe_Values.Look<bool>(ref Resources.showRaidsInLog, "RS_ShowDeadColonistsInLog", true);
            Scribe_Values.Look<bool>(ref Resources.showRaidsInLog, "RS_showIncidentsInLog", true);



        }
    }


}
