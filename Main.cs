using MelonLoader;
using UnityEngine;
using BoneLib.BoneMenu.Elements;
using BoneLib.BoneMenu;
using BoneLib;
using BoneMenuStuff;
using static System.Net.Mime.MediaTypeNames;

namespace VignetteRemover
{
    internal partial class Main : MelonMod
    {

        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();
            BoneMenuStuff.BoneMenu.CreateBoneMenu(MenuManager.CreateCategory("Vignette Remover", Color.red));
        }
    }
}

