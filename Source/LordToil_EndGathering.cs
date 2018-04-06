using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using Verse.AI.Group;

namespace RimStory 
{
    class LordToil_EndGathering : LordToil
    {
        public override bool ShouldFail
        {
            get
            {
                return true;
            }
        }

        public override void UpdateAllDuties()
        {
            
        }
    }
}
