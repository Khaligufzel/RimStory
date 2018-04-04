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
    class Breakup : IEvent
    {
        private Date date;
        private Pawn pawn1, pawn2;
        private Thought thought;
        private bool anniversary = true;
        private List<int> yearsWhenEventStarted = new List<int>();

        public Breakup()
        {

        }

        public Breakup(Date date, Pawn pawn1, Pawn pawn2, Thought thought)
        {
            this.date = date;
            this.pawn1 = pawn1;
            this.pawn2 = pawn2;
            this.thought = thought;
        }



        public Date Date()
        {
            throw new NotImplementedException();
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

        public bool TryStartEvent()
        {
            return false;
        }

        public bool TryStartEvent(Map map)
        {
            throw new NotImplementedException();
        }
    }
}
