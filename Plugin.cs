using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using ArFe_ChaosMod.Patches;
using Random = UnityEngine.Random;

namespace ArFe_ChaosMod
{
    [BepInPlugin(modGUID, modNAME, modVER)]
    public class Main : BaseUnityPlugin
    {
        // MOD Info
        public const string modGUID = "ArrFel.3xSpeedMod";
        public const string modNAME = "Arroz's 3x Speed Mod";
        public const string modVER = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        // Objects / References
        internal ManualLogSource mls;
        public static Main inst;

        void Awake() 
        {
            if (inst == null) { inst = this; }
            else if (inst != this) { Destroy(this); }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("3X Speed Mod has Awoken");

            mls.LogInfo("Patching Scripts...");
            harmony.PatchAll(typeof(Main));
            harmony.PatchAll(typeof(PlayerControllerB_Patch));
            mls.LogInfo("Patched Scripts.");
        }


    }
}
