using DevNews.Models;
using DevNews.Share;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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

        private ObservableCollection<ThirdNews> News { get; set; } = new ObservableCollection<ThirdNews>();
        public readonly List<NewsTypeChose> TypeChoses = new List<NewsTypeChose>();
        readonly NewsService newsService = new NewsService();

        public MainPage()
        {
            InitializeComponent();
            Loaded += LoadData;
            MinWidth = 720;
            TypeChoses = new NewsTypeChose().GetDefaultList();
        }

        private async void LoadData(object sender, RoutedEventArgs e)
        {
            var news = await newsService.GetNewsAsync();
            News = new ObservableCollection<ThirdNews>(news);
            NewsListView.ItemsSource = News;
        }

        private async void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var item = (ThirdNews)button.DataContext;

            var success = await Launcher.LaunchUriAsync(new Uri(item.Url));
            if (success)
            {

            }
        }

        private async void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var item = (ThirdNews)button.DataContext;

            if (await newsService.DeleteAsync(item.Id))
            {
                var success = News.Remove(item);
            }
            else
            {
                // 删除失败
            }
        }

        private async void DeleteAllBtn_Click(object sender, RoutedEventArgs e)
        {
            var items = NewsListView.SelectedItems as List<ThirdNews>;
            var ids = items.Select(x => x.Id).ToList();
            var res = await newsService.SetAsDelteAsync(ids);
            if (res)
            {
                NewsListView.SelectedItems.Clear();
                items.ForEach(item =>
                {
                    News.Remove(item);
                });
            }
        }


        private async void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = (NewsTypeChose)e.AddedItems[0];
            // TODO: 调用内容
            var items = NewsListView.SelectedItems as List<ThirdNews>;
            var ids = items.Select(x => x.Id).ToList();


            NewsType btnValue = currentItem.NewsType;
            var res = await newsService.MoveNewsAsync(ids, btnValue);
            if (res)
            {
                for (int i = 0; i < News.Count; i++)
                {
                    if (items.Contains(News[i]))
                    {
                        News[i].NewsType = btnValue;
                    }
                }
            }
            else
            {

            }

        }

        private void SplitButton_Click(SplitButton sender, SplitButtonClickEventArgs args)
        {

        }
    }
}
