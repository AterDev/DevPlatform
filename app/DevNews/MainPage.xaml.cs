using DevNews.Models;
using DevNews.Share;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

        private void LoadData(object sender, RoutedEventArgs e)
        {
            ReloadNews();
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

            var ids = new List<Guid>();
            ids.Add(item.Id);
            if (await newsService.SetAsDelteAsync(ids))
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
            var items = new List<ThirdNews>();
            foreach (ThirdNews item in NewsListView.SelectedItems)
            {
                items.Add(item);
            }

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

        private async Task<bool> SetNewsTypeAsync(List<Guid> ids, NewsType newsType)
        {
            var res = await newsService.MoveNewsAsync(ids, newsType);
            return res;
        }


        private void NewsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var currentItem = (NewsTypeChose)e.ClickedItem;
            // 调用内容
            var items = new List<ThirdNews>();
            foreach (ThirdNews item in NewsListView.SelectedItems)
            {
                items.Add(item);
            }
            if (items != null && items.Count > 0)
            {
                var ids = items.Select(x => x.Id).ToList();
                NewsType btnValue = currentItem.NewsType;
                var res = await SetNewsTypeAsync(ids, btnValue);
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
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            ReloadNews();
        }

        private async void ReloadNews()
        {
            var news = await newsService.GetNewsAsync();
            News = new ObservableCollection<ThirdNews>(news);
            NewsListView.ItemsSource = News;
        }

        /// <summary>
        /// 按分类筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterBtn_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            NewsType newsType = NewsType.Default;
            switch (button.Name)
            {
                case "CompanyFilter":
                    newsType = NewsType.Company;
                    break;
                case "OpenSourceFilter":
                    newsType = NewsType.OpenSource;
                    break;
                case "FrameworkFilter":
                    newsType = NewsType.LanguageAndFramework;
                    break;
                case "DataFilter":
                    newsType = NewsType.DataAndAI;
                    break;
                case "ElseFilter":
                    newsType = NewsType.Else;
                    break;
                default:
                    break;
            }
            var filterNews = News.Where(n => n.NewsType == newsType).ToList();
            var obsFilterNews = new ObservableCollection<ThirdNews>(filterNews);
            NewsListView.ItemsSource = obsFilterNews;
        }

    }
}
