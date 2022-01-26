namespace Share.Models.ArticleDtos;
/// <summary>
/// 文章内容
/// </summary>
public class ArticleItemDto
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
    /// <summary>
    /// 仅个人查看
    /// </summary>
    public bool? IsPrivate { get; set; }
    public Guid Id { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    
}
