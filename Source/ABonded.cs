using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace RimStory
{
    class ABonded : IEvent
    {
        private Date date;
        private Pawn pawn, animal;

        private List<int> yearsWhenEventStarted = new List<int>();

        public ABonded()
        {

        }

        public ABonded(Date date, Pawn pawn, Pawn animal)
        {
            this.date = date;
            this.pawn = pawn;
            this.animal = animal;
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
            throw new NotImplementedException();
        }

        public bool GetIsAnniversary()
        {
            throw new NotImplementedException();
        }

        public bool IsStillEvent()
        {
            throw new NotImplementedException();
        }

        public string ShowInLog()
        {
            return (date.day + " " + date.quadrum + " " + date.year + " " + "ABondedAnimal".Translate(new object[] {pawn.Name, animal.Name }));
        }

        public bool TryStartEvent()
        {
            return false;
        }

        public bool TryStartEvent(Map map)
        {
            return false;
        }
    }
}
