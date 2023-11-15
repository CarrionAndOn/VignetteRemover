using MelonLoader;

namespace VignetteRemover.Melon
{
    internal static class Preferences
    {
        public static readonly MelonPreferences_Category GlobalCategory = MelonPreferences.CreateCategory("Global");
        public static readonly MelonPreferences_Category OwnCategory = MelonPreferences.CreateCategory("Vignette Remover");
        
        public static MelonPreferences_Entry<int> loggingMode { get; set; }
        public static MelonPreferences_Entry<bool> AutoDisable { get; set; }


        public static void Setup()
        {
            AutoDisable = OwnCategory.CreateEntry("AutoDisable", false, "Auto Disable Vignette", "Whether to auto disable the vignette object or not.");
            loggingMode = GlobalCategory.GetEntry<int>("LoggingMode") ?? GlobalCategory.CreateEntry("LoggingMode", 0, "Logging Mode", "The level of logging to use. 0 = Important Only, 1 = All");
            GlobalCategory.SetFilePath(MelonUtils.UserDataDirectory+"/WeatherElectric.cfg");
            GlobalCategory.SaveToFile(false);
            OwnCategory.SetFilePath(MelonUtils.UserDataDirectory+"/WeatherElectric.cfg");
            OwnCategory.SaveToFile(false);
            ModConsole.Msg("Finished preferences setup for Vignette Remover", 1);
        }
    }
}