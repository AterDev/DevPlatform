namespace Share.Models.LibraryCatalogDtos;
/// <summary>
/// 目录/文件目录 / 自引用
/// </summary>
public class LibraryCatalogShortDto
{
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(50)]
    public string? Type { get; set; }
    public short Sort { get; set; }
    public short Level { get; set; }
    public LibraryCatalog? Parent { get; set; }
    public Guid? ParentId { get; set; }
    /// <summary>
    /// 所属用户
    /// </summary>
    public User Account { get; set; }
    public Guid AccountId { get; set; }
    public Guid Id { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }

}
