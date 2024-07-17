using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using BrightLauncher.Class.Messages;
using BrightLauncher.Services.Message;
using BrightLauncher.Views.Home;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace BrightLauncher.ViewModels
{
    public sealed partial class HomeViewModel : ObservableObject
    {
        ShowMessage showMessage = new ShowMessage();
        [RelayCommand]
        private void To_HomeSetting()
        {
            WeakReferenceMessenger.Default.Send(new PageChangeMessage(new HomeSettingView()));
        }

        [RelayCommand]
        private void message()
        {
            showMessage.Show("这是一条消息");
        }
    }
}
