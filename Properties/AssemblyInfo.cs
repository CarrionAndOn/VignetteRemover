using System.Reflection;
using VignetteRemover;
using MelonLoader;

[assembly: AssemblyTitle(VignetteRemover.Main.Description)]
[assembly: AssemblyDescription(VignetteRemover.Main.Description)]
[assembly: AssemblyCompany(VignetteRemover.Main.Company)]
[assembly: AssemblyProduct(VignetteRemover.Main.Name)]
[assembly: AssemblyCopyright("Developed by " + VignetteRemover.Main.Author)]
[assembly: AssemblyTrademark(VignetteRemover.Main.Company)]
[assembly: AssemblyVersion(VignetteRemover.Main.Version)]
[assembly: AssemblyFileVersion(VignetteRemover.Main.Version)]
[assembly: MelonInfo(typeof(VignetteRemover.Main), VignetteRemover.Main.Name, VignetteRemover.Main.Version, VignetteRemover.Main.Author, VignetteRemover.Main.DownloadLink)]
[assembly: MelonColor(System.ConsoleColor.White)]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONELAB")]