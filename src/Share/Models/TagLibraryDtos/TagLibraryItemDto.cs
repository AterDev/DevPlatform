namespace Share.Models.TagLibraryDtos;
/// <summary>
/// 标签库
/// </summary>
public class TagLibraryItemDto
{
    [MaxLength(40)]
    public string Type { get; set; } = default!;
    [MaxLength(40)]
    public string Name { get; set; } = default!;
    [MaxLength(20)]
    public string? Color { get; set; }
    [MaxLength(40)]
    public string? Style { get; set; }
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    
}
