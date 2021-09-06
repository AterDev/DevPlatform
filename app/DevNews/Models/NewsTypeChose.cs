using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNews.Models
{
    public class NewsTypeChose
    {
        public string DisplayName { get; set; }
        public NewsType NewsType { get; set; }

        public NewsTypeChose()
        {

        }

        public List<NewsTypeChose> GetDefaultList()
        {
            return new List<NewsTypeChose>
            {
                new NewsTypeChose
                {
                    DisplayName  = "巨头",
                    NewsType = NewsType.Company
                },
                new NewsTypeChose
                {
                    DisplayName = "数据与AI",
                    NewsType = NewsType.DataAndAI
                },
                new NewsTypeChose{
                    DisplayName = "语言与框架",
                    NewsType = NewsType.LanguageAndFramework
                },
                new NewsTypeChose
                {
                    DisplayName = "开源",
                    NewsType= NewsType.OpenSource
                },
                new NewsTypeChose
                {
                    DisplayName = "其它",
                    NewsType= NewsType.Else
                }
            };
        }
    }
}
