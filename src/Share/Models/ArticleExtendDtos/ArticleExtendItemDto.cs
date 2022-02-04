namespace Share.Models.ArticleExtendDtos;
/// <summary>
/// 文章扩展
/// </summary>
public class ArticleExtendItemDto
{
    public Guid ArticleId { get; set; } = default!;
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    
}
