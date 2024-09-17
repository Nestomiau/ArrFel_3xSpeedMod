using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace ArFe_ChaosMod.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerB_Patch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void Update_PostUpdate(ref bool ___isSprinting, ref float ___sprintMultiplier)
        {
            if (___isSprinting) 
            {
                ___sprintMultiplier = Mathf.Lerp(___sprintMultiplier,
                                            6.75f,
                                            Time.deltaTime * 30f);
            }
        }
    }
}
