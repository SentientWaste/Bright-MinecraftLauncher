using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using BrightLauncher.Views;
using BrightLauncher.Views.Download.Other;
using BrightLauncher.Views.Setting;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightLauncher.ViewModels
{
    internal partial class OtherViewModel : ObservableObject
    {
        private readonly Window _mainWindow;

        public OtherViewModel()
        {
            _mainWindow = (Application.Current!.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)!.MainWindow!;
        }

        [RelayCommand]
        private void Back()
        {
            var mainWindowVM = (_mainWindow.DataContext as MainWindowViewModel)!;
            mainWindowVM.Page = new DownloadView();
        }

        [ObservableProperty]
        private object _page = new NewsView();

        [RelayCommand]
        private void To_InstallAuxiliaryView()
        {
            Page = new InstallAuxiliaryView();
        }

        [RelayCommand]
        private void To_InstallToolsView()
        {
            Page = new InstallToolsView();
        }

        [RelayCommand]
        private void To_NewsView()
        {
            Page = new NewsView();
        }
    }
}
