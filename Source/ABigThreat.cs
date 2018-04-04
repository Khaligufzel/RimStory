using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

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
            return false;
        }

        private void AddAttendedMemorialDay(Pawn pawn)
        {
           
        }
    }
}
