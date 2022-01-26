namespace Share.Models.LibraryCatalogDtos;
/// <summary>
/// 目录/文件目录 / 自引用
/// </summary>
public class LibraryCatalogFilter : FilterBase
{
    [MaxLength(50)]
    public string? Name { get; set; }
    public short? Sort { get; set; }
    public short? Level { get; set; }
    public Guid? AccountId { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public Status? Status { get; set; }
    public Guid? ParentId { get; set; }
    
}
