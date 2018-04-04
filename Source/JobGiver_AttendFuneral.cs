using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using Verse.AI;
using RimWorld;


namespace RimStory
{
    class JobGiver_AttendFuneral : ThinkNode_JobGiver
    {       
        protected override Job TryGiveJob(Pawn pawn)
        {
            
            
            Building_Grave grave = FindGrave();
            if (grave == null)
            {
                    return null;
            }

            return new Job(RS_JobDefOf.AttendFuneral, grave);
            
            
        }


        public override ThinkNode DeepCopy(bool resolve = true)
        {
            return base.DeepCopy(resolve);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override float GetPriority(Pawn pawn)
        {
            return base.GetPriority(pawn);
        }

        public override void ResolveReferences()
        {
            base.ResolveReferences();
        }

        public override ThinkResult TryIssueJobPackage(Pawn pawn, JobIssueParams jobParams)
        {
            return base.TryIssueJobPackage(pawn, jobParams);
        }

        protected override void ResolveSubnodes()
        {
            base.ResolveSubnodes();
        }

        private Building_Grave FindGrave()
        {
            return Resources.lastGrave;
        }
        
      
        public class RS_JobDefOf
        {
            public static JobDef AttendFuneral;
        }
    }
}
