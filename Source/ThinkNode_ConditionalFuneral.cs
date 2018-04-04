using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using Verse.AI;
using Verse.AI.Group;

namespace RimStory
{
    class ThinkNode_ConditionalFuneral : ThinkNode_Priority
    {
        // Token: 0x060008B4 RID: 2228 RVA: 0x00046A24 File Offset: 0x00044E24
        public override ThinkNode DeepCopy(bool resolve = true)
        {
            ThinkNode_JoinVoluntarilyJoinableLord thinkNode_JoinVoluntarilyJoinableLord = (ThinkNode_JoinVoluntarilyJoinableLord)base.DeepCopy(resolve);
            thinkNode_JoinVoluntarilyJoinableLord.dutyHook = this.dutyHook;
            return thinkNode_JoinVoluntarilyJoinableLord;
        }

        // Token: 0x060008B5 RID: 2229 RVA: 0x00046A4C File Offset: 0x00044E4C
        public override ThinkResult TryIssueJobPackage(Pawn pawn, JobIssueParams jobParams)
        {
            this.CheckLeaveCurrentVoluntarilyJoinableLord(pawn);
            this.JoinVoluntarilyJoinableLord(pawn);
            if (pawn.GetLord() != null && (pawn.mindState.duty == null || pawn.mindState.duty.def.hook == this.dutyHook))
            {
                return base.TryIssueJobPackage(pawn, jobParams);
            }
            return ThinkResult.NoJob;
        }

        // Token: 0x060008B6 RID: 2230 RVA: 0x00046AB0 File Offset: 0x00044EB0
        private void CheckLeaveCurrentVoluntarilyJoinableLord(Pawn pawn)
        {
            Lord lord = pawn.GetLord();
            if (lord == null)
            {
                return;
            }
            LordJob_VoluntarilyJoinable lordJob_VoluntarilyJoinable = lord.LordJob as LordJob_VoluntarilyJoinable;
            if (lordJob_VoluntarilyJoinable == null)
            {
                return;
            }
            if (lordJob_VoluntarilyJoinable.VoluntaryJoinPriorityFor(pawn) <= 0f)
            {
                lord.Notify_PawnLost(pawn, PawnLostCondition.LeftVoluntarily);
            }
        }

        // Token: 0x060008B7 RID: 2231 RVA: 0x00046AF8 File Offset: 0x00044EF8
        private void JoinVoluntarilyJoinableLord(Pawn pawn)
        {
            Lord lord = pawn.GetLord();
            Lord lord2 = null;
            float num = 0f;
            if (lord != null)
            {
                LordJob_VoluntarilyJoinable lordJob_VoluntarilyJoinable = lord.LordJob as LordJob_VoluntarilyJoinable;
                if (lordJob_VoluntarilyJoinable == null)
                {
                    return;
                }
                lord2 = lord;
                num = lordJob_VoluntarilyJoinable.VoluntaryJoinPriorityFor(pawn);
            }
            List<Lord> lords = pawn.Map.lordManager.lords;
            for (int i = 0; i < lords.Count; i++)
            {
                LordJob_VoluntarilyJoinable lordJob_VoluntarilyJoinable2 = lords[i].LordJob as LordJob_VoluntarilyJoinable;
                if (lordJob_VoluntarilyJoinable2 != null)
                {
                    if (lords[i].CurLordToil.VoluntaryJoinDutyHookFor(pawn) == this.dutyHook)
                    {
                        float num2 = lordJob_VoluntarilyJoinable2.VoluntaryJoinPriorityFor(pawn);
                        if (num2 > 0f)
                        {
                            if (lord2 == null || num2 > num)
                            {
                                lord2 = lords[i];
                                num = num2;
                            }
                        }
                    }
                }
            }
            if (lord2 != null && lord != lord2)
            {
                if (lord != null)
                {
                    lord.Notify_PawnLost(pawn, PawnLostCondition.LeftVoluntarily);
                }
                lord2.AddPawn(pawn);
            }
        }

        // Token: 0x040003BE RID: 958
        public ThinkTreeDutyHook dutyHook;
    }

}
