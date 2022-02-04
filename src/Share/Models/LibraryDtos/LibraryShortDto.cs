namespace Share.Models.LibraryDtos;
/// <summary>
/// 模型库
/// </summary>
public class LibraryShortDto
{
    /// <summary>
    /// 库命名空间
    /// </summary>
    [MaxLength(100)]
    public string Namespace { get; set; } = default!;
    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; set; }
    /// <summary>
    /// 语言类型
    /// </summary>
    [MaxLength(100)]
    public string? Language { get; set; }
    /// <summary>
    /// 是否有效
    /// </summary>
    public bool IsValid { get; set; } = default!;
    /// <summary>
    /// 是否公开
    /// </summary>
    public bool IsPublic { get; set; } = default!;
    public User User { get; set; } = default!;
    public LibraryCatalog? Catalog { get; set; } = default!;
    public Guid Id { get; set; } = default!;
    /// <summary>
    /// 状态
    /// </summary>
    public Status Status { get; set; } = default!;
    public DateTimeOffset CreatedTime { get; set; } = default!;
    public DateTimeOffset UpdatedTime { get; set; } = default!;
    
}
