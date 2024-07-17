using Avalonia.Controls;
using BrightLauncher.ViewModels;

namespace BrightLauncher.Views
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            DataContext = new HomeViewModel();
        }
    }
}
