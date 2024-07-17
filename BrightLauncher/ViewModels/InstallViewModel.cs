using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using BrightLauncher.Class.Data;
using BrightLauncher.Class.Messages;
using BrightLauncher.Services.Network;
using BrightLauncher.Views;
using BrightLauncher.Views.Download;
using BrightLauncher.Views.Home;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MinecraftLaunch.Classes.Enums;
using MinecraftLaunch.Classes.Models.Install;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BrightLauncher.ViewModels
{
    public sealed partial class InstallViewModel : ObservableObject
    {
        private readonly Window _mainWindow;
        private readonly DownloadService _downloadService;

        [ObservableProperty] private bool _canSelectForge = true;
        [ObservableProperty] private bool _canSelectFabric = true;
        [ObservableProperty] private bool _canSelectOptifine = true;

        [ObservableProperty] private ModLoaderData _selectedForge;
        [ObservableProperty] private ModLoaderData _selectedFabric;
        [ObservableProperty] private ModLoaderData _selectedOptifine;

        [ObservableProperty] private VersionManifestEntry _versionEntry;

        [ObservableProperty] private IEnumerable<ModLoaderData> forges;
        [ObservableProperty] private IEnumerable<ModLoaderData> fabrics;
        [ObservableProperty] private IEnumerable<ModLoaderData> optifines;

        public InstallViewModel()
        {
            _downloadService = new(default!);

            WeakReferenceMessenger.Default.Register<GameVersionMessage>(this, VersionHandler);
            WeakReferenceMessenger.Default.Register<ModLoaderMessage>(this, ModLoaderHandler);
        }

        [RelayCommand]
        private void Back()
        {
            WeakReferenceMessenger.Default.Send(new PageChangeMessage(new VersionsView()));
        }

        [RelayCommand]
        private void Install()
        {
            IEnumerable<ModLoaderData> loaders = [SelectedForge, SelectedFabric, SelectedOptifine];
            var loader = loaders.Where(x => x is not null).FirstOrDefault();
        }

        [RelayCommand]
        private void UnselectedModLoader(string key)
        {
            switch (key)
            {
                case "Forge":
                    SelectedForge = null;
                    break;
                case "Fabric":
                    SelectedFabric = null;
                    break;
                case "Optifine":
                    SelectedOptifine = null;
                    break;
            }
        }

        private async void VersionHandler(object sender, GameVersionMessage obj)
        {
            VersionEntry = obj.Version;
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

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            switch (e.PropertyName)
            {
                case "SelectedForge":
                    if (SelectedForge is null)
                    {
                        CanSelectForge = CanSelectOptifine = CanSelectFabric = true;
                        return;
                    }

                    CanSelectForge = true;
                    CanSelectOptifine = CanSelectFabric = false;
                    break;
                case "SelectedFabric":
                    if (SelectedFabric is null)
                    {
                        CanSelectForge = CanSelectOptifine = CanSelectFabric = true;
                        return;
                    }

                    CanSelectFabric = true;
                    CanSelectForge = CanSelectOptifine = false;
                    break;
                case "SelectedOptifine":
                    if (SelectedOptifine is null)
                    {
                        CanSelectForge = CanSelectOptifine = CanSelectFabric = true;
                        return;
                    }

                    CanSelectOptifine = true;
                    CanSelectForge = CanSelectFabric = false;
                    break;
            }
        }
    }
}
