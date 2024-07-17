using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace BrightLauncher.Views.Download.Other
{
    public partial class NewsListView : UserControl
    {
        public NewsListView()
        {
            InitializeComponent();
        }

        public NewsListView(string uri, string title, string message, string data, string uri1)
        {
            InitializeComponent();
            LoadImage(uri);
            mTitle.Text = title;
            Message.Text = message;
            link.Text = uri1;
            IsOk.Header = title;
            Date.Text = string.Format("{0}{1}", "发布日期：", data);
        }

        async void LoadImage(string uri)
        {
            try
            {
                using HttpClient hc = new();
                var newsimage = await Task.Run(async () =>
                {
                    var stream1 = await hc.GetByteArrayAsync("https://launchercontent.mojang.com/" + uri);
                    MemoryStream stream = new(stream1);
                    return stream;
                });
                Bitmap bitmap = new(newsimage);
                image.Source = bitmap;
            }
            catch (Exception)
            {

            }
        }
    }
}
