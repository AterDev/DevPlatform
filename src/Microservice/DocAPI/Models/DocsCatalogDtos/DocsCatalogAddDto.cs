namespace DocAPI.Models.DocsCatalogDtos;

public class DocsCatalogAddDto
{
    public Guid? ParentId { get; set; }
    [MaxLength(20)]
    [MinLength(3)]
    public string? Name { get; set; }
    public int? Sort { get; set; }
    public LanguageType Language { get; set; } = LanguageType.EN;
}
