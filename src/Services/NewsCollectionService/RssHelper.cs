using Microsoft.Extensions.Logging;
using Services.NewsCollectionService.RssFeeds;

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
        public List<Rss> GetAllBlogs(ILogger log)
        {
            var result = new List<Rss>();

            var msFeed = new MicrosoftFeed();
            result.AddRange(msFeed.GetBlogs(5).Result);

            var osChinaFeed = new OsChinaFeed();
            result.AddRange(osChinaFeed.GetBlogs().Result);

            var infoWorldFeed = new InfoWorldFeed();
            result.AddRange(infoWorldFeed.GetBlogs().Result);


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