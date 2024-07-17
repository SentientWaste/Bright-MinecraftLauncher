using Avalonia.Controls;
using BrightLauncher.ViewModels;

namespace BrightLauncher.Views
{
    public partial class PlaygroundView : UserControl
    {
        public PlaygroundView()
        {
            InitializeComponent();
            DataContext = new PlaygroundViewModel();
        }
    }
}
