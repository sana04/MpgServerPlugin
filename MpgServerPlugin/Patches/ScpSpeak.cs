using Assets._Scripts.Dissonance;
using HarmonyLib;

namespace MpgServerPlugin.Patches
{
    [HarmonyPatch(typeof(DissonanceUserSetup), nameof(DissonanceUserSetup.CallCmdAltIsActive))]
    class ScpSpeak
    {
        public static bool Prefix(DissonanceUserSetup __instance, bool value)
        {
            CharacterClassManager ccm = __instance.gameObject.GetComponent<CharacterClassManager>();

            if (ccm.CurClass == RoleType.Scp106 || ccm.CurClass == RoleType.Scp0492 || ccm.CurClass == RoleType.Scp049 || ccm.CurClass.Is939())
                __instance.MimicAs939 = value;

            return true;
        }
    }
}
