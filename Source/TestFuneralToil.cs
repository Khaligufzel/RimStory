using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using Verse.AI;
using Verse.AI.Group;

namespace RimStory
{
    class TestFuneralToil : LordToil
    {
        // Token: 0x06000831 RID: 2097 RVA: 0x000435FB File Offset: 0x000419FB
        public TestFuneralToil(Pawn firstPawn, Pawn secondPawn, IntVec3 spot)
        {
            this.firstPawn = firstPawn;
            this.secondPawn = secondPawn;
            this.spot = spot;
            this.data = new LordToilData_MarriageCeremony();
        }

        // Token: 0x1700014A RID: 330
        // (get) Token: 0x06000832 RID: 2098 RVA: 0x00043623 File Offset: 0x00041A23
        public LordToilData_MarriageCeremony Data
        {
            get
            {
                return (LordToilData_MarriageCeremony)this.data;
            }
        }

        // Token: 0x06000833 RID: 2099 RVA: 0x00043630 File Offset: 0x00041A30
        public override void Init()
        {
            base.Init();
            this.Data.spectateRect = this.CalculateSpectateRect();
            SpectateRectSide allowedSides = SpectateRectSide.All;
            if (this.Data.spectateRect.Width > this.Data.spectateRect.Height)
            {
                allowedSides = SpectateRectSide.Vertical;
            }
            else if (this.Data.spectateRect.Height > this.Data.spectateRect.Width)
            {
                allowedSides = SpectateRectSide.Horizontal;
            }
            this.Data.spectateRectAllowedSides = SpectatorCellFinder.FindSingleBestSide(this.Data.spectateRect, base.Map, allowedSides, 1);
        }

        // Token: 0x06000834 RID: 2100 RVA: 0x000436CE File Offset: 0x00041ACE
        public override ThinkTreeDutyHook VoluntaryJoinDutyHookFor(Pawn p)
        {
            if (this.IsFiance(p))
            {
                return DutyDefOf.MarryPawn.hook;
            }
            return DutyDefOf.Spectate.hook;
        }

        // Token: 0x06000835 RID: 2101 RVA: 0x000436F4 File Offset: 0x00041AF4
        public override void UpdateAllDuties()
        {
            for (int i = 0; i < this.lord.ownedPawns.Count; i++)
            {
                Pawn pawn = this.lord.ownedPawns[i];
                if (this.IsFiance(pawn))
                {
                    pawn.mindState.duty = new PawnDuty(DutyDefOf.MarryPawn, this.FianceStandingSpotFor(pawn), -1f);
                }
                else
                {
                    PawnDuty pawnDuty = new PawnDuty(DutyDefOf.Spectate);
                    pawnDuty.spectateRect = this.Data.spectateRect;
                    pawnDuty.spectateRectAllowedSides = this.Data.spectateRectAllowedSides;
                    pawn.mindState.duty = pawnDuty;
                }
            }
        }

        // Token: 0x06000836 RID: 2102 RVA: 0x000437A4 File Offset: 0x00041BA4
        private bool IsFiance(Pawn p)
        {
            return p == this.firstPawn || p == this.secondPawn;
        }

        // Token: 0x06000837 RID: 2103 RVA: 0x000437C0 File Offset: 0x00041BC0
        public IntVec3 FianceStandingSpotFor(Pawn pawn)
        {
            Pawn pawn2;
            if (this.firstPawn == pawn)
            {
                pawn2 = this.secondPawn;
            }
            else
            {
                if (this.secondPawn != pawn)
                {
                    Log.Warning("Called ExactStandingSpotFor but it's not this pawn's ceremony.");
                    return IntVec3.Invalid;
                }
                pawn2 = this.firstPawn;
            }
            if (pawn.thingIDNumber < pawn2.thingIDNumber)
            {
                return this.spot;
            }
            if (this.GetMarriageSpotAt(this.spot) != null)
            {
                return this.FindCellForOtherPawnAtMarriageSpot(this.spot);
            }
            return this.spot + LordToil_MarriageCeremony.OtherFianceNoMarriageSpotCellOffset;
        }

        // Token: 0x06000838 RID: 2104 RVA: 0x00043855 File Offset: 0x00041C55
        private Thing GetMarriageSpotAt(IntVec3 cell)
        {
            return cell.GetThingList(base.Map).Find((Thing x) => x.def == ThingDefOf.MarriageSpot);
        }

        // Token: 0x06000839 RID: 2105 RVA: 0x00043888 File Offset: 0x00041C88
        private IntVec3 FindCellForOtherPawnAtMarriageSpot(IntVec3 cell)
        {
            Thing marriageSpotAt = this.GetMarriageSpotAt(cell);
            CellRect cellRect = marriageSpotAt.OccupiedRect();
            for (int i = cellRect.minX; i <= cellRect.maxX; i++)
            {
                for (int j = cellRect.minZ; j <= cellRect.maxZ; j++)
                {
                    if (cell.x != i || cell.z != j)
                    {
                        return new IntVec3(i, 0, j);
                    }
                }
            }
            Log.Warning("Marriage spot is 1x1. There's no place for 2 pawns.");
            return IntVec3.Invalid;
        }

        // Token: 0x0600083A RID: 2106 RVA: 0x00043914 File Offset: 0x00041D14
        private CellRect CalculateSpectateRect()
        {
            IntVec3 first = this.FianceStandingSpotFor(this.firstPawn);
            IntVec3 second = this.FianceStandingSpotFor(this.secondPawn);
            return CellRect.FromLimits(first, second);
        }

        // Token: 0x04000385 RID: 901
        private Pawn firstPawn;

        // Token: 0x04000386 RID: 902
        private Pawn secondPawn;

        // Token: 0x04000387 RID: 903
        private IntVec3 spot;

        // Token: 0x04000388 RID: 904
        public static readonly IntVec3 OtherFianceNoMarriageSpotCellOffset = new IntVec3(-1, 0, 0);
    }

}
