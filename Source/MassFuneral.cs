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
    public static class MassFuneral
    {
        private static String deadPawnsNames = "";

        static MassFuneral()
        {
            
        }
       
        public static bool TryStartMassFuneral(Map map)
        {
            Pawn pawn = PartyUtility.FindRandomPartyOrganizer(Faction.OfPlayer,map);

            if (pawn == null)
            {
                return false;
            }
            IntVec3 intVec;
            if (!RCellFinder.TryFindPartySpot(pawn, out intVec))
            {
                return false;
            }
            foreach(Pawn deadPawn in Resources.deadPawnsForMassFuneral)
            {

            }
            foreach(Pawn deadPawn in Resources.deadPawnsForMassFuneralBuried)
            {
                deadPawnsNames = deadPawnsNames + deadPawn.Label + "\n";
            }
            Lord lord = LordMaker.MakeNewLord(pawn.Faction, new LordJob_RimStory(Resources.lastGrave.Position, pawn), map, null);
            Find.LetterStack.ReceiveLetter("Funeral", "Colonists are gathering to honor:\n\n"+deadPawnsNames, LetterDefOf.NeutralEvent, Resources.lastGrave);          
       
            deadPawnsNames = "";
            return true;

        }

    }
}
