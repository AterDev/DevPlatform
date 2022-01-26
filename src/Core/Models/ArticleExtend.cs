namespace Core.Models;

/// <summary>
/// 文章扩展
/// </summary>
public class ArticleExtend : BaseDB
{
    public Article Article { get; set; } = null!;
    public string Content { get; set; } = null!;

}
