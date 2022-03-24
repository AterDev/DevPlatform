namespace Share.Models.ArticleCatalogDtos;

public class ArticleCatalogShortDto
{
    [MaxLength(50)]
    public string Name { get; set; } = default!;
    [MaxLength(50)]
    public string? Type { get; set; }
    public short Sort { get; set; } = default!;
    public short Level { get; set; } = default!;
    /// <summary>
    /// 父目录
    /// </summary>
    public ArticleCatalog? Parent { get; set; } = default!;
    public Guid? ParentId { get; set; }
    /// <summary>
    /// 所属用户
    /// </summary>
    public User Account { get; set; } = default!;
    public Guid AccountId { get; set; } = default!;
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;

}
