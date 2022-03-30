namespace DocAPI.Models.DocsCatalogDtos;
/// <summary>
/// 文档目录
/// </summary>
public class DocsCatalogFilter : FilterBase
{
    [MaxLength(20)]
    [MinLength(3)]
    public string? Name { get; set; }
    public int? Sort { get; set; }
    public Guid? ParentId { get; set; } = default!;
    
}
