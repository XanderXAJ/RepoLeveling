using HarmonyLib;

namespace RepoLeveling;

[HarmonyPatch(typeof(PunManager))]
internal static class PunManagerPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(PunManager.ReceiveSyncData))]
    private static void ReceiveSyncData_Postfix(bool finalChunk)
    {
        if (!finalChunk) return;
        RepoLeveling.Logger.LogInfo("ReceiveSyncData_Postfix: Conditions met for applying skills.");
        RepoLeveling.Logger.LogDebug("Client sync complete.");
        SaveDataManager.ApplySkills();
    }
}
