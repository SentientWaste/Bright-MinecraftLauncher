using Avalonia.Controls;
using BrightLauncher.ViewModels;
using System.Diagnostics;

namespace BrightLauncher.Views.Home
{
    public partial class HomeSettingView : UserControl
    {
        public HomeSettingView()
        {
            InitializeComponent();
            DataContext = new HomeSettingViewModel();
        }
    }
}
