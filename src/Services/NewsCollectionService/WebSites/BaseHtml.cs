using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.NewsCollectionService.WebSites;

public class BaseHtml
{
    protected string Url { get; set; }
    protected string[] HtmlTagFilter { get; set; }
    /// <summary>
    /// root结点 
    /// </summary>
    protected string RootName { get; set; }
    /// <summary>
    /// xml item 名称
    /// </summary>
    protected string ItemName { get; set; }
    protected string Author { get; set; }
    protected string Description { get; set; }
    protected string Title { get; set; }
    protected string PubDate { get; set; }
    protected string Content { get; set; }

    protected virtual List<Rss> GetList(int number = 3)
    {
        var result = new List<Rss>();
        try
        {
           
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + e.InnerException + e.StackTrace);
        }
        return default;
    }

    protected virtual string GetContent(string url) => "";
}
