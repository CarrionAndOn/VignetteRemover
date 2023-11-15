using MelonLoader;

namespace VignetteRemover.Melon
{
    internal static class Preferences
    {
        public static readonly MelonPreferences_Category GlobalCategory = MelonPreferences.CreateCategory("Global");
        public static readonly MelonPreferences_Category OwnCategory = MelonPreferences.CreateCategory("Vignette Remover");
        
        public static ModPref<LoggingMode> LoggingMode;
        public static ModPref<bool> AutoDisable;


        public static void Setup()
        {
            AutoDisable = new ModPref<bool>(OwnCategory, "AutoDisable", false, "Auto Disable Vignette", "Whether to auto disable the vignette object or not.");
            LoggingMode = new ModPref<LoggingMode>(GlobalCategory, "LoggingMode", global::LoggingMode.NORMAL, "Logging Mode", "The level of logging to use. DEBUG = Everything, NORMAL = Important Only");
            OwnCategory.SetFilePath(MelonUtils.UserDataDirectory+"/WeatherElectric.cfg");
            OwnCategory.SaveToFile(false);
            GlobalCategory.SetFilePath(MelonUtils.UserDataDirectory+"/WeatherElectric.cfg");
            GlobalCategory.SaveToFile(false);
            ModConsole.Msg("Finished preferences setup for MODNAMEHERE", global::LoggingMode.DEBUG);
        }
    }
}