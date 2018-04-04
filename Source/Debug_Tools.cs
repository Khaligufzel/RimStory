using Harmony;
using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;


namespace RimStory
{
    //[HarmonyPatch(typeof(Dialog_DebugActionsMenu))]
    //[HarmonyPatch("DoListingItems_AllModePlayActions")]
    class Debug_Tools : Dialog_DebugOptionLister
    {
        static void Postfix(Dialog_DebugActionsMenu __instance)
        {

        }

        protected override void DoListingItems()
        {           
        }

        private void MakeNewButton()
        {
            base.DebugAction("Generate map", delegate
            {
                MapParent mapParent = (MapParent)WorldObjectMaker.MakeWorldObject(WorldObjectDefOf.FactionBase);
                mapParent.Tile = TileFinder.RandomStartingTile();
                mapParent.SetFaction(Faction.OfPlayer);
                Find.WorldObjects.Add(mapParent);
                GetOrGenerateMapUtility.GetOrGenerateMap(mapParent.Tile, new IntVec3(50, 1, 50), null);
            });
        }
    }
}
