using HarmonyLib;

// ReSharper disable InconsistentNaming

namespace RepoLeveling;

[HarmonyPatch(typeof(StatsManager))]
internal static class StatsManagerPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(StatsManager.PlayerAdd))]
    private static void PlayerAdd_Postfix(string _steamID)
    {
        if (!SemiFunc.IsMasterClientOrSingleplayer() || !SemiFunc.RunIsLevel() || _steamID != PlayerController.instance.playerSteamID) return;
        RepoLeveling.Logger.LogDebug("Player data has been added.");
        SaveDataManager.ApplySkills();
    }
}