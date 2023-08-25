using BoneLib;
using MelonLoader;
using UnityEngine;
using BoneLib.BoneMenu;
using BoneLib.BoneMenu.Elements;

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
        
        private static bool _enabled = false;
        private static Remover _remover;
        internal static GameObject VignetteObj;
        public override void OnInitializeMelon()
        {
            _remover = new Remover();
            Hooking.OnLevelInitialized += OnLevelLoad;
            SetupBonemenu();
        }
        private void OnLevelLoad(LevelInfo levelInfo)
        {
            VignetteObj = GameObject.Find("Vignetter");
            if (_enabled)
            {
                VignetteObj.SetActive(false);
            }
        }
        private static void SetupBonemenu()
        {
            MenuCategory menuCategory = MenuManager.CreateCategory("Vignette Remover", Color.red);
            menuCategory.CreateBoolElement("Toggle Autodisable", Color.white, _enabled);
            menuCategory.CreateFunctionElement("Enable Vignette", Color.green, EnableVignette);
            menuCategory.CreateFunctionElement("Disable Vignette", Color.red, DisableVignette);
        }
        private static void EnableVignette()
        {
            _remover.Enable(VignetteObj);
        }

        private static void DisableVignette()
        {
            _remover.Disable(VignetteObj);
        }
    }
}