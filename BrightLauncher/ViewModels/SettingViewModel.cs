using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using BrightLauncher.Views;
using BrightLauncher.Views.Download;
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
    internal partial class SettingViewModel : ObservableObject
    {
        private readonly Window _mainWindow;

        public SettingViewModel()
        {
            _mainWindow = (Application.Current!.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)!.MainWindow!;
        }

        [ObservableProperty]
        private object _page = new SettingAccountView();

        [RelayCommand]
        private void To_Setting_Launcher()
        {
            var mainWindowVM = (_mainWindow.DataContext as MainWindowViewModel)!;
            mainWindowVM.Page = new SettingLauncherView();
        }

        [RelayCommand]
        private void To_Setting_DIY()
        {
            var mainWindowVM = (_mainWindow.DataContext as MainWindowViewModel)!;
            mainWindowVM.Page = new SettingLauncherView();
        }

        [RelayCommand]
        private void To_Setting_Account()
        {
            var mainWindowVM = (_mainWindow.DataContext as MainWindowViewModel)!;
            mainWindowVM.Page = new SettingAccountView();
        }

        [RelayCommand]
        private void To_Setting_Game()
        {
            var mainWindowVM = (_mainWindow.DataContext as MainWindowViewModel)!;
            mainWindowVM.Page = new SettingGameView();
        }

        [RelayCommand]
        private void To_Setting_Other()
        {

        }
    }
}
