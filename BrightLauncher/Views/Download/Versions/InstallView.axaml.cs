using Avalonia.Controls;
using BrightLauncher.ViewModels;

namespace BrightLauncher.Views.Download
{
    public partial class InstallView : UserControl
    {
        public InstallView()
        {
            InitializeComponent();
            DataContext = new InstallViewModel();
        }
    }
}
