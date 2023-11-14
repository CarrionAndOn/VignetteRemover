using BoneLib;
using MelonLoader;

namespace VignetteRemover.Melon
{
    internal static class Preferences
    {
        public static readonly MelonPreferences_Category Category = MelonPreferences.CreateCategory("Paranoia");

        public static ModPref<bool> AutoDisable;

        public static void Setup()
        {
            AutoDisable = new ModPref<bool>(Category, "AutoDisable", false, "Auto Disable Vignette", "Whether to auto disable the vignette object or not.");
            Category.SaveToFile(false);
        }
    }
}