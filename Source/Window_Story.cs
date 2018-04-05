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
        private static Vector2 logSize = new Vector2();
        Listing_Standard listing_Standard = new Listing_Standard();
        Rect inner = new Rect();
        Rect outter = new Rect();


        private static int defaultLogSize = 1000;
       
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

            logSize = new Vector2(rect.x, defaultLogSize+(30f*Resources.eventsLog.Count));

            inner = new Rect(rect.position, logSize);
            outter = new Rect(rect.position, new Vector2(rect.width - 200, rect.height));


            Widgets.BeginScrollView(outter, ref vect, inner, true);
            listing_Standard.Begin(rect);

            foreach (IEvent e in Resources.eventsLog)
            {
                listing_Standard.AddLabelLine(e.ShowInLog());
                listing_Standard.AddHorizontalLine(3f);

            }
           
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
