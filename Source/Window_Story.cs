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
        private static int sie = 0;
        private static Vector2 vect = new Vector2(sie, sie);
        Listing_Standard listing_Standard = new Listing_Standard();

        bool sett;
        int xxx;
        int yyy;
        List<String> lista = new List<string>();
        

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





            Rect rect2 = new Rect(rect.position, new Vector2(rect.x-100, 2000));
            Rect rect3 = new Rect(new Vector2(0,0), new Vector2(100, 2000));

          
            

            Widgets.BeginScrollView(rect, ref vect, rect2, true);
            listing_Standard.Begin(rect);

            listing_Standard.AddLabelLine("RimHell");
            listing_Standard.AddHorizontalLine(3f);
            //listing_Standard.AddLabeledRadioList("thehell", , ref strin);
            listing_Standard.AddHorizontalLine(3f);
            //listing_Standard.AddLabeledNumericalTextField<int>("hellhellhellhell", ref xxx, minValue: 0, maxValue: 2000);

            listing_Standard.AddHorizontalLine(3f);
            listing_Standard.AddHorizontalLine(3f);
            listing_Standard.End();
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
