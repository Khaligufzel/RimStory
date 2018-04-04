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
    class LordToil_Gathering : LordToil
    {
        // Token: 0x0600083F RID: 2111 RVA: 0x000439A9 File Offset: 0x00041DA9
        public LordToil_Gathering(IntVec3 spot, int ticksPerPartyPulse = 600)
        {
            this.spot = spot;
            this.ticksPerPartyPulse = ticksPerPartyPulse;
            this.data = new LordToilData_Party();
            this.Data.ticksToNextPulse = ticksPerPartyPulse;
        }

        // Token: 0x1700014B RID: 331
        // (get) Token: 0x06000840 RID: 2112 RVA: 0x000439E1 File Offset: 0x00041DE1
        private LordToilData_Party Data
        {
            get
            {
                return (LordToilData_Party)this.data;
            }
        }

        // Token: 0x06000841 RID: 2113 RVA: 0x000439EE File Offset: 0x00041DEE
        public override ThinkTreeDutyHook VoluntaryJoinDutyHookFor(Pawn p)
        {            
            return DefDatabase<DutyDef>.GetNamed("Funeral", true).hook;
        }

        // Token: 0x06000842 RID: 2114 RVA: 0x000439FC File Offset: 0x00041DFC
        public override void UpdateAllDuties()
        {
            for (int i = 0; i < this.lord.ownedPawns.Count; i++)
            {
                this.lord.ownedPawns[i].mindState.duty = new PawnDuty(DutyDefOf.Party, this.spot, -1f);
            }
        }

        // Token: 0x06000843 RID: 2115 RVA: 0x00043A60 File Offset: 0x00041E60
        public override void LordToilTick()
        {
            if (--this.Data.ticksToNextPulse <= 0)
            {
                this.Data.ticksToNextPulse = this.ticksPerPartyPulse;
                List<Pawn> ownedPawns = this.lord.ownedPawns;
                for (int i = 0; i < ownedPawns.Count; i++)
                {
                    if (PartyUtility.InPartyArea(ownedPawns[i].Position, this.spot, base.Map))
                    {
                        //ownedPawns[i].needs.mood.thoughts.memories.TryGainMemory(ThoughtDefOf.AttendedParty, null);
                        LordJob_RimStory lordJob_Joinable_Party = this.lord.LordJob as LordJob_RimStory;
                        if (lordJob_Joinable_Party != null)
                        {
                            TaleRecorder.RecordTale(TaleDefOf.AttendedParty, new object[]
                            {
                                ownedPawns[i],
                                lordJob_Joinable_Party.Organizer
                            });
                        }
                    }
                }
            }
        }

        // Token: 0x0400038C RID: 908
        private IntVec3 spot;

        // Token: 0x0400038D RID: 909
        private int ticksPerPartyPulse = 600;

        // Token: 0x0400038E RID: 910
        private const int DefaultTicksPerPartyPulse = 600;
    }
}
