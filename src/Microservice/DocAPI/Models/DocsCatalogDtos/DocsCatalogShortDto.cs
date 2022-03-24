namespace DocAPI.Models.DocsCatalogDtos;
/// <summary>
/// 文档目录
/// </summary>
public class DocsCatalogShortDto
{
    /// <summary>
    /// 父节点
    /// </summary>
    public DocsCatalog? Parent { get; set; } = default!;
    [MaxLength(20)]
    [MinLength(3)]
    public string Name { get; set; } = default!;
    public int Sort { get; set; } = default!;
    
}
