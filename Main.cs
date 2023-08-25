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
        private static GameObject _vignetteObj;
        public override void OnInitializeMelon()
        {
            Hooking.OnLevelInitialized += OnLevelLoad;
            SetupBonemenu();
        }
        private static void OnLevelLoad(LevelInfo levelInfo)
        {
            _vignetteObj = GameObject.Find("Vignetter");
            if (_enabled)
            {
                _vignetteObj.SetActive(false);
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
            Remover.Enable(_vignetteObj);
        }

        private static void DisableVignette()
        {
            Remover.Disable(_vignetteObj);
        }
    }
}