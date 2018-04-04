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

            strinList[0] = "1111111111";
            strinList[1] = "2222222222";
            strinList[2] = "3333333333";
            strinList[3] = "44444444441";
            strinList[4] = "55555555555";

            Rect rect2 = new Rect(new Vector2(100,0), new Vector2(100,100));
            Vector2 vect = new Vector2(licz, licz);

            //listing_Standard.Begin(rect);
            Widgets.BeginScrollView(rect, ref vect, rect2, true);

            Log.Message(rect2+"");

            listing_Standard.AddLabelLine("RimStory");
            listing_Standard.AddHorizontalLine(3f);
            listing_Standard.AddLabeledRadioList("siema", strinList, ref strin);
            listing_Standard.AddHorizontalLine(3f);
            listing_Standard.AddLabeledNumericalTextField<int>("xxxxxxxxxxxxxxxxxx", ref licz, minValue: 0, maxValue: 2000);

            listing_Standard.AddHorizontalLine(3f);
            listing_Standard.AddHorizontalLine(3f);
            Widgets.EndScrollView();
            //Widgets.Sc(rect2, ref vect, rect);
            
            //listing_Standard.AddLabeledTextField("zzzzzzzzzzzzzzzzzz", ref strin);
            //listing_Standard.AddHorizontalLine(3f);
            //listing_Standard.Slider(licz, 0f, 6000f);
            //listing_Standard.AddHorizontalLine(3f);
            //listing_Standard.LineRectSpilter(out rect, 0.5f);



            //listing_Standard.End();
 

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
