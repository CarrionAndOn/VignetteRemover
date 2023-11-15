using BoneLib;
using MelonLoader;
using UnityEngine;
using BoneLib.BoneMenu;
using BoneLib.BoneMenu.Elements;
using HarmonyLib;
using VignetteRemover.Melon;

namespace VignetteRemover
{
    public class Main : MelonMod
    {
        internal const string Name = "Vignette Remover";
        internal const string Description = "Gives you the ability to remove the damage vignette.";
        internal const string Author = "SoulWithMae";
        internal const string Company = "Weather Electric";
        internal const string Version = "1.0.4";
        internal const string DownloadLink = "null";

        private static bool _enabled;
        private static GameObject _vignetteObj;
        public override void OnInitializeMelon()
        {
            ModConsole.Setup(LoggerInstance);
            Preferences.Setup();
            _enabled = Preferences.AutoDisable.Value;
            SetupBonemenu();
        }
        
        [HarmonyPatch(typeof(Player_Health), "MakeVignette")]
        public static class VignettePatch
        {
            public static void Postfix(Player_Health __instance)
            {
                _vignetteObj = __instance.Vignetter;
                if (_enabled && _vignetteObj != null)
                {
                    ModConsole.Msg("Vignette found, disabling.", 1);
                    _vignetteObj.SetActive(false);
                }
                else if (_vignetteObj == null)
                {
                    ModConsole.Error("Vignette not found!");
                }
                else
                {
                    ModConsole.Msg("Auto disable is off, not disabling vignette.", 1);
                }
            }
        }
        private static void SetupBonemenu()
        {
            MenuCategory mainCat = MenuManager.CreateCategory("Weather Electric", "#6FBDFF");
            MenuCategory menuCategory = mainCat.CreateCategory("Vignette Remover", Color.red);
            menuCategory.CreateBoolElement("Toggle Autodisable", Color.white, Preferences.AutoDisable.Value, OnBoolChanged);
            menuCategory.CreateFunctionElement("Enable Vignette", Color.green, Enable);
            menuCategory.CreateFunctionElement("Disable Vignette", Color.red, Disable);
        }

        private static void Enable()
        {
            ModConsole.Msg("Enabling vignette.", 1);
            _vignetteObj.SetActive(true);
        }

        private static void Disable()
        {
            ModConsole.Msg("Disabling vignette.", 1);
            _vignetteObj.SetActive(false);
        }
        
        private static void OnBoolChanged(bool value)
        {
            _enabled = value;
            Preferences.AutoDisable.Value = value;
            Preferences.OwnCategory.SaveToFile(false);
        }
    }
}