using Avalonia.Controls;
using BrightLauncher.ViewModels;
using System.Formats.Asn1;

namespace BrightLauncher.Views
{
    public partial class SettingView : UserControl
    {
        public SettingView()
        {
            InitializeComponent();
            DataContext = new SettingViewModel();
        }
    }
}
