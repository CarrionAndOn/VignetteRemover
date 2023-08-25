using BoneLib;
using MelonLoader;
using UnityEngine;
using BoneLib.BoneMenu;
using BoneLib.BoneMenu.Elements;
using SLZ.Rig;

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
        
        public static bool Enabled;
        private static bool _scan;
        private Remover _remover;
        public override void OnInitializeMelon()
        {
            _remover = new Remover();
            Hooking.OnLevelInitialized += OnLevelLoad;
            Hooking.OnLevelUnloaded += OnLevelUnload;
            SetupBonemenu();
        }
        private void OnLevelLoad(LevelInfo levelInfo)
        {
            _scan = true;
        }
        private void OnLevelUnload()
        {
            _scan = false;
        }
        private void Update()
        {
            if (_scan)
            {
                GameObject targetObject = GameObject.Find("RigManager (Blank)");
                if (targetObject != null)
                {
                    _remover.AutoDisable();
                }
            }
        }
        private void SetupBonemenu()
        {
            MenuCategory menuCategory = MenuManager.CreateCategory("Vignette Remover", Color.red);
            menuCategory.CreateBoolElement("Toggle Autodisable", Color.white, Enabled);
            menuCategory.CreateFunctionElement("Enable Vignette", Color.green, _remover.Enable);
            menuCategory.CreateFunctionElement("Disable Vignette", Color.red, _remover.Disable);
        }
    }
}