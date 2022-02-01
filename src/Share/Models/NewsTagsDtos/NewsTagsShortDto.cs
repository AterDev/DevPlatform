namespace Share.Models.NewsTagsDtos;
/// <summary>
/// 新闻标签
/// </summary>
public class NewsTagsShortDto
{
    [MaxLength(40)]
    public string Name { get; set; }
    [MaxLength(20)]
    public string? Color { get; set; }
    public ThirdNews ThirdNews { get; set; }
    public Guid Id { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }

}
