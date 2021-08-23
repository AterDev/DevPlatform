using System;
using System.Collections.Generic;
using System.Text;

namespace Services.NewsCollectionService.RssFeeds
{
    public class OsChinaFeed : BaseFeed
    {
        public OsChinaFeed()
        {
            Urls = new string[]
            {
                "https://www.oschina.net/news/rss",
            };
        }

        protected override string GetContent(string url)
        {
            return base.GetContent(url);
        }
    }
}
