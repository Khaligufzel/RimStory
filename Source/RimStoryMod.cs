using SettingsHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace RimStory
{
    class RimStoryMod : Mod
    {
        public static RimStorySettings settings;

        public RimStoryMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<RimStorySettings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);
            listing_Standard.AddLabeledCheckbox("EnEventLogger".Translate(), ref settings.enableLogging);
            listing_Standard.AddLabeledCheckbox("EnFunerals".Translate(), ref settings.enableFunerals);
            listing_Standard.AddLabeledCheckbox("EnMarriage".Translate(), ref settings.enableMarriageAnniversary);
            listing_Standard.AddLabeledCheckbox("EnMemorialDay".Translate(), ref settings.enableMemoryDay);
            listing_Standard.AddLabeledCheckbox("EnDaysOfVictory".Translate(), ref settings.enableDaysOfVictory);
            listing_Standard.AddLabeledCheckbox("EnIndividualThoughts".Translate(), ref settings.enableIndividualThoughts);
            if (Prefs.DevMode)
            {
                listing_Standard.AddLabeledCheckbox("LOG RESET? LOG RESET? LOG RESET?", ref settings.ISLOGGONNARESET);
            }
            //listing_Standard.AddLabeledCheckbox("Enable funeral" + ": ", ref settings.enableFunerals);
            //listing_Standard.AddLabeledCheckbox("Enable marriage anniversaries " + ": ", ref settings.enableMarriageAnniversary);
            //listing_Standard.AddLabeledCheckbox("Enable Memorial Day " + ": ", ref settings.enableMemoryDay);
            //listing_Standard.AddLabeledCheckbox("Enable Days of Victory " + ": ", ref settings.enableDaysOfVictory);
            //listing_Standard.AddLabeledCheckbox("Enable individual thoughts " + ": ", ref settings.enableIndividualThoughts);
            listing_Standard.End();
            settings.Write();
        }

        public override string SettingsCategory() => "RimStory";
        

        public override void WriteSettings()
        {
            base.WriteSettings();
        }
    }
}
