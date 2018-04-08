using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace RimStory 
{
    class RimStorySettings : ModSettings
    {
        public bool enableAll = true;
        public bool enableFunerals = true;
        public bool enableMemoryDay = true;
        public bool enableMarriageAnniversary = true;
        public bool enableIndividualThoughts = true;
        public bool enableDaysOfVictory = true;
        public bool enableLogging = true;
        public bool ISLOGGONNARESET = false;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref this.enableFunerals, "enableFunerals", true);
            Scribe_Values.Look(ref this.enableMemoryDay, "enableMemoryDay", true);
            Scribe_Values.Look(ref this.enableMarriageAnniversary, "enableMarriageAnniversary", true);
            Scribe_Values.Look(ref this.enableIndividualThoughts, "enableIndividualThoughts", true);
            Scribe_Values.Look(ref this.enableDaysOfVictory, "enableDaysOfVictory", true);
            Scribe_Values.Look(ref this.enableLogging, "enableLogging", true);
        }
    }
}
