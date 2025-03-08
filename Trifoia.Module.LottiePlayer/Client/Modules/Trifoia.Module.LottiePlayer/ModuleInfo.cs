using Oqtane.Models;
using Oqtane.Modules;

namespace Trifoia.Module.LottiePlayer
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "LottiePlayer",
            Description = "Lottie Animations Module",
            Version = "1.0.0",
            ServerManagerType = "Trifoia.Module.LottiePlayer.Manager.LottiePlayerManager, Trifoia.Module.LottiePlayer.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "Trifoia.Module.LottiePlayer.Shared.Oqtane,MudBlazor",
            PackageName = "Trifoia.LottiePlayer" 
        };
    }
}
