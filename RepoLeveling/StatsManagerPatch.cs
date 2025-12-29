using HarmonyLib;

// ReSharper disable InconsistentNaming

namespace RepoLeveling;

[HarmonyPatch(typeof(StatsManager))]
internal static class StatsManagerPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(StatsManager.PlayerAdd))]
    private static void PlayerAdd_Postfix(string _steamID)
    {
        RepoLeveling.Logger.LogInfo($"PlayerAdd_Postfix called with _steamID: {_steamID}, Current PlayerSteamID: {PlayerController.instance.playerSteamID}, Avatar SteamID: {PlayerAvatar.instance.steamID}, IsMasterClientOrSingleplayer: {SemiFunc.IsMasterClientOrSingleplayer()}, RunIsLevel: {SemiFunc.RunIsLevel()}");
        if (!SemiFunc.IsMasterClientOrSingleplayer() || !SemiFunc.RunIsLevel() || _steamID != PlayerController.instance.playerSteamID) return;
        RepoLeveling.Logger.LogInfo("PlayerAdd_Postfix: Conditions met for applying skills.");
        RepoLeveling.Logger.LogDebug("Player data has been added.");
        SaveDataManager.ApplySkills();
    }
}
