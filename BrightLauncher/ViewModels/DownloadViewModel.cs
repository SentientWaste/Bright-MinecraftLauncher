using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using BrightLauncher.Views;
using BrightLauncher.Views.Download;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightLauncher.ViewModels
{
    public sealed partial class DownloadViewModel : ObservableObject
    {
        private readonly Window _mainWindow;

        public DownloadViewModel()
        {
            _mainWindow = (Application.Current!.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)!.MainWindow!;
        }

        [RelayCommand]
        private void To_Other()
        {
            var mainWindowVM = (_mainWindow.DataContext as MainWindowViewModel)!;
            mainWindowVM.Page = new OtherView();
        }

        [RelayCommand]
        private void To_Versions()
        {
            var mainWindowVM = (_mainWindow.DataContext as MainWindowViewModel)!;
            mainWindowVM.Page = new VersionsView();
        }
    }
}
