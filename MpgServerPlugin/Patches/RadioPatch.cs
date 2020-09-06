using HarmonyLib;

namespace MpgServerPlugin.Patches
{
    [HarmonyPatch(typeof(Radio))]
    [HarmonyPatch(nameof(Radio.UseBattery))]
    internal static class RadioPatch
    {
        static bool Prefix(Radio __instance)
        {
            if (__instance.ccm.CurClass == RoleType.ChaosInsurgency) return true;

            if (__instance.ccm.CurClass == RoleType.Tutorial) return true;

            return false;
        }
    }
}
