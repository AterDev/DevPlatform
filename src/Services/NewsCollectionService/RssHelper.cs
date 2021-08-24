using Microsoft.Extensions.Logging;
using Services.NewsCollectionService.RssFeeds;
using Services.NewsCollectionService.WebSites;

namespace Services.NewsCollectionService
{
    public class RssHelper
    {
        private readonly HttpClient _httpClient;
        public RssHelper()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
            }
        }

        public bool IsContainKey(string[] strArray, string key)
        {
            foreach (string item in strArray)
            {
                if (key.Contains(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 获取所有rss内容
        /// </summary>
        /// <returns></returns>
        public List<Rss> GetAllBlogs()
        {
            var result = new List<Rss>();

            var zhidingWeb = new ZhidingSoft();
            var list = zhidingWeb.GetListAsync(5).Result;
            result.AddRange(list);

            var msFeed = new MicrosoftFeed();
            result.AddRange(msFeed.GetBlogs(5).Result);

            var osChinaFeed = new OsChinaFeed();
            result.AddRange(osChinaFeed.GetBlogs(5).Result);

            var infoWorldFeed = new InfoWorldFeed();
            result.AddRange(infoWorldFeed.GetBlogs(5).Result);

            // 过滤旧数据
            result = result.Where(r => r.CreateTime >= DateTime.Now.AddDays(1)).ToList();

            var blogs = new List<Rss>();
            foreach (var blog in result)
            {
                if (!blogs.Any(b => b.Title.Contains(blog.Title)))
                {
                    blogs.Add(blog);
                }
            }
            return blogs;
        }
    }
}