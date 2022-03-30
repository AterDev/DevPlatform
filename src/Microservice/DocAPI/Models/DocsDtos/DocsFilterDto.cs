namespace DocAPI.Models.DocsDtos;
/// <summary>
/// 文档
/// </summary>
public class DocsFilter : FilterBase
{
    [MaxLength(100)]
    [MinLength(3)]
    public string? Name { get; set; }
    public Guid? DocsCatalogId { get; set; } = default!;
    
}
