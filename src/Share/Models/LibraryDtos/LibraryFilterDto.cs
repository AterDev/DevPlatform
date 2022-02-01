namespace Share.Models.LibraryDtos;
/// <summary>
/// 模型库
/// </summary>
public class LibraryFilter : FilterBase
{
    /// <summary>
    /// 库命名空间
    /// </summary>
    [MaxLength(100)]
    public string? Namespace { get; set; }
    /// <summary>
    /// 是否有效
    /// </summary>
    public bool? IsValid { get; set; }
    /// <summary>
    /// 是否公开
    /// </summary>
    public bool? IsPublic { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CatalogId { get; set; }

}
