using DevNews.Models;
using DevNews.Share;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace DevNews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private List<ThirdNews> News { get; set; } = new List<ThirdNews>();

        public MainPage()
        {
            InitializeComponent();
            Loaded += LoadData;
        }

        private async void LoadData(object sender, RoutedEventArgs e)
        {
            var newsService = new NewsService();
            News = await newsService.GetNewsAsync();
            NewsListView.ItemsSource = News;

        }


    }
}
