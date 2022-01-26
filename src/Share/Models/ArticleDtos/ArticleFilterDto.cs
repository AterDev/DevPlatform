namespace Share.Models.ArticleDtos;
/// <summary>
/// 文章内容
/// </summary>
public class ArticleFilter : FilterBase
{
    /// <summary>
    /// 标题
    /// </summary>
    [MaxLength(100)]
    public string? Title { get; set; }
    /// <summary>
    /// 文章类别
    /// </summary>
    public ArticleType? ArticleType { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    public Guid? AccountId { get; set; }
    public Guid? ExtendId { get; set; }
    public Guid? CatalogId { get; set; }
    
}
