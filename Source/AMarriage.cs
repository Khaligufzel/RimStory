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
            
        }

        public bool GetIsAnniversary()
        {
            return anniversary;
        }

        public bool IsStillEvent()
        {
            throw new NotImplementedException();
        }

        public bool TryStartEvent()
        {
            throw new NotImplementedException();
        }

        public bool TryStartEvent(Map map)
        {

            
            //if(pawn1.GetSpouse() != pawn2)
            //{
            //    Resources.eventsToDelete.Add(this);
            //    return false;
            //}

            

            bool flag = true;
            foreach(int y in yearsWhenEventStarted)
            {
                if( y == Utils.CurrentYear())
                {
                    flag = false;
                }
            }

            Log.Message("      " + flag);
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
                Find.LetterStack.ReceiveLetter("Marriage anniversary", pawn1.LabelShort + " and " + pawn2.LabelShort + " anniversary.", LetterDefOf.PositiveEvent);


                foreach (Pawn p in pawn1.Map.mapPawns.FreeColonists)
                {
                    //Map mapa = p.Map.mapPawns.AllPawns;
                    //AddAttendedOurAnniversaryThoughts(p);
                    //Log.Message(p.LabelShort);
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
