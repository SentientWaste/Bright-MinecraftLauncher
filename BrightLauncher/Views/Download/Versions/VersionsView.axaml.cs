using Avalonia.Controls;
using BrightLauncher.ViewModels;

namespace BrightLauncher.Views.Download
{
    public partial class VersionsView : UserControl
    {
        public VersionsView()
        {
            InitializeComponent();
            DataContext = new VersionsViewModel();
        }
    }
}
