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
    //public class Funeral : IEvent
    //{
    //    private Date date;
    //    private Pawn deadPawn;
    //    private bool anniversary = false;

    //    public Funeral()
    //    {

    //    }



    //    public Funeral(Date date, Pawn deadPawn)
    //    {
    //        this.date = date;
    //        this.deadPawn = deadPawn;

    
    //        if(Utils.CurrentDay() < 7)
    //        {
    //            this.date.day = 7;
    //        }
    //        if(Utils.CurrentDay() > 7 && Utils.CurrentDay() < 15)
    //        {
    //            this.date.day = 15;
    //        }
    //        if(Utils.CurrentDay() == 15)
    //        {
    //            this.date.day = 7;
    //        }

    //        if(Utils.CurrentDay() == 7)
    //        {
    //            this.date.day = 15;
    //        }
            

          

    //    }

    //    public Date Date()
    //    {
    //        return date;
    //    }

    //    public void EndEvent()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void ExposeData()
    //    {
            
    //    }

    //    public bool GetIsAnniversary()
    //    {
    //        return anniversary;
    //    }

    //    public bool IsStillEvent()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public string Show()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool TryStartEvent()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool TryStartEvent(Map map)
    //    {

    //        Pawn pawn = PartyUtility.FindRandomPartyOrganizer(Faction.OfPlayer, map);


    //        if (Utils.CurrentDay() == date.day && Utils.CurrentHour() >= Resources.minHour && Utils.CurrentHour() <= Resources.maxHour && Resources.lastGrave != null )
    //        {
    //            if (pawn == null)
    //            {
    //                return false;
    //            }
    //            IntVec3 intVec;
    //            if (!RCellFinder.TryFindPartySpot(pawn, out intVec))
    //            {
    //                return false;
    //            }


    //            Lord lord = LordMaker.MakeNewLord(pawn.Faction, new LordJob_RimStory(Resources.lastGrave.Position, pawn), map, null);
    //            Find.LetterStack.ReceiveLetter("Funeral", "Colonist are gathering for " + deadPawn.LabelShort + " funeral.", LetterDefOf.NeutralEvent, Resources.lastGrave);

    //            Resources.eventsToDelete.Add(this);              

    //            foreach (Pawn p in pawn.Map.mapPawns.FreeColonists)
    //            {
    //                AddAttendedFuneralThoughts(p);
    //            }              
    //            return true;
    //        }

    //        return false;
    //    }

    //    private void AddAttendedFuneralThoughts(Pawn pawn)
    //    {
    //        pawn.needs.mood.thoughts.memories.TryGainMemory(Thoughts.RS_AttendedFuneral);
    //    }
    //}
}
