using BoneLib.BoneMenu.Elements;
using UnityEngine;

namespace BoneMenuStuff
{
    internal class BoneMenu
    {
        // Create all our variables
        private static bool VignetteToggle = true;
        private static GameObject cachedObject;
        public static void CreateBoneMenu(MenuCategory rootCategory)
        {
            // Create cache button
            rootCategory.CreateFunctionElement(
                "Cache Object (HIT ONLY ONCE PER LEVEL)",
                Color.white,
                () =>
                {
                    GameObject gameObject = GameObject.Find("Vignetter(Clone)");
                    cachedObject = gameObject;


                }
            );
            // Create toggle all bonemenu button
            rootCategory.CreateFunctionElement(
                "Toggle Vignette",
                Color.red,
                () =>
                {
                    VignetteToggle = !VignetteToggle;
                    if (cachedObject)
                    {
                        cachedObject.SetActive(VignetteToggle);
                    }
                }
            );
        }
    }
}