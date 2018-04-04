using Harmony;
using System;
using System.Linq;
using System.Reflection;
using Verse;
using RimWorld;
using RimWorld.Planet;
using UnityEngine;

namespace RimStory
{

    public static class Utils
    {

        public static int CurrentDay()
        {
            Vector2 vector;
            if (WorldRendererUtility.WorldRenderedNow && Find.WorldSelector.selectedTile >= 0)
            {
                vector = Find.WorldGrid.LongLatOf(Find.WorldSelector.selectedTile);
            }
            else if (WorldRendererUtility.WorldRenderedNow && Find.WorldSelector.NumSelectedObjects > 0)
            {
                vector = Find.WorldGrid.LongLatOf(Find.WorldSelector.FirstSelectedObject.Tile);
            }
            else
            {
                if (Find.VisibleMap == null)
                {
                    return 0;
                }
                vector = Find.WorldGrid.LongLatOf(Find.VisibleMap.Tile);
            }
            int num = (Find.TickManager.gameStartAbsTick == 0) ? Find.TickManager.TicksGame : Find.TickManager.TicksAbs;

            return GenDate.DayOfSeason((long)num, vector.x) + 1;
        }

        public static int CurrentHour()
        {
            Vector2 vector;
            if (WorldRendererUtility.WorldRenderedNow && Find.WorldSelector.selectedTile >= 0)
            {
                vector = Find.WorldGrid.LongLatOf(Find.WorldSelector.selectedTile);
            }
            else if (WorldRendererUtility.WorldRenderedNow && Find.WorldSelector.NumSelectedObjects > 0)
            {
                vector = Find.WorldGrid.LongLatOf(Find.WorldSelector.FirstSelectedObject.Tile);
            }
            else
            {
                if (Find.VisibleMap == null)
                {
                    return 0;
                }
                vector = Find.WorldGrid.LongLatOf(Find.VisibleMap.Tile);
            }
            int num = (Find.TickManager.gameStartAbsTick == 0) ? Find.TickManager.TicksGame : Find.TickManager.TicksAbs;

            return GenDate.HourOfDay((long)num, vector.x) + 1;
        }

        public static Quadrum CurrentQuadrum()
        {
            Vector2 vector;
            if (WorldRendererUtility.WorldRenderedNow && Find.WorldSelector.selectedTile >= 0)
            {
                vector = Find.WorldGrid.LongLatOf(Find.WorldSelector.selectedTile);
            }
            else if (WorldRendererUtility.WorldRenderedNow && Find.WorldSelector.NumSelectedObjects > 0)
            {
                vector = Find.WorldGrid.LongLatOf(Find.WorldSelector.FirstSelectedObject.Tile);
            }
            else
            {
                if (Find.VisibleMap == null)
                {
                    return 0;
                }
                vector = Find.WorldGrid.LongLatOf(Find.VisibleMap.Tile);
            }
            int num = (Find.TickManager.gameStartAbsTick == 0) ? Find.TickManager.TicksGame : Find.TickManager.TicksAbs;
            return GenDate.Quadrum((long)num, vector.x);

        }

        public static int CurrentYear()
        {
            Vector2 vector;
            if (WorldRendererUtility.WorldRenderedNow && Find.WorldSelector.selectedTile >= 0)
            {
                vector = Find.WorldGrid.LongLatOf(Find.WorldSelector.selectedTile);
            }
            else if (WorldRendererUtility.WorldRenderedNow && Find.WorldSelector.NumSelectedObjects > 0)
            {
                vector = Find.WorldGrid.LongLatOf(Find.WorldSelector.FirstSelectedObject.Tile);
            }
            else
            {
                if (Find.VisibleMap == null)
                {
                    return 0;
                }
                vector = Find.WorldGrid.LongLatOf(Find.VisibleMap.Tile);
            }
            int num = (Find.TickManager.gameStartAbsTick == 0) ? Find.TickManager.TicksGame : Find.TickManager.TicksAbs;

            return GenDate.Year((long)num, vector.x);
        }

        public static Date CurrentDate()
        {
            Vector2 vector;
            if (WorldRendererUtility.WorldRenderedNow && Find.WorldSelector.selectedTile >= 0)
            {
                vector = Find.WorldGrid.LongLatOf(Find.WorldSelector.selectedTile);
            }
            else if (WorldRendererUtility.WorldRenderedNow && Find.WorldSelector.NumSelectedObjects > 0)
            {
                vector = Find.WorldGrid.LongLatOf(Find.WorldSelector.FirstSelectedObject.Tile);
            }
            else
            {
                if (Find.VisibleMap == null)
                {
                    return null;
                }
                vector = Find.WorldGrid.LongLatOf(Find.VisibleMap.Tile);
            }
            int num = (Find.TickManager.gameStartAbsTick == 0) ? Find.TickManager.TicksGame : Find.TickManager.TicksAbs;
            int day = GenDate.DayOfSeason((long)num, vector.x) + 1;

            
            if (WorldRendererUtility.WorldRenderedNow && Find.WorldSelector.selectedTile >= 0)
            {
                vector = Find.WorldGrid.LongLatOf(Find.WorldSelector.selectedTile);
            }
            else if (WorldRendererUtility.WorldRenderedNow && Find.WorldSelector.NumSelectedObjects > 0)
            {
                vector = Find.WorldGrid.LongLatOf(Find.WorldSelector.FirstSelectedObject.Tile);
            }
            else
            {
                if (Find.VisibleMap == null)
                {
                    return null;
                }
                vector = Find.WorldGrid.LongLatOf(Find.VisibleMap.Tile);
            }
            int num2 = (Find.TickManager.gameStartAbsTick == 0) ? Find.TickManager.TicksGame : Find.TickManager.TicksAbs;
            Quadrum quadrum = GenDate.Quadrum((long)num2, vector.x);

            if (WorldRendererUtility.WorldRenderedNow && Find.WorldSelector.selectedTile >= 0)
            {
                vector = Find.WorldGrid.LongLatOf(Find.WorldSelector.selectedTile);
            }
            else if (WorldRendererUtility.WorldRenderedNow && Find.WorldSelector.NumSelectedObjects > 0)
            {
                vector = Find.WorldGrid.LongLatOf(Find.WorldSelector.FirstSelectedObject.Tile);
            }
            else
            {
                if (Find.VisibleMap == null)
                {
                    return null;
                }
                vector = Find.WorldGrid.LongLatOf(Find.VisibleMap.Tile);
            }
            int num3 = (Find.TickManager.gameStartAbsTick == 0) ? Find.TickManager.TicksGame : Find.TickManager.TicksAbs;

            int year = GenDate.Year((long)num3, vector.x);
            

            return new Date(day, quadrum, year);
        }

        
    }
}
