using Services.NewsCollectionService.RssFeeds;

namespace Services.NewsCollectionService.WebSites
{
    public class ZhidingSoft : BaseHtml
    {
        public ZhidingSoft()
        {
            Url = "http://soft.zhiding.cn/";
        }




        protected override string GetContent(string url)
        {
            return base.GetContent(url);
        }
    }
}
