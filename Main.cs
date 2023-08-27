using MelonLoader;
using UnityEngine;
using BoneLib.BoneMenu;
using BoneLib.BoneMenu.Elements;
using HarmonyLib;

namespace VignetteRemover
{
    public class Main : MelonMod
    {
        internal const string Name = "Vignette Remover";
        internal const string Description = "Gives you the ability to remove the damage vignette.";
        internal const string Author = "CarrionAndOn";
        internal const string Company = "Weather Electric";
        internal const string Version = "1.0.0";
        internal const string DownloadLink = "null";
        
        public static bool Enabled = false;
        private static Remover _remover;
        public override void OnInitializeMelon()
        {
            _remover = new Remover();
            SetupBonemenu();
        }
        
        [HarmonyPatch(typeof(Player_Health), "MakeVignette")]
        public static class VignettePatch
        {
            public static void Postfix(Player_Health __instance)
            {
                _remover.AutoDisable();
            }
        }
        private void SetupBonemenu()
        {
            MenuCategory menuCategory = MenuManager.CreateCategory("Vignette Remover", Color.red);
            menuCategory.CreateBoolElement("Toggle Autodisable", Color.white, Enabled, delegate(bool value)
            {
                Enabled = value;
            });
            menuCategory.CreateFunctionElement("Enable Vignette", Color.green, _remover.Enable);
            menuCategory.CreateFunctionElement("Disable Vignette", Color.red, _remover.Disable);
        }
    }
}