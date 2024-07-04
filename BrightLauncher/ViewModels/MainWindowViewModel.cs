using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using BrightLauncher.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BrightLauncher.ViewModels
{
    internal partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]//#2A2929
        private object _page = new HomeView();

        [ObservableProperty]//#2A2929
        private WindowState _windowst = WindowState.Normal;

        [RelayCommand]
        private void To_Home()
        {
            Page = new HomeView();
        }

        [RelayCommand]
        private void To_Download()
        {
            Page = new DownloadView();
        }

        [RelayCommand]
        private void To_Playground()
        {
            Page = new PlaygroundView();
        }

        [RelayCommand]
        private void To_Setting()
        {
            Page = new SettingView();
        }

        [RelayCommand]
        private void Close()
        {
            Environment.Exit(0);
        }

        [RelayCommand]
        private void Minimize()
        {
            Windowst = WindowState.Normal;
            Windowst = WindowState.Minimized;
        }
    }
}
