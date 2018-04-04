using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using UnityEngine;
using Verse;

namespace RimStory
{
    class Window_Story : MainTabWindow
    {
        
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

            // Make a background box
            GUI.Box(new Rect(10, 10, 100, 300), "Loader Menu");

        
            if (GUI.Button(new Rect(20, 40, 80, 20), "Level 1"))
            {
               // MassFuneral.TryStartMassFuneral(Resources.deadPawnsForMassFuneral, Resources.lastDeadPawn.Map);
                
            }

            
            if (GUI.Button(new Rect(20, 70, 80, 20), "Level 2"))
            {               
            }
          
            if (GUI.Button(new Rect(20, 100, 80, 20), "Level 2"))
            {

            }
         
            if (GUI.Button(new Rect(20, 130, 80, 20), "Level 2"))
            {
            }
   
            if (GUI.Button(new Rect(20, 160, 80, 20), "Level 2"))
            {
            }
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
