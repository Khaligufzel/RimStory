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

        Rect filterRect = new Rect();

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
                                if (!Resources.showRaidsInLog && e is ABigThreat){}
                                else if (!Resources.showDeadColonistsInLog && e is AMemorialDay) { }
                                else if (!Resources.showIncidentsInLog && e is IncidentShort) { }
                                else
                                {
                                    listing_Standard.AddLabelLine(e.ShowInLog());
                                    listing_Standard.AddHorizontalLine(3f);
                                }
                            }
                        }
                    }
                    if(Resources.eventsLog.Count == 0)
                    {
                        listing_Standard.AddLabelLine("Nothing here yet.");
                    }
                }

                Widgets.EndScrollView();

                

                listing_Standard.End();


                filterRect = new Rect(new Vector2(outter.width, rect.position.y), new Vector2(200, 200));
                listing_Standard.Begin(filterRect);
                listing_Standard.AddLabeledCheckbox("ShowRaidsInLog".Translate(), ref Resources.showRaidsInLog);
                listing_Standard.AddLabeledCheckbox("ShowDeadColonistsInLog".Translate(), ref Resources.showDeadColonistsInLog);
                listing_Standard.AddLabeledCheckbox("ShowIncidentsInLog".Translate(), ref Resources.showIncidentsInLog);

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
