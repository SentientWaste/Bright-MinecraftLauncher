using Avalonia.Controls;
using Avalonia.Input;
using BrightLauncher.Services.Message;
using BrightLauncher.ViewModels;
using System;

namespace BrightLauncher.Views;

public partial class MainWindow : Window
{
    public ShowMessage showMessage = new ShowMessage();
    public static MainWindow Mw {  get; set; }
    public MainWindow()
    {
        InitializeComponent();
        Mw = this;
        DataContext = new MainWindowViewModel();
    }

}
