using BrightLauncher.Views.Download;
using BrightLauncher.Views.Download.Other;
using CommunityToolkit.Mvvm.ComponentModel;
using MinecraftLaunch.Classes.Models.Install;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightLauncher.ViewModels
{
    public partial class PlaygroundViewModel : ObservableObject
    {
        public ObservableCollection<string>? OnlineList { get; private set; } 
    }
}
