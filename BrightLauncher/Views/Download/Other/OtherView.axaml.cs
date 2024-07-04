using Avalonia.Controls;
using BrightLauncher.ViewModels;

namespace BrightLauncher.Views.Download
{
    public partial class OtherView : UserControl
    {
        public OtherView()
        {
            InitializeComponent();
            DataContext = new OtherViewModel();
        }
    }
}
