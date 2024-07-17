using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using BrightLauncher.Class.Messages;
using BrightLauncher.Views;
using BrightLauncher.Views.Download;
using BrightLauncher.Views.Home;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightLauncher.ViewModels
{
    public sealed partial class DownloadViewModel : ObservableObject
    {
        [RelayCommand]
        private void NavigationTo(string key)
        {
            var control = key switch
            {
                "Other" => new OtherView(),
                "Version" => new VersionsView(),
                _ => new UserControl()
            };

            WeakReferenceMessenger.Default.Send(new PageChangeMessage(control));
        }
    }
}
