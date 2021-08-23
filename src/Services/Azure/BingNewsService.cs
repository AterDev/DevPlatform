using Assist.Utils;
using Entity;
using HtmlAgilityPack;
using Microsoft.Azure.CognitiveServices.Search.NewsSearch;
using Microsoft.Azure.CognitiveServices.Search.NewsSearch.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services.Azure
{
    public class BingNewsService
    {
        readonly string subscriptionKey = "";
        readonly ILogger _log;
        private const double Similarity = 0.5;// 定义相似度

        public BingNewsService(ILogger<BingNewsService> logger,
            IOptions<AzureOptions> options)
        {
            _log = logger;
            subscriptionKey = options.Value.BingSearchKey;
        }

        public async Task<List<BingNews>> GetNews(string keyword, string freshness = "Day")
        {
            //获取新闻
            if (string.IsNullOrEmpty(subscriptionKey))
            {
                return default;
            }
            List<BingNews> newNews = await GetNewsSearchResults(keyword);
            if (newNews == null)
            {
                return default;
            }

            // 获取过滤来源白名单
            string[] urlFilter = { "tech.ifeng.com", "news.zol.com.cn", "tech.sina.com.cn",
                "pchome.net", "donews.com", "idcquan.com", "oschina.net" , "homea.people.com.cn",
                "tech.qq.com","www.ebrun.com","cn.engadget.com","tech.huanqiu.com"};

            // 数据预处理
            for (int i = 0; i < newNews.Count; i++)
            {
                // 来源过滤
                if (!urlFilter.Any(p => newNews[i].Url.ToLower().Contains(p)))
                {
                    _log.LogInformation("filter:" + newNews[i].Provider + newNews[i].Title);
                    newNews[i].Title = string.Empty;
                    continue;
                }
                // 无缩略图过滤
                if (string.IsNullOrEmpty(newNews[i].ThumbnailUrl))
                {
                    _log.LogInformation("noPic:" + newNews[i].Title);
                    newNews[i].Title = string.Empty;
                    continue;
                }

                //TODO: 语义分词重复过滤
                for (int j = i + 1; j < newNews.Count; j++)
                {
                    // 重复过滤
                    if ((newNews[i].Title.Similarity(newNews[j].Title) > Similarity))
                    {
                        _log.LogInformation("repeat" + newNews[i].Title);
                        newNews[i].Title = string.Empty;
                        continue;
                    }

                }
            }
            return newNews.Where(n => n.Title != string.Empty).ToList();
        }



        /// <summary>
        /// 获取必应新闻列表
        /// </summary>
        /// <param name="query">搜索关键词</param>
        /// <param name="count">数量</param>
        /// <param name="offset">偏移量</param>
        /// <param name="market">地区</param>
        /// <param name="freshness">时间频率</param>
        /// <returns></returns>
        public async Task<List<BingNews>> GetNewsSearchResults(string query, int count = 20, int offset = 0, string market = "zh-CN", string freshness = "Day")
        {
            var newsList = new List<BingNews>();
            try
            {
                var client = new NewsSearchClient(new ApiKeyServiceClientCredentials(subscriptionKey));
                var result = await client.News.SearchAsync(query, count: count, offset: offset, market: market, freshness: freshness);
                if (result != null && result.Value.Count > 0)
                {
                    result.Value.ToList().ForEach(data =>
                    {
                        var news = new BingNews
                        {
                            Title = data.Name,
                            Url = data.Url,
                            Description = data.Description,
                            ThumbnailUrl = data.Image?.Thumbnail?.ContentUrl,
                            Provider = data.Provider?[0].Name,
                            DatePublished = DateTime.TryParse(data.DatePublished, out var date) ? date : DateTime.Now,
                            Category = data.Category
                        };
                        newsList.Add(news);
                    });

                    newsList = newsList.Where(m => m.Category != null && m.Category.Equals("ScienceAndTechnology"))
                        .ToList();

                }
                return newsList;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Source + e.Message);
            }
            return newsList;
        }

        /// <summary>
        /// 获取内容页
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> GetNewsContentAsync(string url)
        {
            // 判断url来源，根据不同来源使用不同规则获取内容
            var filterList = NewsContentFilter.GetDefaultFilter();
            var filter = filterList.Where(f => url.Contains(f.Url)).FirstOrDefault();
            if (filter == null)
            {
                return "";
            }
            try
            {
                var hw = new HtmlWeb();
                var doc = await hw.LoadFromWebAsync(url);
                var content = doc.DocumentNode.SelectSingleNode($"//div[@{filter.Path}]").InnerHtml;
                // TODO: 移除无用内容
                return content ?? "";
            }
            catch (Exception e)
            {
                _log.LogError("==GetNewsContentAsync:" + e.Message + e.InnerException);
                return "";
            }
        }
    }
}
