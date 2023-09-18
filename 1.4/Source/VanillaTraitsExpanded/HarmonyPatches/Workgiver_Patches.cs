using HarmonyLib;
using RimWorld;
using Verse;

namespace VanillaTraitsExpanded
{
	[HarmonyPatch(typeof(WorkGiver_Researcher))]
	[HarmonyPatch(nameof(WorkGiver_Researcher.ShouldSkip))]
	public static class Researcher_ShouldSkip_Patch
    {
		private static void Postfix(ref bool __result, Pawn pawn)
		{
			if (pawn.HasTrait(VTEDefOf.VTE_Technophobe) && Find.ResearchManager.currentProj?.techLevel > TechLevel.Medieval)
            {
				__result = true;
            }
		}
	}

    [HarmonyPatch(typeof(WorkGiver_HunterHunt))]
    [HarmonyPatch(nameof(WorkGiver_HunterHunt.ShouldSkip))]
    public static class HunterHunt_ShouldSkip_Patch
    {
        private static void Postfix(ref bool __result, Pawn pawn)
        {
            if (pawn.HasTrait(VTEDefOf.VTE_AnimalLover))
            {
                __result = true;
            }
        }
    }

    [HarmonyPatch(typeof(WorkGiver_HunterHunt))]
    [HarmonyPatch("CanFindHuntingPosition")]
    public static class HunterHunt_CanFindHuntingPosition_Patch
    {
        private static void Postfix(ref bool __result, Pawn hunter, Pawn animal)
        {
            if (hunter.HasTrait(VTEDefOf.VTE_CatPerson) && Globals.cats.Contains(animal.def.defName))
            {
                __result = false;
            }

            if (hunter.HasTrait(VTEDefOf.VTE_DogPerson) && Globals.dogs.Contains(animal.def.defName))
            {
                __result = false;
            }
        }
    }
}
