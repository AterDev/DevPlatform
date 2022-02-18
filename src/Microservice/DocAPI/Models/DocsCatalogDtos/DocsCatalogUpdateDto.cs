namespace DocAPI.Models.DocsCatalogDtos;
/// <summary>
/// 文档目录
/// </summary>
public class DocsCatalogUpdateDto
{
    [MaxLength(20)]
    [MinLength(3)]
    public string? Name { get; set; }
    public int? Sort { get; set; }
    
}
