using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using BrightLauncher.Class.Messages;
using BrightLauncher.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace BrightLauncher.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty] private object _page;
        [ObservableProperty]  private WindowState _windowst = WindowState.Normal;

        public MainWindowViewModel()
        {
            //给你的信使添加一个指定信息的接受处理，这个泛型填啥类型都可以,你可以一个lambda表达式搞定
            WeakReferenceMessenger.Default.Register<PageChangeMessage>(this, (sender, args) =>
            {
                Page = null;
                Page = args.Control;
            } );

            NavigationTo(new HomeView());
        }

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

        private void NavigationTo(UserControl control)
        {
            if (control is null)
            {
                return;
            }

            //发送端
            WeakReferenceMessenger.Default.Send(new PageChangeMessage(control));
        }
    }
}
