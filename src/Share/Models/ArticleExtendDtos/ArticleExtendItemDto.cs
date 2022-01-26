namespace Share.Models.ArticleExtendDtos;
/// <summary>
/// 文章扩展
/// </summary>
public class ArticleExtendItemDto
{
    public Guid ArticleId { get; set; }
    public Guid Id { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
    
}
