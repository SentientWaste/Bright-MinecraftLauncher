using Avalonia.Controls;
using BrightLauncher.ViewModels;

namespace BrightLauncher.Views
{
    public partial class DownloadView : UserControl
    {
        public DownloadView()
        {
            InitializeComponent();
            DataContext = new DownloadViewModel();
        }
    }
}
