namespace Share.Models.LibraryCatalogDtos;
/// <summary>
/// 目录/文件目录 / 自引用
/// </summary>
public class LibraryCatalogItemDto
{
    [MaxLength(50)]
    public string Name { get; set; } = default!;
    [MaxLength(50)]
    public string? Type { get; set; }
    public short Sort { get; set; } = default!;
    public short Level { get; set; } = default!;
    public Guid? ParentId { get; set; }
    public Guid AccountId { get; set; } = default!;
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;

}
