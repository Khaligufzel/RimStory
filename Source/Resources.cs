using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;

namespace RimStory
{
    public static class Resources
    {

        public static Map TEST_MAP;

        public static Random rng = new Random();
        public static int randomChanceRaid = 51;








        public static int minHour = 10;
        public static int maxHour = 20;

        public static List<Pawn> deadPawnsForMassFuneral = new List<Pawn>();
        public static List<Pawn> deadPawnsForMassFuneralBuried = new List<Pawn>();
        public static List<Building_Grave> graves = new List<Building_Grave>();

        //List of all events to honor
        public static List<IEvent> events = new List<IEvent>();
        public static List<IEvent> eventsToDelete = new List<IEvent>();
        //List of all events. Important and non important.
        public static List<IEvent> eventsLog = new List<IEvent>();
        public static List<Pawn> pawnsAttended = new List<Pawn>();

        //public static Pawn lastDeadPawn;
        public static Building_Grave lastGrave;

        public static List<Pawn> deadPawns = new List<Pawn>();

        public static bool isMemorialDayCreated = false;
        public static Date dateLastFuneral = null;

        //public static void RS_Save()
        //{
        //    Saves save = new Saves();
        //    save.ExposeData();
        //}

        

    }
}
