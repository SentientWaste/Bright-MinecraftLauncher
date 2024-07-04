using Avalonia.Controls;
using Avalonia.Input;
using BrightLauncher.ViewModels;
using System;

namespace BrightLauncher.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

}
