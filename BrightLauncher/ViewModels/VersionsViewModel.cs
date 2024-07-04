using Avalonia.Threading;
using BrightLauncher.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using MinecraftLaunch;
using System.Text;
using System.Threading.Tasks;
using MinecraftLaunch.Components.Installer;
using MinecraftLaunch.Components.Resolver;
using MinecraftLaunch.Components;
using MinecraftLaunch.Utilities;
using MinecraftLaunch.Classes;
using BrightLauncher.Services.Network;
using System.Collections.ObjectModel;
using MinecraftLaunch.Classes.Models.Install;
using System.Collections.Immutable;
using System.Threading;
using Avalonia.Controls;
using BrightLauncher.Views.Setting;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia;
using CommunityToolkit.Mvvm.Messaging;
using BrightLauncher.Class.Messages;
using BrightLauncher.Views.Download;

namespace BrightLauncher.ViewModels
{
    public partial class VersionsViewModel : ObservableObject
    {
        private List<VersionManifestEntry> _allVersion = [];
        private CancellationTokenSource _cancellationTokenSource = new();

        private readonly DownloadService _downloadService;

        [ObservableProperty] private bool _isLoading = true;
        [ObservableProperty] private bool _isLoadFinish = false;
        [ObservableProperty] private int _currentVersionType = -1;
        [ObservableProperty] private VersionManifestEntry _selectionGame;

        public ObservableCollection<VersionManifestEntry> VersionManifestEntries { get; private set; }

        public VersionsViewModel()
        {
            if (Design.IsDesignMode)
            {
                return;
            }

            _mainWindow = (Application.Current!.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)!.MainWindow!;
            _downloadService = new(default!);
            VersionManifestEntries = [];

            //异步获取列表
            _ = Task.Run(async () =>
            {
                var asyncEnumerable = _downloadService.GetVersionListAsync();
                await foreach (var item in asyncEnumerable)
                {
                    _allVersion.Add(item);
                }
            }).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    CurrentVersionType = 0;
                    IsLoading = false;
                    IsLoadFinish = !IsLoading;
                }
            });
        }

        private readonly Window _mainWindow;

        [RelayCommand]
        private void Back()
        {
            var mainWindowVM = (_mainWindow.DataContext as MainWindowViewModel)!;
            mainWindowVM.Page = new DownloadView();
        }

        async partial void OnCurrentVersionTypeChanged(int value)
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = new();

            VersionManifestEntries.Clear();
            var filterParameters = CurrentVersionType switch
            {
                0 => "release",
                1 => "snapshot",
                2 => "old_beta",
                3 => "old_alpha",
                _ => "release"
            };

            var filterGames = _allVersion.Where(x => x.Type == filterParameters).ToImmutableArray();
            foreach (var game in filterGames)
            {
                if (_cancellationTokenSource.IsCancellationRequested)
                {
                    break;
                }

                try
                {
                    VersionManifestEntries.Add(game);
                    await Task.Delay(3, _cancellationTokenSource.Token);
                }
                catch (Exception)
                {                }
            }
        }

        partial void OnSelectionGameChanged(VersionManifestEntry value)
        {
            var mainWindowVM = (_mainWindow.DataContext as MainWindowViewModel)!;
            mainWindowVM.Page = new InstallView();

            WeakReferenceMessenger.Default.Send(new GameVersionMessage(value));
        }
    }
}
