using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using BrightLauncher.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace BrightLauncher.Views.Download.Other
{
    public partial class NewsView : UserControl
    {
        public NewsView()
        {
            InitializeComponent();
            LoadNews();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            newslist = this.Find<StackPanel>("newslist");
            Isok = this.Find<StackPanel>("Isok");
        }
        List<NewsListView> newItemViews = new List<NewsListView>();
        public async void LoadNews()
        {
            using HttpClient hc = new();
            try
            {
                var json = await hc.GetStringAsync("https://launchercontent.mojang.com/news.json");
                var v = JsonConvert.DeserializeObject<NewsModels>(json);
                foreach (var i in v.entries)
                {
                    NewsListView newItem = new(i.newsPageImage.url, i.title, i.text, i.date, i.readMoreLink);
                    newItemViews.Add(newItem);

                    if (newItemViews.Count is 20)
                        break;
                }
            }
            catch (System.Exception)
            {

            }
            finally
            {
                Isok.IsVisible = false;
                hc.Dispose();
                foreach (var i in newItemViews)
                    await Dispatcher.UIThread.InvokeAsync(() => { newslist.Children.Add(i); }, DispatcherPriority.Background);
            }
        }
    }
}
