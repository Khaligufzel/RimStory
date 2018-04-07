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
            throw new NotImplementedException();
        }

        public bool IsStillEvent()
        {
            throw new NotImplementedException();
        }

        public string ShowInLog()
        {
            return (date.day + " " + date.quadrum + " " + date.year + " " + "ABreakup".Translate(new object[] {pawn1.Name, pawn2.Name }));
            //return (date.day + " " + date.quadrum + " " + date.year + " " + pawn1.Name + " brokeup with " + pawn2.Name  );
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
