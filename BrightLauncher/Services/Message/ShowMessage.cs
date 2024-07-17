using Avalonia;
using BrightLauncher.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrightLauncher.Services.Message
{
    public class ShowMessage
    {
        public void Show(string message)
        {
            MainWindow.Mw.messagebox.Margin = new Thickness(0, 0, 20, 20);
            MainWindow.Mw.message.Text = message;
            Task.Delay(3000);
            MainWindow.Mw.messagebox.Margin = new Thickness(0, 0, -300, 20);
        }
    }
}
