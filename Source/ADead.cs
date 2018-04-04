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
    class ADead : IEvent
    {
        private Date date;
        private Pawn deadPawn;
        private bool anniversary = true;
        private List<int> yearsWhenEventStarted = new List<int>();

        public ADead()
        {

        }

        public ADead(Date date, Pawn deadPawn)
        {
            this.date = date;
            this.deadPawn = deadPawn;         
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
            
            IEnumerable<Pawn> directRelations = deadPawn.relations.RelatedPawns;
            

            if (Utils.CurrentDay() == date.day && Utils.CurrentQuadrum() == date.quadrum && Utils.CurrentYear() != date.year)
            {


                //foreach (Pawn p in deadPawn.relations.PotentiallyRelatedPawns)
                //{
                //    foreach (PawnRelationDef item in p.GetRelations(deadPawn))
                //    {

                //        Log.Message(p + " " + item + deadPawn);
                //    }
                   
                //}

                foreach (Pawn p in deadPawn.relations.PotentiallyRelatedPawns)
                {
                    if (!p.Dead && p != null)
                    {
                        foreach (PawnRelationDef item in p.GetRelations(deadPawn))
                        {
                            Log.Message(p + " " + item + " " + deadPawn);

                        if (item == PawnRelationDefOf.Fiance)
                            {
                                p.needs.mood.thoughts.memories.TryGainMemory(Thoughts.RS_DayDiedFiance);
                                Log.Warning("thought should be added.");
                            }
                        if (item == PawnRelationDefOf.Lover)
                            {
                                p.needs.mood.thoughts.memories.TryGainMemory(Thoughts.RS_DayDiedLover);
                                Log.Warning("thought should be added.");
                            }
                        if (item == PawnRelationDefOf.Spouse)
                            {
                                Log.Warning("thought should be added.");
                                p.needs.mood.thoughts.memories.TryGainMemory(Thoughts.RS_DayDiedSpouse);
                            }

                        if (p.relations.DirectRelationExists(PawnRelationDefOf.Parent, deadPawn))
                            {

                            Log.Warning("thought should be added.");
                            p.needs.mood.thoughts.memories.TryGainMemory(Thoughts.RS_DayDiedFather);
                            }
                        if (p.relations.DirectRelationExists(PawnRelationDefOf.Parent, deadPawn))
                        {
                                p.needs.mood.thoughts.memories.TryGainMemory(Thoughts.RS_DayDiedFiance);
                        }
                        if (item == PawnRelationDefOf.Child)
                            {
                                Log.Warning("thought should be added.");
                                p.needs.mood.thoughts.memories.TryGainMemory(Thoughts.RS_DayDiedChild);
                            }
                        if (item == PawnRelationDefOf.Sibling)
                            {
                                Log.Warning("thought should be added.");
                                p.needs.mood.thoughts.memories.TryGainMemory(Thoughts.RS_DayDiedSibling);
                            }
                        }
                    }
                }

                


                //Log.Message("Relacje?");
                //foreach (Pawn p in map.mapPawns.FreeColonists)
                //{

                //}


                //if (Utils.CurrentDay() == date.day && Utils.CurrentHour() >= Resources.minHour && Utils.CurrentHour() <= Resources.maxHour && Utils.CurrentYear() != date.year)
                //{
                //    AddDeadOfRelativeThoughts(deadPawn);

                //    //Find.LetterStack.ReceiveLetter("test", "test", LetterDefOf.PositiveEvent);

                //    return true;
                //}
                //return false;
            }

            return true;
            
        }

        private void AddDeadOfRelativeThoughts(Pawn pawn)
        {
            pawn.needs.mood.thoughts.memories.TryGainMemory(Thoughts.RS_AttendedMemorialDay);
        }
    }
}
