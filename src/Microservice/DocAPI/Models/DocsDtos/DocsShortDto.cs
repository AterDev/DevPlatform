namespace DocAPI.Models.DocsDtos;
/// <summary>
/// 文档
/// </summary>
public class DocsShortDto
{
    [MaxLength(100)]
    [MinLength(3)]
    public string Name { get; set; } = default!;
    public DocsCatalog DocsCatalog { get; set; } = default!;
    
}
