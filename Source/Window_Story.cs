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
        public static int sie = 0;
        public static Vector2 vect = new Vector2(sie, sie);
        public static Vector2 logSize = new Vector2();
        Listing_Standard listing_Standard = new Listing_Standard();
        Rect inner = new Rect();
        Rect outter = new Rect();
        Rect bigRect = new Rect();


        private static int defaultLogSize = 1000;
       
       
        

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
            if (RimStoryMod.settings.enableLogging)
            {
                bigRect = rect;

                bigRect = new Rect(rect.position, new Vector2(rect.width, defaultLogSize + (35f * Resources.eventsLog.Count)));
                logSize = new Vector2(rect.x, defaultLogSize + (35f * Resources.eventsLog.Count));
                inner = new Rect(rect.position, logSize);
                outter = new Rect(rect.position, new Vector2(rect.width - 200, rect.height));

                listing_Standard.Begin(bigRect);
                Widgets.BeginScrollView(outter, ref vect, inner, true);

                if (Resources.eventsLog != null)
                {
                    foreach (IEvent e in Resources.eventsLog)
                    {
                        if (e != null)
                        {
                            if (e.ShowInLog() != null)
                            {
                                listing_Standard.AddLabelLine(e.ShowInLog());
                                listing_Standard.AddHorizontalLine(3f);
                            }
                            else
                            {
                                listing_Standard.AddLabelLine("Sorry, I can't show record. Report to dev please. PS: I love you! ");
                                listing_Standard.AddHorizontalLine(3f);
                            }
                        }
                    }
                }

                Widgets.EndScrollView();

                listing_Standard.End();
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
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

        public void ExposeData()
        {
           // throw new NotImplementedException();
        }
    }
}
