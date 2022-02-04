namespace Share.Models.NewsTagsDtos;
/// <summary>
/// 新闻标签
/// </summary>
public class NewsTagsItemDto
{
    [MaxLength(40)]
    public string Name { get; set; } = default!;
    [MaxLength(20)]
    public string? Color { get; set; }
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    
}
