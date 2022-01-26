namespace Share.Models.ArticleDtos;
/// <summary>
/// 文章内容
/// </summary>
public class ArticleShortDto
{
    /// <summary>
    /// 标题
    /// </summary>
    [MaxLength(100)]
    public string Title { get; set; }
    /// <summary>
    /// 概要
    /// </summary>
    [MaxLength(500)]
    public string? Summary { get; set; }
    /// <summary>
    /// 作者名称
    /// </summary>
    [MaxLength(100)]
    public string? AuthorName { get; set; }
    /// <summary>
    /// 标签
    /// </summary>
    [MaxLength(100)]
    public string? Tags { get; set; }
    /// <summary>
    /// 文章类别
    /// </summary>
    public ArticleType ArticleType { get; set; }
    public Account Account { get; set; }
    /// <summary>
    /// 仅个人查看
    /// </summary>
    public bool? IsPrivate { get; set; }
    /// <summary>
    /// 文章扩展内容
    /// </summary>
    public ArticleExtend? Extend { get; set; }
    /// <summary>
    /// 所属目录
    /// </summary>
    public ArticleCatalog? Catalog { get; set; }
    public Guid Id { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    
}
