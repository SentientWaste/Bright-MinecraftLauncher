using BrightLauncher.Class.Data;
using BrightLauncher.Class.Messages;
using BrightLauncher.Services.Network;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MinecraftLaunch.Classes.Enums;
using System.Collections.Generic;

namespace BrightLauncher.ViewModels
{
    public sealed partial class InstallViewModel : ObservableObject
    {
        private readonly DownloadService _downloadService;

        [ObservableProperty] private IEnumerable<ModLoaderData> forges;
        [ObservableProperty] private IEnumerable<ModLoaderData> fabrics;
        [ObservableProperty] private IEnumerable<ModLoaderData> optifines;

        public InstallViewModel()
        {
            _downloadService = new(default!);
            WeakReferenceMessenger.Default.Register<GameVersionMessage>(this,  VersionHandler);
            WeakReferenceMessenger.Default.Register<ModLoaderMessage>(this,  ModLoaderHandler);
        }

        private async void VersionHandler(object sender, GameVersionMessage obj)
        {
            await _downloadService.InitModLoaders(obj.Version);
        }

        private void ModLoaderHandler(object sender, ModLoaderMessage obj)
        {
            switch (obj.LoaderType)
            {
                case LoaderType.Forge:
                    Forges = obj.LoaderDatas;
                    break;
                case LoaderType.Fabric:
                    Fabrics = obj.LoaderDatas;
                    break;
                case LoaderType.OptiFine:
                    Optifines = obj.LoaderDatas;
                    break;
            }
        }
    }
}
