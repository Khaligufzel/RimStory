using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using UnityEngine;
using Verse;
using SettingsHelper;

namespace RimStory
{
    class Window_Story : MainTabWindow
    {
        Listing_Standard listing_Standard = new Listing_Standard();

        bool sett;
        int licz = 20;
        String strin = "siemaneczkooo";
        String[] strinList = new String[5];

        public override bool CausesMessageBackground()
        {
            return base.CausesMessageBackground();
        }

        public override void Close(bool doCloseSound = true)
        {
            base.Close(doCloseSound);
        }

        public override void DoWindowContents(Rect rect)
        {
            base.DoWindowContents(rect);

            strinList[0] = "111111test1111";
            strinList[1] = "22222test22222";
            strinList[2] = "333333test3333";
            strinList[3] = "444444test44444";
            strinList[4] = "5555555test5555";

            Rect rect2 = new Rect(new Vector2(100,0), new Vector2(100,100));
            Vector2 vect = new Vector2(licz, licz);

            Widgets.BeginScrollView(rect, ref vect, rect2, true);


            listing_Standard.AddLabelLine("RimHell");
            listing_Standard.AddHorizontalLine(3f);
            listing_Standard.AddLabeledRadioList("thehell", strinList, ref strin);
            listing_Standard.AddHorizontalLine(3f);
            listing_Standard.AddLabeledNumericalTextField<int>("hellhellhellhell", ref licz, minValue: 0, maxValue: 2000);

            listing_Standard.AddHorizontalLine(3f);
            listing_Standard.AddHorizontalLine(3f);
            Widgets.EndScrollView();
       
 

        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override void ExtraOnGUI()
        {
            base.ExtraOnGUI();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void Notify_ResolutionChanged()
        {
            base.Notify_ResolutionChanged();
        }

        public override void PostClose()
        {
            base.PostClose();
        }

        public override void PostOpen()
        {
            base.PostOpen();
        }

        public override void PreClose()
        {
            base.PreClose();
        }

        public override void PreOpen()
        {
            base.PreOpen();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void WindowOnGUI()
        {
            base.WindowOnGUI();
        }

        public override void WindowUpdate()
        {
            base.WindowUpdate();
        }

        protected override void SetInitialSizeAndPosition()
        {
            base.SetInitialSizeAndPosition();
        }
    }
}
