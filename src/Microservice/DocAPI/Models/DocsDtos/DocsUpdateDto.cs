namespace DocAPI.Models.DocsDtos;
/// <summary>
/// 文档
/// </summary>
public class DocsUpdateDto
{
    [MaxLength(100)]
    [MinLength(3)]
    public string? Name { get; set; }
    [MaxLength(10000)]
    public string? Content { get; set; }
    public Guid? DocsCatalogId { get; set; } = default!;
    public LanguageType Language { get; set; } = LanguageType.EN;

}
