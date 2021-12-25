using System.Collections.Generic;

namespace DevNews.Models
{
    public class NewsTypeChose
    {
        public string DisplayName { get; set; }
        public TechType NewsType { get; set; }

        public NewsTypeChose()
        {
        }
        public List<NewsTypeChose> GetDefaultList()
        {
            return new List<NewsTypeChose>
            {
                new NewsTypeChose
                {
                    DisplayName  = "资讯速览",
                    NewsType = TechType.Normal
                },
                new NewsTypeChose
                {
                    DisplayName = "发布更新",
                    NewsType= TechType.Publish
                },
                new NewsTypeChose{
                    DisplayName = "关注讨论",
                    NewsType = TechType.Focus
                }
            };
        }
    }
}
