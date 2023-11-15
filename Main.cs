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
        internal const string Version = "1.0.2";
        internal const string DownloadLink = "null";

        private static bool _enabled;
        private static GameObject _vignetteObj;
        public override void OnInitializeMelon()
        {
            ModConsole.Setup(LoggerInstance);
            Preferences.Setup();
            _enabled = Preferences.AutoDisable;
            SetupBonemenu();
        }
        
        [HarmonyPatch(typeof(Player_Health), "MakeVignette")]
        public static class VignettePatch
        {
            public static void Postfix(Player_Health __instance)
            {
                var playerHead = Player.playerHead;
                _vignetteObj = playerHead.FindChild("Vignetter(Clone)").gameObject;
                if (_enabled && _vignetteObj != null)
                {
                    ModConsole.Msg("Vignette found, disabling.", LoggingMode.DEBUG);
                    _vignetteObj.SetActive(false);
                }
                else
                {
                    ModConsole.Error("Vignette not found!");
                }
            }
        }
        private static void SetupBonemenu()
        {
            MenuCategory mainCat = MenuManager.CreateCategory("Weather Electric", "#6FBDFF");
            MenuCategory menuCategory = mainCat.CreateCategory("Vignette Remover", Color.red);
            menuCategory.CreateBoolElement("Toggle Autodisable", Color.white, Preferences.AutoDisable.entry.Value, OnBoolChanged);
            menuCategory.CreateFunctionElement("Enable Vignette", Color.green, Enable);
            menuCategory.CreateFunctionElement("Disable Vignette", Color.red, Disable);
        }

        private static void Enable()
        {
            ModConsole.Msg("Enabling vignette.", LoggingMode.DEBUG);
            _vignetteObj.SetActive(true);
        }

        private static void Disable()
        {
            ModConsole.Msg("Disabling vignette.", LoggingMode.DEBUG);
            _vignetteObj.SetActive(false);
        }
        
        private static void OnBoolChanged(bool value)
        {
            _enabled = value;
            Preferences.AutoDisable.entry.Value = value;
            Preferences.OwnCategory.SaveToFile(false);
        }
    }
}