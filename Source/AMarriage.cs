using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using Verse.AI;
using RimWorld;
using RimWorld.Planet;
using Verse.AI.Group;

namespace RimStory
{
    class AMarriage : IEvent
    {
        private Date date;
        private Pawn pawn1, pawn2;
        private bool anniversary = true;
        private List<int> yearsWhenEventStarted = new List<int>();

        public AMarriage()
        {

        }


        public AMarriage(Date date, Pawn pawn1, Pawn pawn2)
        {
            this.date = date;
            this.pawn1 = pawn1;
            this.pawn2 = pawn2;          
        }

        public Date Date()
        {
            return date;
        }

        public void EndEvent()
        {
            throw new NotImplementedException();
        }

        public void ExposeData()
        {
            
            Scribe_Values.Look(ref anniversary, "RS_Anniversary", true);
            Scribe_References.Look(ref pawn1, "RS_DeadPawn1");
            Scribe_References.Look(ref pawn2, "RS_DeadPawn2");
            Scribe_Collections.Look(ref yearsWhenEventStarted, "RS_yearsWhenEventStarted", LookMode.Value);
            Scribe_Deep.Look(ref date, "RS_DateAttacked");
        }

        public bool GetIsAnniversary()
        {
            return anniversary;
        }

        public bool IsStillEvent()
        {
            throw new NotImplementedException();
        }

        public string ShowInLog()
        {
            //return (date.day + " " + date.quadrum + " " + date.year + " " + pawn1.Name + " and " + pawn2.Name+" married.");
            return (date.day + " " + date.quadrum + " " + date.year + " " + "AMarriage".Translate(new object[] {pawn1, pawn2}));
        }

        public bool TryStartEvent()
        {
            throw new NotImplementedException();
        }

        public bool TryStartEvent(Map map)
        {

            bool flag = true;
            foreach(int y in yearsWhenEventStarted)
            {
                if( y == Utils.CurrentYear())
                {
                    flag = false;
                }
            }

            if (Utils.CurrentDay() == date.day && Utils.CurrentQuadrum() == date.quadrum && Utils.CurrentHour() >= Resources.minHour && Utils.CurrentHour() <= Resources.maxHour && Utils.CurrentYear() != date.year && flag)
            {

                if (pawn1 == null)
                {
                    return false;
                }
                IntVec3 intVec;
                if (!RCellFinder.TryFindPartySpot(pawn1, out intVec))
                {
                    return false;
                }

                yearsWhenEventStarted.Add(Utils.CurrentYear());

                Lord lord = LordMaker.MakeNewLord(pawn1.Faction, new LordJob_Joinable_Party(intVec, pawn1), map, null);
                //Find.LetterStack.ReceiveLetter("Marriage anniversary", pawn1.LabelShort + " and " + pawn2.LabelShort + " anniversary.", LetterDefOf.PositiveEvent);
                Find.LetterStack.ReceiveLetter("AMarriageLetter".Translate(), "AMarriageDesc".Translate(new object[] {pawn1.LabelShort, pawn2.LabelShort }), LetterDefOf.PositiveEvent);


                foreach (Pawn p in pawn1.Map.mapPawns.FreeColonists)
                {

                    if (p == pawn1 || p == pawn2)
                    {
                        if (p.GetSpouse() == pawn1 || p.GetSpouse() == pawn2)
                        {
                            AddAttendedOurAnniversaryThoughts(p);

                        }

                        else
                        {
                            anniversary = false;
                            return false;
                        }
                    }
                    else
                    {
                        AddAttendedAnniversaryThoughts(p);
                    }

                }
                return true;
            }
            flag = true;
            return false;
           
        }

        private void AddAttendedAnniversaryThoughts(Pawn pawn)
        {           
            pawn.needs.mood.thoughts.memories.TryGainMemory(Thoughts.RS_AttendedAnniversary);
        }

        private void AddAttendedOurAnniversaryThoughts(Pawn pawn)
        {           
            pawn.needs.mood.thoughts.memories.TryGainMemory(Thoughts.RS_AttendedOurAnniversary);
        }
    }
    
}
