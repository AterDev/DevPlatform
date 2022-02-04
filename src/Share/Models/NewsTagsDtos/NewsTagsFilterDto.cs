namespace Share.Models.NewsTagsDtos;
/// <summary>
/// 新闻标签
/// </summary>
public class NewsTagsFilter : FilterBase
{
    [MaxLength(40)]
    public string? Name { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    public Guid? ThirdNewsId { get; set; } = default!;
    
}
