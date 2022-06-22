namespace DocAPI.Models.DocsCatalogDtos;
/// <summary>
/// 文档目录
/// </summary>
public class DocsCatalogItemDto
{
    [MaxLength(20)]
    [MinLength(3)]
    public string Name { get; set; } = default!;
    public int Sort { get; set; } = default!;
    public Guid Id { get; set; } = default!;
    public LanguageType Language { get; set; } = LanguageType.EN;
}
