using MelonLoader;
using UnityEngine;
using BoneLib.BoneMenu;

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

