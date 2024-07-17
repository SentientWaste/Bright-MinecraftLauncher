using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using BrightLauncher.Views;
using BrightLauncher.Views.Download.Other;
using BrightLauncher.Views.Home;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightLauncher.ViewModels
{
    partial class HomeSettingViewModel : ObservableObject
    {
        private readonly Window _mainWindow;

        public HomeSettingViewModel()
        {
            _mainWindow = (Application.Current!.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)!.MainWindow!;
        }

        [RelayCommand]
        private void Back()
        {
            var mainWindowVM = (_mainWindow.DataContext as MainWindowViewModel)!;
            mainWindowVM.Page = new HomeView();
        }

        [ObservableProperty]
        private object _page = new SelectedVersionsView();

        [RelayCommand]
        private void To_SelectedVersionsView()
        {
            Page = new SelectedVersionsView();
        }

        [RelayCommand]
        private void To_TaskView()
        {
            Page = new TaskView();
        }

        [RelayCommand]
        private void To_OtherOptionView()
        {
            Page = new OtherOptionView();
        }

    }
}
