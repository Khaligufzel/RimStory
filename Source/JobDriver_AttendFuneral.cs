using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using Verse.AI;


namespace RimStory
{
    class JobDriver_AttendFuneral : JobDriver
    {
        private TargetIndex graveToVisit = TargetIndex.A;

        public override PawnPosture Posture => base.Posture;

        public override bool TryMakePreToilReservations()
        {
            
            return true;
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {

           
            this.FailOnDespawnedNullOrForbidden(graveToVisit);   
            

            yield return Toils_Goto.GotoThing(graveToVisit, PathEndMode.Touch);
           
            yield return Toils_General.Wait(1000);
            

            yield break;
            //yield return Toils_Interpersonal.WaitToBeAbleToInteract(this.pawn);
            //yield return Toils_Interpersonal.GotoInteractablePosition(graveToVisit);

            //Toil gotoTarget = Toils_Goto.GotoThing(graveToVisit, PathEndMode.Touch);
            //gotoTarget.socialMode = RandomSocialMode.Off;

            //Toil wait = Toils_General.WaitWith(graveToVisit, 4000, false, true);
            //Toil wait = Toils_General.Wait(4000);
            //wait.socialMode = RandomSocialMode.Off;
            //yield return Toils_General.Do(delegate
            //{
            //    Pawn petter = this.pawn;
            //    Building_Grave pettee = (Building_Grave)this.pawn.CurJob.targetA.Thing;
            //    //pettee.interactions.TryInteractWith(petter, InteractionDefOf.Nuzzle);
            //});

        }
    }
}
