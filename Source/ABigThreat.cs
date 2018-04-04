using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using Verse.AI.Group;

namespace RimStory
{
    class ABigThreat : IEvent
    {
        private Date date;
        private bool anniversary = true;
        private List<int> yearsWhenEventStarted = new List<int>();
        private Faction faction;

        public ABigThreat()
        {

        }

        public ABigThreat(Date date, Faction faction)
        {
            this.date = date;
            this.faction = faction;
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
            bool flag = true;
            foreach (int y in yearsWhenEventStarted)
            {
                if (y == Utils.CurrentYear())
                {
                    flag = false;
                }
            }

            if (Utils.CurrentDay() == date.day && Utils.CurrentQuadrum() == date.quadrum && Utils.CurrentHour() >= Resources.minHour && Utils.CurrentHour() <= Resources.maxHour && Utils.CurrentYear() != date.year && flag)
            {
                Pawn pawn = PartyUtility.FindRandomPartyOrganizer(Faction.OfPlayer, map);
                if (pawn == null)
                {
                    return false;
                }
                IntVec3 intVec;
                if (!RCellFinder.TryFindPartySpot(pawn, out intVec))
                {
                    return false;
                }

                yearsWhenEventStarted.Add(Utils.CurrentYear());

                yearsWhenEventStarted.Add(Utils.CurrentYear());
                Lord lord = LordMaker.MakeNewLord(pawn.Faction, new LordJob_Joinable_Party(intVec, pawn), map, null);
                Find.LetterStack.ReceiveLetter("Day of "+faction.Name+" defeat", "Your colonists are celebrating " + faction.Name + "'s defeat on \n" + date, LetterDefOf.PositiveEvent);
                return true;
            }

            flag = true;
            return false;
        }

        private void AddAttendedMemorialDay(Pawn pawn)
        {
           
        }
    }
}
